using PrologInterpreter.Clause;

namespace Prolog.Tree;

public class Node
{
    public IClause Clause { get; set; }
    public readonly List<Node> Children;
    
    public Node()
    {
        Children = new List<Node>();
    }
    public Node(IClause clause)
    {
        Clause = clause;
        Children = new List<Node>();
    }

    public Node(IClause clause, List<Node> children)
    {
        Clause = clause;
        this.Children = children;
    }

    public void AddChild(Node c)
    {
        Children.Add(c);
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

