using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI trackerText;
    public Slider timerSlider;

    public void HideUI()
    {
        trackerText.gameObject.SetActive(false);
        timerSlider.gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        // feedbackText.gameObject.SetActive(true);
    }

}
