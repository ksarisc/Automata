using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata.Activities.IO;

[Operation("Move File", OperationGroup = OperationGroup.IO)]
public class FileMove : IDataTableActivity
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
