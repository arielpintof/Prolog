using PrologInterpreter.Clause;
using PrologInterpreter.Functor;

namespace PrologInterpreter.Tree;

public class Node
{
    public IClause Clause { get; set; }
    public List<Node> children;
    

    public Node()
    {
        children = new List<Node>();
    }
    public Node(IClause clause)
    {
        Clause = clause;
        children = new List<Node>();
    }

    public Node(IClause clause, List<Node> children)
    {
        Clause = clause;
        this.children = children;
    }

    public void AddChild(Node c)
    {
        children.Add(c);
        /*if (children == null)
        {
            children = new List<Node>();
        }
        children.Add(t);*/
    }

    public bool IsLeaf ()
    {
        return Clause switch
        {
            Rule => false,
            _ => true
        };
    }
}

