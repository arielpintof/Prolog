using PrologInterpreter.Term;
using PrologInterpreter.Truth;

namespace PrologInterpreter.Connector;

public interface IConnector
{
    public Truthness Truth(ITerm left, ITerm right);
}