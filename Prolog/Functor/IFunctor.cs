using PrologInterpreter.Term;
using PrologInterpreter.Truth;

namespace PrologInterpreter.Functor;

public interface IFunctor : ITerm
{
    Truthness ITerm.Truth()
    {
        return HasVariables() ? Truthness.Unknown : Truthness.True;
    }

    public IEnumerable<ITerm> CollectVariables();

    public IEnumerable<ITerm> CollectAtoms();

    bool HasVariables();
}