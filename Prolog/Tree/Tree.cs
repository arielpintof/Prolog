using System.Xml;
using PrologInterpreter.Clause;
using PrologInterpreter.Functor;
using PrologInterpreter.Term;


namespace PrologInterpreter.Tree;

public class Tree 
{
    public Node root;
    private List<IClause> rules { get; set; }
    private List<IClause> functors { get; set; }
    private IClause goal { get; set; }
    
    private List<IClause> clausulas { get; set; }

    public Tree()
    {
        root = null;
    }

    public Tree(Node root, List<IClause> rules, List<IClause> functors, IClause goal)
    {
        this.root = null;
        this.rules = rules;
        this.functors = functors;
        this.goal = goal;

        clausulas = Methods.Concat(rules, functors);
    }

    public void InitGoal()
    {
        root = new Node(goal);
        var hijos = new List<Node>();

        foreach (var g in rules.ToList())
        {
            var goalHead = goal.Head().Name();
            var ruleHead = g.Head().Name();

            if (ruleHead.Equals(goalHead) /*|| ruleBody.Equals(goalHead)*/)
            {
                var node = new Node(g);
                hijos.Add(node);
                root.children = hijos;
                rules.Remove(g);
            }
            else
            {
                foreach (var facts in functors.ToList())
                {
                    
                    if (ruleHead.Equals(goalHead))
                    {
                        var node = new Node(facts);
                        root.children.Add(node);
                        functors.Remove(facts);
                    } 
                }
                    
            }
            
        }
        InitRulesAndFacts(root.children);
    }

    public void InitRulesAndFacts(List<Node> nodes)
    {

        if (nodes.Count == 0 )
        {
            Console.WriteLine("Termina");
        }
        else
        {
            Console.WriteLine(nodes.Count);
            var hijos = new List<Node>();
            var parent = new Node();
        
            foreach (var n in nodes)
            {
                foreach (var g in n.Clause.Body())
                {
                    foreach (var f in rules.ToList())
                    {
                        var ruleHead = f.Head().Name();
                        var goalHead = g.Name();
                        if (ruleHead.Equals(goalHead))
                        {
                            var node = new Node(f);
                            hijos.Add(node);
                            parent.children = hijos;
                            //root.children.Add(node);
                            rules.Remove(f);
                        }
                        else
                        {
                            foreach (var func in functors.ToList())
                            {
                                var headName = func.Head().Name();
                            
                                 if(headName.Equals(goalHead))
                                {
                                    //Console.WriteLine("ENTRA");
                                    var node = new Node(f);
                                    hijos.Add(node);
                                    parent.children = hijos;
                                    //root.children.Add(node);
                                    functors.Remove(f);
                                }
                            }
                        }
                    }

                }
            }
            InitRulesAndFacts(parent.children);
            //Console.WriteLine(parent.children.Count);
        }
        
        
        
       
    }
    
    
}