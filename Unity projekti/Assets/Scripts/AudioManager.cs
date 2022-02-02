using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Manager that handles all audio output logically
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    [Header("Mixer")]
    [SerializeField] private AudioMixer Mixer;  // Audio Mixer that is in use

    // Music system should be reworked a bit.
    // For example, creating a "MusicEffect" class. Currently uses the SoundEffect class
    [Header("Music")]
    [SerializeField] private SoundEffect StartingMusic;     // Music sound effect
    [SerializeField] private AudioSource MusicAS;   // Music AudioSource reference

    private AudioSource AS;                        // AudioManager Audiosource that is used to play SoundEffects

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMusicTrack(StartingMusic); // at start play the Starting Music
    }

    /// <summary>
    /// Change an Audio Mixers group volume. Groups: Master, SoundEffect and Music 
    /// </summary>
    /// <param name="group"></param>
    /// <param name="volume"></param>
    public void ChangeMixerGroupVolume(string group, float volume)
    {
        Mixer.SetFloat(group, volume);
    }

    /// <summary>
    /// Toistaa jonkin ääni effektin vain kerran annetulla SoundEffect datalla, ja datan äänenvoimakkuus lisätään audiosourceen
    /// </summary>
    /// <param name="effect"></param>
    public void PlayClipOnce(SoundEffect effect)
    {
        AS.outputAudioMixerGroup = effect.Mixer;
        AS.PlayOneShot(effect.GetClip(), effect.volume);
    }

    /// <summary>
    /// Toistaa jonkin ääni effektin vain kerran annetulla SoundEffect datalla, annetun GameObjektin AudioSourcesta
    /// </summary>
    /// <param name="effect"></param>
    /// <param name="source"></param>
    public void PlayClipOnce(SoundEffect effect, GameObject source)
    {
        // Hae source -GameObjectista "AudioSource"
        AudioSource SourceAS = source.GetComponent<AudioSource>();

        SourceAS.outputAudioMixerGroup = effect.Mixer;

        // Mikäli AudioSource komponenttia ei ole olemassa "source" objektissa, luo AudioSource komponentti sille
        if (SourceAS == null)
            SourceAS = source.AddComponent<AudioSource>();

        // Aseta GameObjektin AudioSourcelle spatialBlend samaan, mitä "effect":tiin on asetettu
        SourceAS.spatialBlend = effect.spatialBlend;

        // Toista ääni effekti source - GameObjektin AudioSource komponentista
        SourceAS.PlayOneShot(effect.GetClip(), effect.volume);
    }

    /// <summary>
    /// Plays the given music track 
    /// </summary>
    /// <param name="track"></param>
    public void PlayMusicTrack(SoundEffect track)
    {
        MusicAS.outputAudioMixerGroup = track.Mixer;
        MusicAS.clip = track.GetClip();
        MusicAS.volume = track.volume;
        MusicAS.loop = true;
        MusicAS.Play();
    }
}
