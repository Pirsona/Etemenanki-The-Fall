using UnityEngine;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    public AudioMixer _mixer;
    public float SoundVolume => _dto.SoundVolume;
    public float MusicVolume => _dto.MusicVolume;

    private const string _settingsPrefsKey = "settings";
    private const float _defaultSoundVolume = 1.0f;
    private const float _defaultMusicVolume = 0.3f;

    private DTO_GameSettings _dto;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_settingsPrefsKey))
        {
            string json = PlayerPrefs.GetString(_settingsPrefsKey);
            _dto = JsonUtility.FromJson<DTO_GameSettings>(json);
        }
        else
        {
            _dto = DefaultDTO();
        }
        Debug.Log($"Sound Volume: {SoundVolume} | Music Volume: {MusicVolume} | Position: {_dto.Position}");
    }

    public void SetSoundVolume(float volume)
    {
        _dto.SoundVolume = volume;
        SaveDTO();
    }

    public void SetMusicVolume(float volume)
    {
        _dto.MusicVolume = volume;
        SaveDTO();
    }

    private void SaveDTO()
    {
        string json = JsonUtility.ToJson(_dto);
        PlayerPrefs.SetString(_settingsPrefsKey, json);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        _dto.Position = transform.position;
        PlayerPrefs.Save();
    }

    private DTO_GameSettings DefaultDTO()
    {
        return new DTO_GameSettings()
        {
            SoundVolume = _defaultSoundVolume,
            MusicVolume = _defaultMusicVolume,
            Position = transform.position
        };
    }
}
