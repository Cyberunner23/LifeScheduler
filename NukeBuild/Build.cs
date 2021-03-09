using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    ///   

    [Parameter("Configuration to build - Default is 'Debug'")]
    Configuration Configuration = Configuration.Debug;

    [Solution] readonly Solution Solution;

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
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
