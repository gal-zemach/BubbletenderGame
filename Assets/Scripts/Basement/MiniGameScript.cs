using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameScript : MonoBehaviour
{
    public GameManager gameManager;
    
    public IconScript iconScript;

    public SequenceScript sequenceScript;
    public TimerScript timerScript;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI trackerText;
    public TextMeshProUGUI levelText;
    public Slider timerSlider;

    public bool IsWashingSequanceActive => sequenceScript.sequenceActive;

    void Start()
    {
        // Hide Tracker + Timer on Entry
        trackerText.gameObject.SetActive(false);
        timerSlider.gameObject.SetActive(false);
 
        // Hide Instructional Text (For Game Jam: Ugly Text)
        feedbackText.text = "Press Space to Start";
        feedbackText.gameObject.SetActive(false);
        levelText.text = "Level: " + sequenceScript.playerLevel.ToString();
        levelText.gameObject.SetActive(false);

        sequenceScript.Init(() => gameManager?.SpawnBubble());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState != GameManager.GameState.Basement)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartWashGame();
        }
    }

    void StartWashGame()
    {
        // Hide Instructional Text
        feedbackText.gameObject.SetActive(false);
        levelText.gameObject.SetActive(false);

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
        
        // Hide Feedback UI (For Game Jam: Ugly Font)
        feedbackText.gameObject.SetActive(false);
        levelText.text = "Level: " + sequenceScript.playerLevel.ToString();
        levelText.gameObject.SetActive(false);  
    }
}
