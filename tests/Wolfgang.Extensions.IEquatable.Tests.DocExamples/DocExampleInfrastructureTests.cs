using Xunit.Sdk;

namespace Wolfgang.Extensions.IEquatable.Tests.DocExamples;

/// <summary>
/// Exercises the paths of the doc-example harness that a green
/// <see cref="DocExampleRotTests"/> run never reaches on its own: the
/// "src project not found" failure and the xunit serialization round-trip
/// that a discovery/execution split relies on.
/// </summary>
public sealed class DocExampleInfrastructureTests
{
    [Fact]
    public void FindSrcDirectory_when_no_ancestor_contains_the_src_project_throws_DirectoryNotFoundException()
    {
        // A directory that does not exist under the temp folder: DirectoryInfo walks
        // its parents without touching it, and no ancestor of the temp folder holds
        // src/Wolfgang.Extensions.IEquatable/.
        var startDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));

        var exception = Assert.Throws<DirectoryNotFoundException>
        (
            () => DocExampleSource.FindSrcDirectory(startDirectory)
        );

        Assert.Contains(startDirectory, exception.Message, StringComparison.Ordinal);
    }



    [Fact]
    public void DocExample_when_round_tripped_through_xunit_serialization_preserves_every_property()
    {
        var original = new DocExample("IEquatableExtensions.cs", 42, "var found = 5.IsInSet(1, 5, 10);");

        var copy = SerializationHelper.Deserialize<DocExample>
        (
            SerializationHelper.Serialize(original)
        );

        Assert.Equal
        (
            (original.File, original.Line, original.Code),
            (copy.File, copy.Line, copy.Code)
        );
    }
}
