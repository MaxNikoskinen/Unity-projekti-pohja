using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Luokka äänentoistoon

public class AudioManager : Singleton<AudioManager>
{
    [Header("Mixer")]
    [SerializeField] private AudioMixer Mixer;

    [Header("Music")]
    [SerializeField] private SoundEffect StartingMusic;
    [SerializeField] private AudioSource MusicAS;

    private AudioSource AS;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    //Soita aloitus musiikki kun peli käynnistyy
    private void Start()
    {
        PlayMusicTrack(StartingMusic);
    }

    //Vaihda audiomikserin äänenvoimakkuutta
    public void ChangeMixerGroupVolume(string group, float volume)
    {
        Mixer.SetFloat(group, volume);
    }

    // Toistaa jonkin ääni effektin vain kerran annetulla SoundEffect datalla, ja datan äänenvoimakkuus lisätään audiosourceen
    public void PlayClipOnce(SoundEffect effect)
    {
        AS.outputAudioMixerGroup = effect.Mixer;
        AS.PlayOneShot(effect.GetClip(), effect.volume);
    }

    // Toistaa jonkin ääni effektin vain kerran annetulla SoundEffect datalla, annetun GameObjektin AudioSourcesta
    public void PlayClipOnce(SoundEffect effect, GameObject source)
    {
        // Hae source -GameObjectista "AudioSource"
        AudioSource SourceAS = source.GetComponent<AudioSource>();

        // Mikäli AudioSource komponenttia ei ole olemassa "source" objektissa, luo AudioSource komponentti sille
        if (SourceAS == null)
            SourceAS = source.AddComponent<AudioSource>();

        SourceAS.outputAudioMixerGroup = effect.Mixer;

        // Aseta GameObjektin AudioSourcelle spatialBlend samaan, mitä "effect":tiin on asetettu
        SourceAS.spatialBlend = effect.spatialBlend;

        // Toista ääni effekti source - GameObjektin AudioSource komponentista
        SourceAS.PlayOneShot(effect.GetClip(), effect.volume);
    }

    //Metodi joka soittaa musiikkia
    public void PlayMusicTrack(SoundEffect track)
    {
        MusicAS.outputAudioMixerGroup = track.Mixer;
        MusicAS.clip = track.GetClip();
        MusicAS.volume = track.volume;
        MusicAS.loop = true;
        MusicAS.Play();
    }
}
