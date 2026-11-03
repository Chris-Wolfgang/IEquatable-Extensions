using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Wolfgang.Extensions.IEquatable.Tests.Unit;

/// <summary>
/// The library is a set of synchronous, stateless extension methods: no static fields, no caches,
/// no async state machines and nothing to dispose. Its only exposure to concurrency is many threads
/// reading the same set at once, so these tests do exactly that from several dedicated threads
/// released together by a <see cref="Barrier"/>. Assertions are structural (every answer matches the
/// single-threaded answer, the shared set is unchanged, nothing throws), so they do not depend on timing.
/// </summary>
/// <remarks>
/// Systematic schedule exploration (Coyote) and long soak runs are deliberately not used: with no
/// shared mutable state and no awaits there are no interleavings for a model checker to explore and no
/// handles, threads or memory for a soak run to leak.
/// </remarks>
public class ConcurrencyTests
{
    private const int Threads = 8;
    private const int IterationsPerThread = 2_000;
    private const int ItemCount = 64;



    [Fact]
    public async Task IsInSet_T_ICollection_when_called_concurrently_on_a_shared_HashSet_returns_the_single_threaded_answer()
    {
        ICollection<int?> set = new HashSet<int?>(Enumerable.Range(0, ItemCount).Select(i => (int?)(i * 2)));

        var wrongAnswers = await CountWrongAnswersAsync(value => ((int?)value).IsInSet(set), value => value % 2 == 0 && value < ItemCount * 2);

        Assert.Equal(0, wrongAnswers);
        Assert.Equal(ItemCount, set.Count);
    }



    [Fact]
    public async Task IsNotInSet_T_IEnumerable_when_called_concurrently_on_a_shared_List_returns_the_single_threaded_answer()
    {
        var list = Enumerable.Range(0, ItemCount).Select(i => (int?)(i * 2)).ToList();
        IEnumerable<int?> set = list;

        var wrongAnswers = await CountWrongAnswersAsync(value => ((int?)value).IsNotInSet(set), value => value % 2 != 0 || value >= ItemCount * 2);

        Assert.Equal(0, wrongAnswers);
        Assert.Equal(Enumerable.Range(0, ItemCount).Select(i => (int?)(i * 2)), list);
    }



    [Fact]
    public async Task IsInSet_T_ParamsArray_when_called_concurrently_on_a_shared_array_returns_the_single_threaded_answer()
    {
        var array = Enumerable.Range(0, ItemCount).Select(i => (int?)(i * 3)).ToArray();

        var wrongAnswers = await CountWrongAnswersAsync(value => ((int?)value).IsInSet(array), value => value % 3 == 0 && value < ItemCount * 3);

        Assert.Equal(0, wrongAnswers);
        Assert.Equal(Enumerable.Range(0, ItemCount).Select(i => (int?)(i * 3)), array);
    }



    [Fact]
    public async Task IsInSet_T_T1_T2_T3_and_NotEqual_when_called_concurrently_on_shared_instances_return_the_single_threaded_answer()
    {
        var a = new IEquatableTestClass(1);
        var b = new IEquatableTestClass(2);
        var c = new IEquatableTestClass(3);

        var wrongAnswers = await CountWrongAnswersAsync
        (
            value => new IEquatableTestClass(value).IsInSet(a, b, c) && new IEquatableTestClass(value).NotEqual(a) == (value != 1),
            value => value is >= 1 and <= 3
        );

        Assert.Equal(0, wrongAnswers);
    }



    // Runs the call for values 0 .. (ItemCount * 4) on every thread at once and counts the answers
    // that differ from the expected single-threaded answer. Adding 0 or 1 per call keeps the counting
    // one executed statement rather than a branch that only runs when the test is failing.
    private static async Task<int> CountWrongAnswersAsync(Func<int, bool> call, Func<int, bool> expected)
    {
        var wrongAnswers = 0;

        await RunOnDedicatedThreadsAsync
        (
            () =>
            {
                for (var i = 0; i < IterationsPerThread; i++)
                {
                    var value = i % (ItemCount * 4);
                    Interlocked.Add(ref wrongAnswers, call(value) == expected(value) ? 0 : 1);
                }
            }
        );

        return wrongAnswers;
    }



    private static async Task RunOnDedicatedThreadsAsync(Action body)
    {
        using var barrier = new Barrier(Threads);

        var tasks = Enumerable
            .Range(0, Threads)
            .Select
            (
                _ => Task.Factory.StartNew
                (
                    () =>
                    {
                        barrier.SignalAndWait();
                        body();
                    },
                    CancellationToken.None,
                    TaskCreationOptions.LongRunning,
                    TaskScheduler.Default
                )
            )
            .ToArray();

        await Task.WhenAll(tasks);
    }
}
