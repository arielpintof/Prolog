namespace PrologInterpreter.Term;

public interface IAtom : ITerm
{
    int ITerm.Arity()
    {
        return 0;
    }
}