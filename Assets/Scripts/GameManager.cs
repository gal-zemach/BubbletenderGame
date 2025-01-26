using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Clients")]
    // public BarClientScript ClientPrefab;
    public Transform ClientsParent;

    [Space]
    public BarClientScript CurrentClient;

    [Header("Clues")]
    public CluesSpawner cluesSpawner;

    [Header("Bubbles")]
    public BubbleSpawner bubblesSpawner;

    void Start()
    {
            
    }
    
    void Update()
    {
        if (!CurrentClient.HasEnteredBar && Input.GetKeyDown(KeyCode.N))
        {
            Action<BarOrder> onEnteredBar = (order) => cluesSpawner.SpawnClues(order);
            
            CurrentClient.EnterBar(onEnteredBar);
        }
        
        if (CurrentClient.HasEnteredBar && Input.GetKeyDown(KeyCode.M))
        {
            cluesSpawner.ClearClues();
            CurrentClient.LeaveBar();
        }
    }
}
