using System;

namespace Automata.Activities.Logic
{
    [Operation("For Each", OperationGroup = OperationGroup.Logic)]
    public class ForEach : BaseSequenceActivity
    {
        public override void Run(IDependencyFactory factory, IState state)
        {
            throw new NotImplementedException();
        }

        public override Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }
    }
}
