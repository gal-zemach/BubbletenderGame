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
    public MiniGameScript washingGameScript;
    public BubbleSpawner bubbleSpawner;
    
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
        
        CurrentClient.OnClientIsDoneWaiting += ClientLeaves;
        CurrentClient.OnClientLeft += InsertNewClient;
        InsertNewClient();
    }

    public void InsertNewClient()
    {
        Action<BarOrder> onEnteredBar = (order) => cluesSpawner.SpawnClues(order);
        Action onLeftBar = () => cluesSpawner.ClearClues();
            
        CurrentClient.EnterBar(onEnteredBar, onLeftBar);
    }

    public void ClientLeaves()
    {
        CurrentClient.LeaveBar();
    }
    
    void OnDestroy()
    {
        CurrentClient.OnClientLeft -= InsertNewClient;
    }

    public void MoveToBar()
    {
        if (gameState == GameState.Bar)
        {
            return;
        }

        if (washingGameScript.IsWashingSequanceActive)
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

    public void SpawnBubble()
    {
        bubbleSpawner.SpawnBubble();
    }
}
