using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public static StageController Instance;

    [SerializeField] private Button[] stageButtons;
    private const int TotalStages = 30;

    private void InitializeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        InitializeSingleton();
        SetupLevels();
        RefreshStageButtons();
    }

    public void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        ReloadLoadingScene();
    }

    private void ReloadLoadingScene()
    {
        SceneManager.LoadScene(GameConstants.LoadingSceneTitle);
    }

    public void PlaySelectedLevel()
    {
        SceneManager.LoadScene(GameConstants.AlternateGameScene);
    }

    private void SetupLevels()
    {
        for (int i = 0; i < TotalStages; i++)
        {
            string levelKey = $"GameStage{i}";
            if (!PlayerPrefs.HasKey(levelKey))
            {
                int levelState = i == 0 ? 1 : 0;
                PlayerPrefs.SetInt(levelKey, levelState);
            }
        }
        PlayerPrefs.Save();
    }

    public void CompleteStage(int stageIndex)
    {
        PlayerPrefs.SetInt($"GameStage{stageIndex}", 1);
        PlayerPrefs.Save();
    }

    private void RefreshStageButtons()
    {
        for (int i = 0; i < TotalStages; i++)
        {
            bool stageUnlocked = i == 0 || PlayerPrefs.GetInt($"GameStage{i}", 0) == 1;
            UpdateStageButton(stageButtons[i], stageUnlocked);
        }
    }

    private void UpdateStageButton(Button button, bool isUnlocked)
    {
        button.interactable = isUnlocked;
        button.image.color = isUnlocked ? Color.white : new Color(1, 1, 1, 0.78f);
    }

    public void LoadStage(int stageIndex)
    {
        PlayerPrefs.SetInt("OngoingStage", stageIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(GameConstants.MainGameScene);
    }
}
