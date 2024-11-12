using System;

namespace Automata.Activities;

public interface IState
{
    //public string Name { get; }
    public int Level { get; }
    public int Index { get; }

    public string TempPath { get; }
    public string Path { get; }
}
