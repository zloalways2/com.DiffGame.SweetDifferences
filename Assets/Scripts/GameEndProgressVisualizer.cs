using UnityEngine;
using UnityEngine.UI;

public class GameEndProgressVisualizer : MonoBehaviour
{
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private GameObject _completionIndicator;
    [SerializeField] private GameObject _failureIndicator;
    [SerializeField] private GameObject _targetGameObject;

    public void SetupProgressBar(float maxValue)
    {
        _progressSlider.maxValue = maxValue;
        _progressSlider.value = maxValue;
    }

    public void UpdateProgressBar(float value)
    {
        _progressSlider.value = value;
    }

    public void DisplaySuccessMessage()
    {
        _completionIndicator.SetActive(true);
        _targetGameObject.SetActive(false);
    }

    public void DisplayFailureMessage()
    {
        _failureIndicator.SetActive(true);
        _targetGameObject.SetActive(false);
    }

    public static void GameExitPortal()
    {
        Time.timeScale = 0f;
    }
}