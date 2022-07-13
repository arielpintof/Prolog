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

var father = new Functor("father", "alex", "bill");
var mother = new Functor("mother", "alice", "bill");
var rule1 = new Rule(new Functor("child", "J", "K"), new Functor("mother", "K", "J"));
var rule2 = new Rule(new Functor("child", "G", "H"), new Functor("father", "H", "G"));
var rule3 = new Rule(new Functor("son", "X", "Y"), 
    new Functor("child", "X", "Y"), new Functor("boy", "X"));
var rules = new List<IClause> { rule1, rule2, rule3};
var facts = new List<IClause> { father, mother};
var goal = new Functor("son", "bill, A");

Console.WriteLine("-----------------------------");
var tree = new Tree(new Node(), rules, facts, goal);
tree.InitGoal();


/*foreach (var f in facts)
{
    Console.WriteLine(f.Head().ToString());
}*/
