using System.Threading.Tasks;

namespace Automata.Activities
{
    public interface IActivity : IDisposable
    {
        //public int Iteration { get; }
        public int Index { get; }

        protected void Log(string message);

        public void Run(IDependencyFactory factory, IState state);

        public Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel);

        //public static IActivity Empty { get; } = new EmptyActivity();
    }

    //public sealed class EmptyActivity : IActivity{
    //    public int Index { get; } = 0;

    //    protected void Log(string message) { }
    //    void IActivity.Log(string message){
    //        //throw new NotImplementedException();
    //    }

    //    public void Run(IDependencyFactory factory, IState state) { }

    //    public Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel){
    //        return Task.CompletedTask;
    //    }

    //    public void Dispose(){
    //        GC.SuppressFinalize(this);
    //    }
    //}
}
