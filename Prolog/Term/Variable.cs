using PrologInterpreter.Truth;

namespace PrologInterpreter.Term;

public sealed class Variable : IVariable, IEquatable<Variable>
{
    public Variable(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public bool Equals(Variable? other)
    {
        return !ReferenceEquals(null, other) && string.Equals(Name, other.Name);
    }

    string ITerm.Name()
    {
        return Name;
    }

    Truthness ITerm.Truth()
    {
        return Truthness.Unknown;
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Variable) obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}