using System;

namespace Automata.Activities.Logic
{
    [Operation("For Each", OperationGroup = OperationGroup.Logic)]
    public sealed class IfElse : BaseSequenceActivity
    {
        public CSharpValue<bool>? Condition { get; set; }
        public IActivity? If { get; set; }
        public IActivity? Else { get; set; }

        public override void Run(IDependencyFactory factory, IState state)
        {
            throw new NotImplementedException();
        }

        public override Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
