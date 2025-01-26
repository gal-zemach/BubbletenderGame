using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SequenceScript : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI trackerText;
    public MiniGameScript gameScript; 
    public TimerScript timerScript;
    public IconScript iconScript;

    // Variables
    public int successTarget = 3;   
    public int seqLength = 3; 
    public int playerLevel = 1;
    private List<string> directions = new List<string> { "W", "A", "S", "D" };

    private List<string> correctSequence;
    private int currentIndex = 0;
    private int successCount = 0;
    private bool sequenceActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sequenceActive)
        {
            // Check for player input
            if (Input.anyKeyDown)
            {
                Debug.Log("Key Selected");

                string input = GetKeyPressed();

                if (input != null)
                {
                    CheckSequence(input);
                }
            }
        }
        
        // End the sequence if the timer runs out
        if (timerScript.timerRunning == false)
        {
            EndSequence();
        }
    }
    // Display the Sequence
    public void RunSequence()
    {
        // Generate a Sequence Based on Target
        correctSequence = GenerateRandomSequence(seqLength);

        // Create the Sprites
        iconScript.CreateIcons(correctSequence);

        // Start the Script
        sequenceActive = true;
        trackerText.text = successCount.ToString() + "/" + successTarget.ToString();
    }

    private List<string> GenerateRandomSequence(int length)
    {
        List<string> sequence = new List<string>();

        for (int i = 0; i < length; i++)
        {
            // Randomly pick a direction from the list
            string randomDirection = directions[Random.Range(0, directions.Count)];
            sequence.Add(randomDirection);
        }

        return sequence;
    }

    // Gather Player Input
    string GetKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.W)) return "W";
        if (Input.GetKeyDown(KeyCode.A)) return "A";
        if (Input.GetKeyDown(KeyCode.S)) return "S";
        if (Input.GetKeyDown(KeyCode.D)) return "D";

        return null;
    }

    // Check the Sequence
    void CheckSequence(string input)
    {    
        // Compare Player Input to the Desired Sequence
        if (currentIndex < correctSequence.Count)
        {
            Debug.Log(correctSequence[currentIndex]);
            
            if (input == correctSequence[currentIndex].ToString())
            {
                Debug.Log("Correct Input");

                SpriteRenderer currentSpriteRenderer = iconScript.spawnedIcons[currentIndex].GetComponent<SpriteRenderer>();
                if (currentSpriteRenderer != null)
                {
                    // Change the color to green or any color you prefer
                    currentSpriteRenderer.color = Color.green;
                }

                currentIndex++;
            }
            
            else
            {
                ResetLoop();
            }
        }

        if (currentIndex == correctSequence.Count)
        {

           successCount++;

            // Change the Feedback Text
            trackerText.text = successCount.ToString() + "/" + successTarget.ToString();

            // If the target number of successes has been completed, exit game
            if (successCount == successTarget)
            {
                // feedbackText.text = "All Sequences Complete! Press Space to Start Again.";
                playerLevel++;
                seqLength++;

                if (playerLevel == 3 || playerLevel == 6 || playerLevel == 9)
                {
                    successTarget++;
                }

                EndSequence();
            }

            // Otherwise, restart the loop
            else
            {
                ResetLoop();
            }
        }
    }

    private void ResetLoop()
    {
        // Reset Counters
        currentIndex = 0;
        
        // ReRun Sequence
        RunSequence();
    }

    private void EndSequence()
    {
        currentIndex = 0;
        successCount = 0;
        iconScript.DestroyExistingSprites();
        sequenceActive = false;
        gameScript.OnSequenceCompleted(true);
    }

}
