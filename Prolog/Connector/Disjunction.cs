using PrologInterpreter.Term;
using PrologInterpreter.Truth;

namespace PrologInterpreter.Connector;

public class Disjunction : IConnector
{
    public Truthness Truth(ITerm left, ITerm right)
    {
        return (left.Truth(), right.Truth()) switch
        {
            (Truthness.Unknown, _) => Truthness.Unknown,
            (_, Truthness.Unknown) => Truthness.Unknown,
            (Truthness.True, _) => Truthness.True,
            (_, Truthness.True) => Truthness.True,
            (Truthness.False, Truthness.False) => Truthness.False,
            _ => throw new ArgumentException("Enum values not recognized")
        };
    }
}