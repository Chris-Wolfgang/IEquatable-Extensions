type: fix

The `net462` and `netstandard2.0` assets now declare every parameter `T?`, the same nullable annotations the `net8.0` and `net10.0` assets already had, so nullable-enabled consumers get the same flow analysis on every target framework.
