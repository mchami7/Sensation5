using System;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public AudioMixer mainMixer;
    public AudioMixerGroup sfxGroup;
    public AudioMixerGroup musicGroup;

    public Sound[] music;
    public Sound[] sfx;

    private void OnEnable()
    {
        PlayerSoundPreference.changeMusicVol += ChangeMusicVolume;
        PlayerSoundPreference.changeSFXVol += ChangeSoundVolume;
    }

    private void OnDisable()
    {
        PlayerSoundPreference.changeMusicVol -= ChangeMusicVolume;
        PlayerSoundPreference.changeSFXVol -= ChangeSoundVolume;

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound m in sfx)
            m.audioSource = gameObject.GetComponent<AudioSource>();

        foreach (Sound m in music)
        {
            m.audioSource = gameObject.AddComponent<AudioSource>();
            m.audioSource.clip = m.soundClip;
            m.audioSource.outputAudioMixerGroup = m.musicMixerGroup;

            m.audioSource.volume = m.volume;
            m.audioSource.loop = m.loop;
            m.audioSource.pitch = m.pitch;
        }

    }

    private void Start()
    {
        ChangeSoundVolume(PlayerSoundPreference.GetSoundVolumeLevelPreference());
        ChangeMusicVolume(PlayerSoundPreference.GetMusicVolumeLevelPreference());

        Play("MainMenu");
    }

    
    public void ChangeSoundVolume(float volume)
    {
        sfxGroup.audioMixer.SetFloat("sfxVol", volume);
    }

    public void ChangeMusicVolume(float volume)
    {
        musicGroup.audioMixer.SetFloat("musicVol", volume);
    }
    
    public void Play(string name)
    {
        Sound s = Array.Find(music, sound => sound.soundName == name);

        foreach (Sound m in music)
            m.audioSource.Stop();

        if (s != null)
            s.audioSource.Play();

        s.audioSource.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(music, sound => sound.soundName == name);

        if (s != null)
            s.audioSource.Stop();
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.soundName == name);
        s.audioSource.volume = s.volume;
        s.audioSource.pitch = s.pitch;
        s.audioSource.PlayOneShot(s.soundClip);
    }

    public void StopAllMusic()
    {
        foreach (Sound m in music)
            m.audioSource.Stop();
    }

    private AudioSource GetAudioSource(string name)
    {
        Sound s = Array.Find(music, sound => sound.soundName == name);
        return s.audioSource;
    }
}
