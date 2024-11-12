using Automata.Activities;
using System;

namespace Automata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute
    {
        private readonly Type _dependency;
        private readonly IActivity? _instance;

        public DependsOnAttribute(Type dependency, IActivity? activity)
        {
            _dependency = dependency;
            _instance = activity;
        }
    }
}
