using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource effectsSource;

    private void Awake()
    {

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.volume = PlayerPrefs.GetFloat("SoundEffectsVolume", 1f);
        effectsSource.PlayOneShot(clip);
    }
}
