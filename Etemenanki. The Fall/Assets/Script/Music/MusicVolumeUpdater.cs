using UnityEngine;

public class MusicVolumeUpdater : MonoBehaviour
{
    public GameSettings GameSettings;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _audioSource.volume = GameSettings.MusicVolume;
    }
}
