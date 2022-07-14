// See https://aka.ms/new-console-template for more information

using PrologInterpreter.Clause;
using PrologInterpreter.Functor;
using PrologInterpreter.Tree;

//var father = new Functor("father", "john", "jane");
//var mother = new Functor("mother", "valeria", "jane");
//var rule_1 = new Rule(new Functor("son", "Y", "X"), new Functor("father", "X", "Y"));





//Access to functor head.
//var a = goal.Atom.Name();
//Console.WriteLine(a);

/*var father = new Functor("father", "alex", "bill");
var mother = new Functor("mother", "alice", "bill");
var rule1 = new Rule(new Functor("child", "J", "K"), new Functor("mother", "K", "J"));
var rule2 = new Rule(new Functor("child", "G", "H"), new Functor("father", "H", "G"));
var rule3 = new Rule(new Functor("son", "X", "Y"), 
    new Functor("child", "X", "Y"), new Functor("boy", "X"));
var rules = new List<IClause> { rule1, rule2, rule3};
var facts = new List<IClause> { father, mother};
var goal = new Functor("son", "bill, A");
*/
var sells = new Functor("robert", "ballistic", "cuba");
var missile = new Functor("ballistic");
var american = new Functor("american", "robert");
var enemy = new Functor("enemy", "cuba", "america");
var rule1 = new Rule(new Functor("hostile", "Z"), new Functor("enemy", "Z", "america"));
var rule2 = new Rule(new Functor("weapon", "Y"), new Functor("missile", "Y"));
var rule3 = new Rule(new Functor("criminal", "X"),
    new Functor("american", "X"),
    new Functor("weapon", "Y"),
    new Functor("sells", "X", "Y", "Z"),
    new Functor("hostile", "Z"));

var rules = new List<IClause> { rule1, rule2, rule3};
var facts = new List<IClause> { sells, missile, enemy, american};
var goal = new Functor("criminal", "robert");

Console.WriteLine("-----------------------------");
var tree = new Tree(new Node(), rules, facts, goal);
tree.InitFromGoal();
tree.InitRulesAndFacts(tree.root.children);
var a = tree.root.children;

/*foreach (var r in a)
{
    Console.WriteLine(r.Clause.Head().Name());
    foreach (var c in r.children)
    {
        Console.WriteLine(c.Clause.Head().Name());
        foreach (var f in c.children)
        {
            Console.WriteLine(f.Clause.Head().Name());
        }
    }
    
}*/




/*foreach (var f in facts)
{
    Console.WriteLine(f.Head().ToString());
}*/
