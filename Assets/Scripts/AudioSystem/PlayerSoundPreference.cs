using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSoundPreference : MonoBehaviour
{    //This script is responsbile for saving and loading player sound preferences

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    public static Action<float> changeMusicVol;
    public static Action<float> changeSFXVol;

    private void Start()
    {
        musicSlider.value = GetMusicVolumeLevelPreference();
        sfxSlider.value = GetSoundVolumeLevelPreference();
    }

    public static void SoundVolumeLevelPreference(float sVol)
    {
        PlayerPrefs.SetFloat("sVol", sVol);
        changeSFXVol?.Invoke(sVol);
    }

    public static void MusicVolumeLevelPreference(float mVol)
    {
        PlayerPrefs.SetFloat("mVol", mVol);
        changeMusicVol?.Invoke(mVol);
    }

    public static float GetSoundVolumeLevelPreference()
    {
        return PlayerPrefs.GetFloat("sVol", 0.8f);
    }

    public static float GetMusicVolumeLevelPreference()
    {
        return PlayerPrefs.GetFloat("mVol", 0.75f);
    }
}

