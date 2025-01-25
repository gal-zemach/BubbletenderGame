using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject uiPanel;
    public TextMeshProUGUI feedbackText;
    public Slider timerSlider;

    public void HideUI()
    {
        uiPanel.SetActive(false);
        feedbackText.gameObject.SetActive(false);
        timerSlider.gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        uiPanel.SetActive(true);
    }

}
