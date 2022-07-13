using PrologInterpreter.Functor;

namespace PrologInterpreter.Clause;

public class Rule : IClause
{
    public Rule(IFunctor head, params IFunctor[] body)
    {
        Head = head;
        Body.UnionWith(body);
    }

    public IFunctor Head { get; set; }
    public ISet<IFunctor> Body { get; set; } = new HashSet<IFunctor>();

    IFunctor IClause.Head()
    {
        return Head;
    }

    IEnumerable<IFunctor> IClause.Body()
    {
        return Body;
    }

    public override string ToString()
    {
        return $"{Head} :- {string.Join(", ", Body)}";
    }
}