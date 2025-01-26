using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CluesSpawner : MonoBehaviour
{
    public List<ClueScript> clueBubbles;

    public float timeBetweenCluesAnimation = .2f;

    private int NUMBER_OF_CLUES = 3;

    private BarOrder currOrder;

    public bool showingBubbles = false;
    public Action OnCluesCompleted = null;

    void Update()
    {
        if (!showingBubbles)
        {
            return;
        }
        
        foreach (var bubble in clueBubbles)
        {
            if (bubble.isShown)
            {
                return;
            }
        }

        showingBubbles = false;
        OnCluesCompleted?.Invoke();
    }

    public void SpawnClues(BarOrder order)
    {        
        showingBubbles = true;
        
        currOrder = order;
        StartCoroutine(SpawnCluesCoroutine());
    }

    private IEnumerator SpawnCluesCoroutine()
    {
        var indices = clueBubbles.GetRandomIndices(NUMBER_OF_CLUES);

        clueBubbles[indices[0]].isShown = true;
        clueBubbles[indices[1]].isShown = true;
        clueBubbles[indices[2]].isShown = true;

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
