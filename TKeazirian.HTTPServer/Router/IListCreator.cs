using System.Collections;

namespace TKeazirian.HTTPServer.Router;

public abstract class ListCreator : IList<string>
{
    protected ListCreator()
    {

    }

    public abstract int Count { get; }
    public abstract bool IsReadOnly { get; }

    public abstract void Add(string item);
    public abstract void Clear();
    public abstract bool Contains(string item);
    public abstract void CopyTo(string[] array, int arrayIndex);
    public abstract bool Remove(string item);
    public abstract IEnumerator<string> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<string>)this).GetEnumerator();
    }

    public abstract int IndexOf(string item);
    public abstract void Insert(int index, string item);
    public abstract void RemoveAt(int index);
    public abstract string this[int index] { get; set; }
}
