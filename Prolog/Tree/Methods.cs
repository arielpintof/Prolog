using PrologInterpreter.Clause;
using PrologInterpreter.Functor;

namespace PrologInterpreter.Tree;

public class Methods
{
    public static List<IClause> Concat(IEnumerable<IClause> rules, IEnumerable<IClause> functors)
    {
        return rules.Concat(functors).ToList();;
    }

    public static IEnumerable<IClause> FindHead(List<IClause> clauses, string GoalHead)
    {
        var results = clauses.Where(s => s.Head().Name() == GoalHead);
        return results; 
    }

    public static void AddChildrenNodes(Node node, IEnumerable<IClause> clauses)
    {
        foreach (var c in clauses)
        {
            var newNode = new Node(c);
            node.AddChild(newNode);
        }
    }

    public static IEnumerable<IFunctor> getFunctors(Node nodes)
    {
        return nodes.Clause.Body();
    }

}