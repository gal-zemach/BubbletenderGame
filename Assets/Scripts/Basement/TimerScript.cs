using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Slider timerSlider;
    public float timeLimit = 10f;
    public bool timerRunning = false;
    public bool overTime = false;
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
                overTime = true;
                timerSlider.value = 0;
            }
        }
    }

    public void StartTimer()
    {
        currentTime = timeLimit;
        timerRunning = true;
        timerSlider.value = 1;
    }

    public void StopTimer()
    {
        timerRunning = false;
        overTime = false;
    }

}