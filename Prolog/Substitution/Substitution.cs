using PrologInterpreter.Term;

namespace PrologInterpreter.Substitution;

public class Substitution
{
    public Substitution(IVariable substitutable, ITerm by)
    {
        Substitutable = substitutable;
        By = by;
    }

    public IVariable Substitutable { get; set; }

    public ITerm By { get; set; }
}