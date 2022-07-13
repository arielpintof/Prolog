using PrologInterpreter.Truth;

namespace PrologInterpreter.Term;

public interface ITerm
{
    public static ITerm CreateTerm(string name)
    {
        return char.IsUpper(name[0]) ? new Variable(name) : new Atom(name);
    }

    public string Name();

    public int Arity();

    public Truthness Truth();
}