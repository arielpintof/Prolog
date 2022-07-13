using PrologInterpreter.Clause;

namespace PrologInterpreter.Tree;

public class Methods
{
    public static List<IClause> Concat(IEnumerable<IClause> rules, IEnumerable<IClause> functors)
    {
        return rules.Concat(functors).ToList();;
    }
    
}