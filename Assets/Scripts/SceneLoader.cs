using System.Collections;
using Other;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private LoadingScreen _loadingScreen;

    private float _timerForDots;
    private int _currentDotCount; 
    private const float _dotDisplayInterval = 0.5f;

    private void Start()
    {
        StartCoroutine(LoadTargetScene(ConstVault.MAIN_SCENE));
    }

    private IEnumerator LoadTargetScene(string sceneName)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            UpdateLoadingIndicator();
            _loadingScreen.UpdateProgress(asyncLoad.progress);

            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    private void UpdateLoadingIndicator()
    {
        _timerForDots += Time.deltaTime;

        if (_timerForDots < _dotDisplayInterval) return;
        _currentDotCount = (_currentDotCount + 1) % 4;
        var dotString = new string('.', _currentDotCount);
        _loadingScreen.UpdateStatusText("Loading" + dotString);
        _timerForDots = 0f;
    }
}