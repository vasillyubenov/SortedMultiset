using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SortedMultiset
{
    private SortedSet<Cake> sortedSet;
    private Dictionary<Cake, int> countDictionary;

    public SortedMultiset()
    {
        sortedSet = new SortedSet<Cake>();
        countDictionary = new Dictionary<Cake, int>();
    }

    public void Add(Cake item)
    {
        if (countDictionary.ContainsKey(item))
        {
            countDictionary[item]++;
        }
        else
        {
            sortedSet.Add(item);
            countDictionary[item] = 1;
        }
    }

    public Cake First()
    {
        return sortedSet.First();
    }

    public bool Remove(Cake item)
    {
        if (countDictionary.ContainsKey(item))
        {
            countDictionary[item]--;
            if (countDictionary[item] == 0)
            {
                sortedSet.Remove(item);
                countDictionary.Remove(item);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public int Count()
    {
        return sortedSet.Count;
    }

    public int GetCakeCount(Cake item)
    {
        if (countDictionary.TryGetValue(item, out int count))
        {
            return count;
        }
        else
        {
            return 0;
        }
    }

    public IEnumerable<Cake> Elements
    {
        get
        {
            foreach (var item in sortedSet)
            {
                for (int i = 0; i < countDictionary[item]; i++)
                {
                    yield return item;
                }
            }
        }
    } 
}