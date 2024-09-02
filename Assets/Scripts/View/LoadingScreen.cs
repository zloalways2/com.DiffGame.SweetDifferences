using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadingMessage;
    [SerializeField] private Slider _loadingSlider;

    public void UpdateStatusText(string text)
    {
        _loadingMessage.text = text;
    }

    public void UpdateProgress(float progress)
    {
        _loadingSlider.value = progress;
    }
}