using PrologInterpreter.Term;
using PrologInterpreter.Truth;

namespace PrologInterpreter.Connector;

public class Conjunction : IConnector
{
    public Truthness Truth(ITerm left, ITerm right)
    {
        return (left.Truth(), right.Truth()) switch
        {
            (Truthness.Unknown, _) => Truthness.Unknown,
            (_, Truthness.Unknown) => Truthness.Unknown,
            (Truthness.False, _) => Truthness.False,
            (_, Truthness.False) => Truthness.False,
            (Truthness.True, Truthness.True) => Truthness.True,
            _ => throw new ArgumentException("Enum values not recognized")
        };
    }
}