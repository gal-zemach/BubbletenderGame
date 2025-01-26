using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Slider timerSlider;
    public float timeLimit = 10f;
    public bool timerRunning = false;
    private float currentTime;

    void Update()
    {
        if (timerRunning)
        {
            currentTime -= Time.deltaTime;
            timerSlider.value = currentTime / timeLimit;

            if (currentTime <=0)
            {
                timerRunning = false;
                timerSlider.value = 0;
            }
        }
    }

    public void StartTimer()
    {
        currentTime = timeLimit;
        timerRunning = true;
        timerSlider.value = 1;
        timerSlider.gameObject.SetActive(true);
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

}