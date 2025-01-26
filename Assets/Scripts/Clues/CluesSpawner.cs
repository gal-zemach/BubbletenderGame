using System.Collections.Generic;
using UnityEngine;

public class CluesSpawner : MonoBehaviour
{
    public List<ClueScript> clueBubbles;

    private int NUMBER_OF_CLUES = 3;

    public void SpawnClues(BarOrder order)
    {
        var indices = clueBubbles.GetRandomIndices(NUMBER_OF_CLUES);
        
        clueBubbles[indices[0]].Set(order, ClueScript.ClueType.Glass);
        clueBubbles[indices[1]].Set(order, ClueScript.ClueType.Drink);
        clueBubbles[indices[2]].Set(order, ClueScript.ClueType.Garnish);
    }

    public void ClearClues()
    {
        foreach (var item in clueBubbles)
        {
            item.Clear();
        }
    }
}
