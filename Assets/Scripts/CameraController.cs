using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Animator CameraAnimator;
    public string CameraUpTriggerName = "CameraUp";
    public string CameraDownTriggerName = "CameraDown";

    public void CameraUp()
    {
        PlayCameraTrigger(CameraUpTriggerName);
    }

    public void CameraDown()
    {
        PlayCameraTrigger(CameraDownTriggerName);
    }

    public void PlayCameraTrigger(string triggerName)
    {
        if (CameraAnimator == null)
        {
            return;
        }

        CameraAnimator.SetTrigger(triggerName);
    }
}
