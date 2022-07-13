using PrologInterpreter.Clause;

namespace PrologInterpreter.Interpreter;

public class KnowledgeBase
{
    public IEnumerable<IClause> Clauses { get; set; } = new HashSet<IClause>();
}