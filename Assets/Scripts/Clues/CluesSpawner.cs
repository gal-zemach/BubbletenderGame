using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesSpawner : MonoBehaviour
{
    public List<ClueScript> clueBubbles;

    public float timeBetweenCluesAnimation = .2f;

    private int NUMBER_OF_CLUES = 3;

    private BarOrder currOrder;

    public void SpawnClues(BarOrder order)
    {        
        currOrder = order;
        StartCoroutine(SpawnCluesCoroutine());
    }

    private IEnumerator SpawnCluesCoroutine()
    {
        var indices = clueBubbles.GetRandomIndices(NUMBER_OF_CLUES);

        clueBubbles[indices[0]].Set(currOrder, ClueScript.ClueType.Glass);
        yield return new WaitForSeconds(timeBetweenCluesAnimation);

        clueBubbles[indices[1]].Set(currOrder, ClueScript.ClueType.Drink);
        yield return new WaitForSeconds(timeBetweenCluesAnimation);
        
        clueBubbles[indices[2]].Set(currOrder, ClueScript.ClueType.Garnish);
        yield return null;
    }

    public void ClearClues()
    {
        foreach (var item in clueBubbles)
        {
            item.Clear();
        }
    }
}
