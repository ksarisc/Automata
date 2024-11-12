using Automata.Activities;

namespace Automata.Activities
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OperationAttribute : Attribute
    {
        public string DisplayName { get; }
        public OperationGroup OperationGroup { get; set; }

        public OperationAttribute(string displayName)
        {
            DisplayName = displayName;
            //OperationGroup = operationGroup ?? OperationGroup.IO;
        }
    }
}
