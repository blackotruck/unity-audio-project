using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip mainAmbient;
    [SerializeField]
    private AudioSource _AmbientMusic;
    private AudioSource _VariantMusic;
    [SerializeField]
    private AudioMixerGroup _OneLifeLeft;
    public float musicVolume = .5f;

    void Start()
    {
        _AmbientMusic.volume = musicVolume;
        _AmbientMusic.clip = mainAmbient;
        _AmbientMusic.Play();
    }

    public void CrossfadeVariantMusic(AudioSource variantAudioSource)
    {
        Debug.Log("Crofade madafaka");
        _VariantMusic = variantAudioSource;
        _VariantMusic.volume = 0;
        StartCoroutine(CrossFade(_AmbientMusic, _VariantMusic, 2.0f));
    }

    public void CrossfadeAmbientMusic()
    {
        StartCoroutine(CrossFade(_VariantMusic, _AmbientMusic, 2.0f));
    }

    IEnumerator CrossFade(AudioSource currentAudio, AudioSource nextAudio, float seconds)
    {
        float steps = seconds / 20.0f;
        float vol = musicVolume / 20.0f;

        nextAudio.Play();
        for( int i = 0; i < 20; i++)
        {
            currentAudio.volume -= vol;
            nextAudio.volume += vol;

            yield return new WaitForSeconds(steps);
        }

        currentAudio.Stop();
    }

    public void SetOneLifeMixer()
    {
        _AmbientMusic.outputAudioMixerGroup = _OneLifeLeft;
    }

}
