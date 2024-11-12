using System.Data;

namespace Automata.Activities
{
    public interface IDataTableActivity : IActivity
    {
        public IEnumerable<string> GetColumnNames();
        //public DataTable GetSchema();
        public DataTable GetData();
    }
}
