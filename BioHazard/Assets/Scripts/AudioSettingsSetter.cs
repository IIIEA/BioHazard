using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioSettingsSetter : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    public UnityEvent<float> OnSetSound;
    public UnityEvent<float> OnSetMusic;

    private void Start()
    {
        float sound;
        float music;

        _mixer.GetFloat(Constants.Sound, out sound);
        _mixer.GetFloat(Constants.Music, out music);

        OnSetSound.Invoke(sound);
        OnSetMusic.Invoke(music);
    }

    public void SetSound(float value)
    {
        _mixer.SetFloat(Constants.Sound, value);
    }

    public void SetMusic(float value)
    {
        _mixer.SetFloat(Constants.Music, value);
    }
}