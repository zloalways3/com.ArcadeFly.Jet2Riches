using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private Slider timerSlider;
    [SerializeField] private GameObject completionUI;
    [SerializeField] private GameObject gameplayUI;

    private float remainingTime = 60f;
    private bool isTimerActive = false;

    private void InitializeTimer()
    {
        timerSlider.maxValue = remainingTime;
        timerSlider.value = remainingTime;
        isTimerActive = true;
        Time.timeScale = 1f;
    }

    private void UpdateTimer()
    {
        if (!isTimerActive) return;

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerSlider.value = remainingTime;
        }
        else
        {
            remainingTime = 0;
            EndTimer();
        }
    }

    private void EndTimer()
    {
        isTimerActive = false;
        completionUI.SetActive(true);
        gameplayUI.SetActive(false);
        Time.timeScale = 0f;
    }

    private void Start()
    {
        InitializeTimer();
    }

    private void Update()
    {
        UpdateTimer();
    }
}