using System;

namespace Automata;

public class CSharpValue<T>
{
    public T? Value { get; set; } = default;
    public bool IsText { get; set; }
}
