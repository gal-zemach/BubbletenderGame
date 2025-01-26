using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Bar, Basement
    }
    
    [Header("Components")]
    public CameraController cameraController;
    
    [Header("Clients")]
    public Transform ClientsParent;

    [Space]
    public BarClientScript CurrentClient;

    [Header("Clues")]
    public CluesSpawner cluesSpawner;

    [Header("Bubbles")]
    public BubbleSpawner bubblesSpawner;

    [Space]
    public GameState gameState;

    void Start()
    {
        gameState = GameState.Bar;
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

    public void MoveToBar()
    {
        if (gameState == GameState.Bar)
        {
            return;
        }

        cameraController.CameraUp();
        gameState = GameState.Bar;
    }

    public void MoveToBasement()
    {
        if (gameState == GameState.Basement)
        {
            return;
        }
        
        cameraController.CameraDown();
        gameState = GameState.Basement;
    }
}
