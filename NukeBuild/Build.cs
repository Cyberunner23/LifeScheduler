using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.IO;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.Npm.NpmTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    AbsolutePath FrontendPath = RootDirectory / "LifeScheduler.Frontend";

    [Parameter("Configuration to build - Default is 'Debug'")]
    Configuration Configuration = Configuration.Debug;

    [Solution] readonly Solution Solution;

    Target FrontendRestore => _ => _
        .Executes(() => {
            Npm("i", FrontendPath);
        });

    Target FrontendBuild => _ =>_
        .DependsOn(FrontendRestore)
        .Executes(() =>
        {
            Npm("run build", FrontendPath);
        });

    Target NugetRestore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });
    Target Compile => _ => _
        .DependsOn(NugetRestore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    // TODO(AFL): Re-enable this once https://github.com/dotnet/sdk/issues/12490 is fixed

    /*Target PublishLocalServerHosted => _ => _
        .Executes(() => 
        {
            DotNetPublish(x => x
                .SetProject(Solution.GetProject("LifeScheduler.ServerHost"))
                .SetPublishProfile("LocalFolder"));
            DotNetPublish(x => x
                .SetProject(Solution.GetProject("LifeScheduler.Frontend"))
                .SetPublishProfile("LocalFolder"));
        });*/

    public static int Main() => Execute<Build>(x => x.Compile);
}
