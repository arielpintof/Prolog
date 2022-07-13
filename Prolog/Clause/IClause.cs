using PrologInterpreter.Functor;

namespace PrologInterpreter.Clause;

public interface IClause
{
    public IFunctor Head();

    public IEnumerable<IFunctor> Body();
}