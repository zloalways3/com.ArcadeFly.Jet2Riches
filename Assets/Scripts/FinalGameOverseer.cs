using UnityEngine;

public class FinalGameOverseer : MonoBehaviour
{
    public void QuitApplication()
    {
        if (IsEditorMode())
        {
            StopEditorPlayMode();
        }
        else
        {
            CloseApplication();
        }
    }

    private bool IsEditorMode()
    {
#if UNITY_EDITOR
        return true;
#else
            return false;
#endif
    }

    private void StopEditorPlayMode()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void CloseApplication()
    {
        Application.Quit();
    }
}