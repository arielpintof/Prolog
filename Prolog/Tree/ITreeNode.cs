namespace PrologInterpreter.Tree;

public interface ITreeNode<T>
{
    T Parent { get; set; }
    
    bool IsLeaf { get; }
    
    bool IsRoot { get; }
    
    T GetRootNode();
    
    string GetFullyQualifiedName();
}