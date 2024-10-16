using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void BeginLoading()
    {
        StartCoroutine(LoadSceneAsync(GameConstants.MainMenuSceneTitle));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        var sceneLoading = SceneManager.LoadSceneAsync(sceneName);
        sceneLoading.allowSceneActivation = false;

        yield return MonitorLoadingProgress(sceneLoading);
    }

    private IEnumerator MonitorLoadingProgress(AsyncOperation sceneLoading)
    {
        while (!sceneLoading.isDone)
        {
            if (sceneLoading.progress >= 0.9f)
            {
                sceneLoading.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    private void Start()
    {
        BeginLoading();
    }
}