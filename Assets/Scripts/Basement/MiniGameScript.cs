using UnityEngine;
using System.Collections.Generic;

public class MiniGameScript : MonoBehaviour
{
    public IconScript iconScript;
    public UIScript uiScript;
    public SequenceScript sequenceScript;
    public TimerScript timerScript;
    private bool gameActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // When the scene starts, the UI is hidden
        uiScript.HideUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartWashGame();
        }
    }

    void StartWashGame()
    {
        gameActive = true;
        uiScript.ShowUI();
        timerScript.StartTimer();
        // sequenceScript.RunSequence();  
    }

    public void OnSequenceCompleted (bool success)
    {
        gameActive = false;
        uiScript.HideUI();
        timerScript.StopTimer();
    }
}
