using System.Collections;

namespace Iterator1;

public abstract class Iterator<T> : IEnumerator<T>
{
    public abstract T Current { get; }
    object IEnumerator.Current => Current;
    public abstract bool MoveNext();
    public abstract void Reset();
    public virtual void Dispose() { }
}
