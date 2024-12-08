using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Slider soundEffectsSlider;
    [SerializeField] private Slider masterVolumeSlider;

    private Resolution[] resolutions;

    private void Start()
    {
        // Initialize resolution dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        foreach (Resolution res in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(res.width + " x " + res.height));
        }

        resolutionDropdown.value = resolutions.Length - 1;
        resolutionDropdown.RefreshShownValue();

        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        soundEffectsSlider.value = PlayerPrefs.GetFloat("SoundEffectsVolume", 1f);
        fullscreenToggle.isOn = Screen.fullScreen;
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", resolutions.Length - 1);
    }

    public void OpenOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }

    public void SetSoundEffectsVolume(float volume)
    {
        FindObjectOfType<AudioSettings>().SetSoundEffectsVolume(volume);
        PlayerPrefs.SetFloat("SoundEffectsVolume", volume);
    }
}
