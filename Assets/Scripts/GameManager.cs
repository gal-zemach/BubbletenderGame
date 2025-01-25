using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Clients")]
    public GameObject ClientPrefab;
    public Transform ClientsParent;

    [Space]
    public BarClientScript CurrentClient;

    [Header("Clues")]
    public CluesSpawner cluesSpawner;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (CurrentClient == null && Input.GetKeyDown(KeyCode.N))
        {
            CurrentClient = CreateNewClient();
            CurrentClient.Init();
            
            cluesSpawner.SpawnClues(CurrentClient.order);
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            cluesSpawner.ClearClues();

            CurrentClient.Hide();
            CurrentClient = null;
        }

        // if (CurrentOrder)
        // {
        //     if (CurrentClient.ServeOrder(CurrentClient))


        //     CurrentClient.Hide();
        //     CurrentClient = null;
        // }
    }

    private BarClientScript CreateNewClient()
    {
        var newClientGo = GameObject.Instantiate<GameObject>(ClientPrefab, ClientsParent);
        return newClientGo.GetComponent<BarClientScript>();
    }
}
