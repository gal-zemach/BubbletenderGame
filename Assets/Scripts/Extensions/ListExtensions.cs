using System;
using System.Collections.Generic;

public static class ListExtensions
{
    public static List<int> GetRandomIndices<T>(this List<T> list, int n)
    {
        if (n < 0 || n > list.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "The number of indices requested must be between 0 and the size of the list.");
        }

        List<int> indices = new List<int>(list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            indices.Add(i);
        }

        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            int randomIndex = random.Next(i, indices.Count);
            (indices[i], indices[randomIndex]) = (indices[randomIndex], indices[i]);
        }

        return indices.GetRange(0, n);
    }
}
