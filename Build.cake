#tool nuget:?package=NUnit.ConsoleRunner&version=3.11.1
#tool nuget:?package=docfx.console&version=2.56.1

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var dnnServerPath = Argument("dnnServerPath", string.Empty);
var solution = Argument("solution-file", "docfx-feedback.sln");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    DotNetCoreClean(solution);
});

Task("Restore")
    .Does(() =>
{
    DotNetCoreRestore(solution);
});

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration
    };
    DotNetCoreBuild(solution, settings);
});

Task("DnnDeploy")
    .IsDependentOn("Build")
    .Does(() =>
{
    // Copy Dnn Files
    CopyFiles($"Dnn.*/**/bin/{configuration}/**/*.dll", $"{dnnServerPath}/bin");
    if (configuration.ToLower() == "debug")
        CopyFiles($"Dnn.*/**/bin/{configuration}/**/*.pdb", $"{dnnServerPath}/bin");

});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);