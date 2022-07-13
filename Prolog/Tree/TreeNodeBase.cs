namespace PrologInterpreter.Tree;

public abstract class TreeNodeBase<T> : ITreeNode<T> where T : class, ITreeNode<T>
{
    public string Name { get; private set; }
    public T Parent { get; set; }
    public List<T> ChildNodes { get; private set; }

    protected abstract T MySelf { get; }
    
    protected TreeNodeBase(string name)
    {
        Name = name;
        ChildNodes = new List<T>();
    }
    public bool IsLeaf 
    {
        get { return ChildNodes.Count == 0; }
    }

    public bool IsRoot
    {
        get { return Parent == null; }
    }

   
    public List<T> GetLeafNodes()
    {
        return ChildNodes.Where(x => x.IsLeaf).ToList();
    }

    
    public List<T> GetNonLeafNodes()
    {
        return ChildNodes.Where(x => !x.IsLeaf).ToList();
    }

   
    public T GetRootNode()
    {
        if (Parent == null)
            return MySelf;

        return Parent.GetRootNode();
    }

  
    public string GetFullyQualifiedName()
    {
        if (Parent == null)
            return Name;

        return string.Format("{0}.{1}", Parent.GetFullyQualifiedName(), Name);
    }

    
    public void AddChild(T child)
    {
        child.Parent = MySelf;
        ChildNodes.Add(child);
    }
    
    public void AddChildren(IEnumerable<T> children)
    {
        foreach (T child in children)
            AddChild(child);
    }
}
    
