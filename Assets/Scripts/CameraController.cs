using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Animator CameraAnimator;
    public string CameraUpTriggerName = "CameraUp";
    public string CameraDownTriggerName = "CameraDown";

    private bool isCameraUp = true;
    public bool CameraOnBar => isCameraUp;
    public bool CameraOnBasement => !isCameraUp;

    public void CameraUp()
    {
        PlayCameraTrigger(CameraUpTriggerName);
        isCameraUp = true;
    }

    public void CameraDown()
    {
        PlayCameraTrigger(CameraDownTriggerName);
        isCameraUp = false;
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
