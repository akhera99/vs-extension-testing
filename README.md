﻿# Visual Studio Extension Testing

This project allows Visual Studio extension developers to write integration tests that run inside an experimental
instance of Visual Studio.

[![License](https://img.shields.io/github/license/Microsoft/vs-extension-testing.svg)](https://raw.githubusercontent.com/Microsoft/vs-extension-testing/master/LICENSE) [![Azure Artifacts](https://img.shields.io/badge/dynamic/json.svg?style=flat&color=e05d44&logo=nuget&label=azure%20artifacts&query=$.versions[0]&url=https%3A%2F%2Fpkgs.dev.azure.com%2Fazure-public%2Fvside%2F_packaging%2Fvssdk%2Fnuget%2Fv3%2Fflat2%2Fmicrosoft.visualstudio.extensibility.testing.xunit%2Findex.json)](https://dev.azure.com/azure-public/vside/_artifacts/feed/vssdk/NuGet/Microsoft.VisualStudio.Extensibility.Testing.Xunit/)

# Installation and Use

## Requirements

* Extension development requires [Visual Studio 2017](https://visualstudio.microsoft.com/vs/) or newer. Version 15.7 or
  newer is recommended for the best Test Explorer experience.
* Extensions themselves must target one or more versions of Visual Studio from the following list:
    * Visual Studio 2012
    * Visual Studio 2013
    * Visual Studio 2015
    * Visual Studio 2017
    * Visual Studio 2019
    * Visual Studio 2022
* Extensions must be deployed via one or more VSIX packages.
* Test execution and debugging is only supported for versions of Visual Studio available on the same machine as the
  development IDE.

## Install the test harness

### Install the test package for the applicable version(s) of Visual Studio

| Visual Studio Version | Integration Testing Package |
| --- | --- |
| 2022 | Microsoft.VisualStudio.Extensibility.Testing.Xunit |
| 2012 - 2019 | Microsoft.VisualStudio.Extensibility.Testing.Xunit.Legacy |

### Configure the test framework

#### Classic projects

Add the following to **AssemblyInfo.cs** to enable the test framework:

```csharp
using Xunit;

[assembly: TestFramework("Xunit.Harness.IdeTestFramework", "Microsoft.VisualStudio.Extensibility.Testing.Xunit")]
```

#### SDK projects

> 💡 By default, SDK projects automatically generate the required assembly attribute. Manual customization is only
> required if the default assembly attributes support has been disabled, or in cases where the automatic application of
> `TestFrameworkAttribute` is not desired.

To disable generation of `TestFrameworkAttribute` (which will require manual addition similar to classic projects), add
the following to the project file:

```xml
<PropertyGroup>
  <GenerateTestFrameworkAttribute>false</GenerateTestFrameworkAttribute>
</PropertyGroup>
```

### Configure extensions for deployment

Add the following to **AssemblyInfo.cs** to deploy extensions required for testing.

```csharp
using Xunit.Harness;

[assembly: RequireExtension("Extension.File.Name.vsix")]
```

## Ensure test discovery is enabled

Test projects using a customized xUnit test framework cannot currently be discovered while tests are being written. The
test discovery process that runs after a build completes will detect the required tests. Ensure this feature is enabled
by the following steps:

1. Open **Tools** &rarr; **Options...**
2. Select the **Test** page on the left
3. Ensure **Additionally discover tests from built assemblies after builds** is checked

Tests will be automatically discovered and **Test Explorer** updated after each successful build.

## Write tests

Apply the `[IdeFact]` attribute to tests that need to run in the IDE. After building the project, the tests will
appear in **Test Explorer** where they can be launched for running and/or debugging directly.

# Contributing

Please see [CONTRIBUTING.md](CONTRIBUTING.md) for information about our Code of Conduct and contributing guidelines.
