using System;

namespace Automata.Activities.Process;

[Operation("Run App", OperationGroup = OperationGroup.Proc)]
public class RunApp : BaseDataTableActivity
{
    //ScriptValue
    public CSharpValue<string> Application { get; set; } = new();
    public CSharpValue<string> LaunchPath { get; set; } = new();
    public CSharpValue<string> Arguments { get; set; } = new();

    public RunApp()
    {
        _columns.AddRange([
            "Output",
        ]);
        _data.Columns.Add("Output", typeof(string));
    }

    public override void Run(IDependencyFactory factory, IState state)
    {
        throw new NotImplementedException();
    }

    public override Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel)
    {
        throw new NotImplementedException();
    }
}
