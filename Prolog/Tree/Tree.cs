using System.Xml;
using PrologInterpreter.Clause;
using PrologInterpreter.Functor;
using PrologInterpreter.Term;


namespace PrologInterpreter.Tree;

public class Tree 
{
    public Node root;
    private IClause goal { get; set; }
    private List<IClause> clauses { get; set; }
    
    public Tree()
    {
        root = null;
    }

    public Tree(Node root, IEnumerable<IClause> rules, IEnumerable<IClause> functors, IClause goal)
    {
        this.root = null;
        this.goal = goal;
        this.clauses = Methods.Concat(rules, functors);

    }

    public void initFromFacts()
    {
        
    }
    public void InitFromGoal()
    {
        var goalHead = goal.Head().Name();
        var children = Methods.FindHead(clauses, goalHead);
        root = new Node(goal);
        Methods.AddChildrenNodes(root, children);
        Console.WriteLine("Functor Goal Head : " + goalHead);
        
        //InitRulesAndFacts(root.children);
    }

    public void InitRulesAndFacts(List<Node> nodes)
    {
        foreach (var node in nodes)
        {
            var bodyFunctors = Methods.getFunctors(node);
            foreach (var functor in bodyFunctors)
            {
                var goalHead = functor.Name();
                Console.WriteLine("Functor Goal Head : " + goalHead);
                var children = Methods.FindHead(clauses, goalHead);
                Methods.AddChildrenNodes(node, children);
            }

            /*var p1 = node.children;
            foreach (var a in p1)
            {
                var d = a.Clause.Head().Name();
                Console.WriteLine(d);
            }*/
            
            InitRulesAndFacts(node.children);
        }
        
        
       
        
        
        
       
    }
    
    
    
}