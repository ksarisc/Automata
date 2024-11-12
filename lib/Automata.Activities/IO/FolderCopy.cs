using System;
using System.Data;

namespace Automata.Activities.IO;

[Operation("Copy Folder", OperationGroup = OperationGroup.IO)]
public class FolderCopy : IDataTableActivity
{
    public IEnumerable<string> GetColumnNames()
    {
        throw new NotImplementedException();
    }

    public DataTable GetData()
    {
        throw new NotImplementedException();
    }

    public void Run(IDependencyFactory factory, IState state)
    {
        throw new NotImplementedException();
    }

    public Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
