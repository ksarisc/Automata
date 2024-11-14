using System;

namespace Automata.Activities
{
    public interface ISequenceActivity : IActivity
    {
        public int Iteration { get; }
    }

    public abstract class BaseSequenceActivity : ISequenceActivity
    {
        public int Iteration { get; protected set; }

        public int Index { get; protected set; }

        public void Log(string message)
        {
            //_log.Append(message);
        }

        public abstract void Run(IDependencyFactory factory, IState state);
        //public void Run(IDependencyFactory factory, IState state){
        //    throw new NotImplementedException();
        //}

        public abstract Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel);
        //public Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel){
        //    throw new NotImplementedException();
        //}

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
