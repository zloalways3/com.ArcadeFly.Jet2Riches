using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenesLoader : MonoBehaviour
{
    public void LoadBootScreen()
    {
        LoadScene(GameConstants.LoadingSceneTitle);
    }

    public void LoadGameScene()
    {
        LoadScene(GameConstants.MainGameScene);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
        
}