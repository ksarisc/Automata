using System.Threading.Tasks;

namespace Automata.Activities
{
    public interface IActivity : IDisposable
    {
        public int Index {  get; }

        protected void Log(string message);
        public void Run(IDependencyFactory factory, IState state);

        public Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel);
    }
}
