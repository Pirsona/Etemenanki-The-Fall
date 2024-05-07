using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterMusic : MonoBehaviour
{
    public Slider SoundSlider;
    public Slider MusicSlider;

    public GameSettings GameSettings;

    public void SaveSettings()
    {
        GameSettings.SetSoundVolume(SoundSlider.value);
        GameSettings.SetMusicVolume(MusicSlider.value);
    }

    public void SetMusicForSettings()
    {
        SoundSlider.value = GameSettings.SoundVolume;
        MusicSlider.value = GameSettings.MusicVolume;
    }
}
