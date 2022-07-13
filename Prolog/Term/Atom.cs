using PrologInterpreter.Truth;

namespace PrologInterpreter.Term;

public sealed class Atom : IAtom, IEquatable<Atom>
{
    public Atom(string name)
    {
        Name = name;
    }

    public string Name { get; }

    string ITerm.Name()
    {
        return Name;
    }
    
    Truthness ITerm.Truth()
    {
        return Truthness.True;
    }

    public bool Equals(Atom? other)
    {
        return !ReferenceEquals(null, other) && string.Equals(Name, other.Name);
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Atom) obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}