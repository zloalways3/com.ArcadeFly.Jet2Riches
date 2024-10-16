using UnityEngine;
using UnityEngine.UI;

public class GameSessionSupervisor : MonoBehaviour
{
    public static GameSessionSupervisor Instance;

    [SerializeField] private int totalLives = 3;
    [SerializeField] private Image[] lifeIcons;
    [SerializeField] private GameObject playerCharacter;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameplayUI;

    private void InitializeInstance()
    {
        Instance = this;
    }

    private void ReduceLifeCount()
    {
        totalLives--;
        lifeIcons[totalLives].enabled = false;
    }

    private bool IsGameOver()
    {
        return totalLives <= 0;
    }

    public void LoseLife()
    {
        ReduceLifeCount();

        if (IsGameOver())
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        DisablePlayerControl();
        ShowGameOverUI();
        PauseGame();
    }

    private void DisablePlayerControl()
    {
        playerCharacter.GetComponent<CharacterMover>().enabled = false;
    }

    private void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
        gameplayUI.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void Awake()
    {
        InitializeInstance();
    }
}