using System;
using System.Collections;
using System.Collections.Generic;

public class SortedMultiset<T> : IEnumerable<T> where T : IComparable<T>
{
    private readonly List<T> elements = new List<T>();
    private readonly IComparer<T> comparer;

    public SortedMultiset(IComparer<T> comparer = null)
    {
        this.comparer = comparer ?? Comparer<T>.Default;
    }

    public void Add(T item)
    {
        int index = elements.BinarySearch(item, comparer);
        if (index < 0)
            index = ~index; // Get the index of the next greater element
        elements.Insert(index, item);
    }

    public bool Remove(T item)
    {
        int index = elements.BinarySearch(item, comparer);
        if (index >= 0)
        {
            elements.RemoveAt(index);
            return true;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}