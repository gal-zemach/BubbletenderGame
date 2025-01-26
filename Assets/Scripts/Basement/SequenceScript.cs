using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;

public class SequenceScript : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI trackerText;
    public MiniGameScript gameScript; 
    public TimerScript timerScript;
    public IconScript iconScript;
    public Sprite correctSprite;
    public Sprite incorrectSprite;
    private float cycleDelay = 0.2f;

    // Difficulty Variables
    public int successTarget = 3;   
    public int seqLength = 3; 
    public int playerLevel = 1;
    public int maxLevel = 10;

    // Private Variables
    // private List<string> directions = new List<string> { "W", "A", "S", "D", "U", "Q", "L", "R" };
    private List<string> directions = new List<string> {"U", "Q", "L", "R" };

    private List<string> correctSequence;
    private int currentIndex = 0;
    private int successCount = 0;
    public bool sequenceActive = false;

    private Action bubbleSpawningAction = null;

    public void Init(Action bubbleSpawningAction)
    {
        this.bubbleSpawningAction = bubbleSpawningAction;
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
        if (timerScript.overTime == true)
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
            string randomDirection = directions[UnityEngine.Random.Range(0, directions.Count)];
            sequence.Add(randomDirection);
        }

        return sequence;
    }

    // Gather Player Input
    string GetKeyPressed()
    {
        // if (Input.GetKeyDown(KeyCode.W)) return "W";
        // if (Input.GetKeyDown(KeyCode.A)) return "A";
        // if (Input.GetKeyDown(KeyCode.S)) return "S";
        // if (Input.GetKeyDown(KeyCode.D)) return "D";
        if (Input.GetKeyDown(KeyCode.UpArrow)) return "U";
        if (Input.GetKeyDown(KeyCode.DownArrow)) return "Q";
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return "L";
        if (Input.GetKeyDown(KeyCode.RightArrow)) return "R";

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
                    // Change to correct Sprite
                    currentSpriteRenderer.sprite = correctSprite;
                }

                currentIndex++;
            }
            
            else
            {
                SpriteRenderer currentSpriteRenderer = iconScript.spawnedIcons[currentIndex].GetComponent<SpriteRenderer>();
                if (currentSpriteRenderer != null)
                {
                    // Change to incorrect Sprite
                    currentSpriteRenderer.sprite = incorrectSprite;
                }

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
                bubbleSpawningAction?.Invoke();
                
                // Adjust Variables for the Level
                if (playerLevel < maxLevel)
                {
                    playerLevel++;
                }

                if (playerLevel == 2 || playerLevel == 4 || playerLevel == 6 || playerLevel == 8)
                {
                    seqLength++;
                }

                if (playerLevel == 3 || playerLevel == 5 || playerLevel == 7 || playerLevel == 9)
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
        
        // Start a coroutine to delay the next sequence
        StartCoroutine(DelayedRunSequence(cycleDelay));  // 1f is the delay in seconds
    }

    private IEnumerator DelayedRunSequence(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // After the delay, run the sequence
        RunSequence();
    }

    private void EndSequence()
    {
        StartCoroutine(DelayedLoop(cycleDelay));
    }

    private IEnumerator DelayedLoop(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // After the delay, run the sequence
        currentIndex = 0;
        successCount = 0;
        iconScript.DestroyExistingSprites();
        sequenceActive = false;
        gameScript.OnSequenceCompleted(true);
    }

}
