using System.Collections.Immutable;
using PrologInterpreter.Clause;
using PrologInterpreter.Term;
using PrologInterpreter.Truth;

namespace PrologInterpreter.Functor;

public sealed class Functor : IFunctor, IClause, IEquatable<Functor>
{
    public Functor(string name)
    {
        Atom = new Atom(name);
    }

    public Functor(string name, params string[] termNames)
    {
        Atom = new Atom(name);
        Arguments.UnionWith(termNames.Select(ITerm.CreateTerm));
        Truth = HasVariables() ? Truthness.Unknown : Truthness.True;
        Console.WriteLine(Truth);
    }

    public IAtom Atom { get; }
    public ISet<ITerm> Arguments { get; } = new HashSet<ITerm>();
    public Truthness Truth { get; }

    string ITerm.Name()
    {
        return Atom.Name();
    }

    int ITerm.Arity()
    {
        return Arguments.Count;
    }

    public bool HasVariables()
    {
        return Arguments.Any(e => e is IVariable);
    }

    IEnumerable<ITerm> IFunctor.CollectVariables()
    {
        return Arguments.Where(e => e is IVariable);
    }

    IEnumerable<ITerm> IFunctor.CollectAtoms()
    {
        return Arguments.Where(e => e is IAtom);
    }
    
    IFunctor IClause.Head()
    {
        return this;
    }

    IEnumerable<IFunctor> IClause.Body()
    {
        return ImmutableHashSet<IFunctor>.Empty;
    }

    public override string ToString()
    {
        return $"{Atom}({string.Join(", ", Arguments)})";
    }
    
    public bool Equals(Functor? other)
    {
        return !ReferenceEquals(null, other) && Equals(Atom, other.Atom) && Arguments.SequenceEqual(other.Arguments);
    }
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return GetType() == obj.GetType() && Equals((Functor) obj);
    }

    public override int GetHashCode()
    {
        return (Atom, Arguments).GetHashCode();
    }
    
}