using UnityEngine;
using UnityEngine.Audio;

public class SoundEngineDirector : MonoBehaviour
{
    [SerializeField] private AudioMixer mainAudioMixer;

    private void AdjustVolume(string parameterName, float volume)
    {
        mainAudioMixer.SetFloat(parameterName, volume);
    }

    public void ChangeMusicVolume(float volume)
    {
        AdjustVolume(GameConstants.MusicVolumeParameterName, volume);
    }

    public void ChangeSoundVolume(float volume)
    {
        AdjustVolume(GameConstants.SoundVolumeParameterName, volume);
    }
}