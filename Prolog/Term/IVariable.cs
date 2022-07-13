namespace PrologInterpreter.Term;

public interface IVariable : ITerm
{
    int ITerm.Arity()
    {
        return 0;
    }
}