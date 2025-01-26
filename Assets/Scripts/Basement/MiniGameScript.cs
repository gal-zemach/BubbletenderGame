using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MiniGameScript : MonoBehaviour
{
    public IconScript iconScript;
    public SequenceScript sequenceScript;
    public TimerScript timerScript;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI trackerText;
    public Slider timerSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hide Tracker + Timer on Entry
        trackerText.gameObject.SetActive(false);
        timerSlider.gameObject.SetActive(false);

        // Show Instructional Text
        feedbackText.text = "Press Space to Start";
        feedbackText.gameObject.SetActive(true);
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
        // Hide Instructional Text
        feedbackText.gameObject.SetActive(false);

        // Show Tracker UI
        timerSlider.gameObject.SetActive(true);
        trackerText.gameObject.SetActive(true);

        // Start Mini Game
        timerScript.StartTimer();
        sequenceScript.RunSequence();  
    }

    public void OnSequenceCompleted (bool success)
    {
        // Stop Timer
        timerScript.StopTimer();

        // Hide Tracker UI
        timerSlider.gameObject.SetActive(false);
        trackerText.gameObject.SetActive(false);
        
        // Show Feedback UI
        feedbackText.gameObject.SetActive(true);
       
    }
}
