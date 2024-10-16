using UnityEngine;

public class GameControllerSceneManagers : MonoBehaviour
{
    private int _levelscCurrentNumber;
        
    private void Start()
    {
        _levelscCurrentNumber = PlayerPrefs.GetInt("OngoingStage", 0);
    }

    public void OnScaleTimeOn()
    {
        Time.timeScale = 1f;
    }
        
    public void OnScaleTimeOff()
    {
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        PlayerPrefs.SetInt("OngoingStage", _levelscCurrentNumber+1);
        PlayerPrefs.Save();
        StageController stageController = FindObjectOfType<StageController>();
        stageController.CompleteStage(_levelscCurrentNumber);
    }
}