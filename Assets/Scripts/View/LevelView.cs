using Other;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Button[] _levelOptions;
    [SerializeField] private Sprite _closedSprite;
    [SerializeField] private Sprite _openSprite;

    private StageNavigator _stageNavigator;

    private void Start()
    {
        _stageNavigator = FindObjectOfType<StageNavigator>();
        _stageNavigator.InitializeLevels();
        LevelPalette();
    }

    private void LevelPalette()
    {
        for (var i = 0; i < ConstVault.TOTAL_LEVELS; i++)
        {
            if (i == 0 || _stageNavigator.IsLevelUnlocked(i))
            {
                _levelOptions[i].GetComponent<Image>().sprite = _openSprite;
                var levelIndex = i;
                _levelOptions[i].onClick.AddListener(() => _stageNavigator.StageElevator(levelIndex));
            }
            else
            {
                Destroy(_levelOptions[i].GetComponent<Button>());
                _levelOptions[i].GetComponent<Image>().sprite = _closedSprite;
            }
        }
    }
}