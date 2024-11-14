using System.Data;

namespace Automata.Activities;

public interface IDataTableActivity : IActivity
{
    public IEnumerable<string> GetColumnNames();
    //public DataTable GetSchema();
    public DataTable GetData();
}

public abstract class BaseDataTableActivity : IDataTableActivity
{
    //public int Iteration { get; set; } = 0;
    public int Index { get; set; }

    protected readonly List<string> _columns = new();
    protected readonly DataTable _data = new();

    void IActivity.Log(string message)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetColumnNames() => _columns;

    public DataTable GetData() => _data;

    public abstract void Run(IDependencyFactory factory, IState state);

    public abstract Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel);

    #region cleanup
    protected virtual void Dispose(bool disposing)
    {
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion cleanup
}
