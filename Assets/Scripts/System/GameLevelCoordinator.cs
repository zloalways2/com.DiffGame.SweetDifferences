using Other;
using UnityEngine;

namespace System
{
    public class GameLevelCoordinator : MonoBehaviour
    {
        private TimerHandler _timerHandler;
        private GameEndProgressVisualizer _gameEndProgressVisualizer;
        private PointGuardian _pointGuardian;
        private int _levelIndex;

        private void Start()
        {
            SetupComponents();
            ConfigureTimer();
            Time.timeScale = 1f;
        }

        private void SetupComponents()
        {
            _levelIndex = PlayerPrefs.GetInt("ActiveLevel", 0);
            _timerHandler = gameObject.AddComponent<TimerHandler>();
            _gameEndProgressVisualizer = FindObjectOfType<GameEndProgressVisualizer>();
            _pointGuardian = gameObject.AddComponent<PointGuardian>();
        }

        private void ConfigureTimer()
        {
            if (_gameEndProgressVisualizer != null)
            {
                _gameEndProgressVisualizer.SetupProgressBar(30f);
            }
            _timerHandler.Setup(30f);
        }

        private void Update()
        {
            if (_timerHandler.IsActive)
            {
                RefreshTimer();
            }
        }

        private void RefreshTimer()
        {
            _timerHandler.Tick();
        
            if (_gameEndProgressVisualizer != null)
            {
                _gameEndProgressVisualizer.UpdateProgressBar(_timerHandler.RemainingTime);
            }

            if (_timerHandler.RemainingTime <= 0)
            {
                ProcessTimeOut();
            }
        }

        private void ProcessTimeOut()
        {
            if (_pointGuardian.HasSufficientPoints(_levelIndex * ConstVault.POINT_MULTIPLIER))
            {
                _gameEndProgressVisualizer.DisplaySuccessMessage();
            }
            else
            {
                _gameEndProgressVisualizer.DisplayFailureMessage();
            }

            GameEndProgressVisualizer.GameExitPortal();
        }
    }
}