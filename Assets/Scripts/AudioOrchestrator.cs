using Other;
using UnityEngine;
using UnityEngine.Audio;

public class AudioOrchestrator : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioBlender;

    public void SoundscapeTuner(float volume)
    {
        _audioBlender.SetFloat(ConstVault.SOUND_IDENTIFIER, volume);
    }

    public void MelodyMixer(float volume)
    {
        _audioBlender.SetFloat(ConstVault.TRACK_TITLE, volume);
    }
}