using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public string volumeParametr = "MasterVolume";
    public AudioMixer audioMixer;
    [SerializeField] private Slider slider;
    private float volumeValue;
    private const float MULTIPLIER = 20f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandlerSliderValueChanged);
    }

    private void Start()
    {
        volumeValue = PlayerPrefs.GetFloat(volumeParametr, Mathf.Log10(slider.value) * MULTIPLIER);
        slider.value = Mathf.Pow(10f, volumeValue / MULTIPLIER);
    }

    private void HandlerSliderValueChanged(float value)
    {
        volumeValue = Mathf.Log10(value) * MULTIPLIER;
        audioMixer.SetFloat(volumeParametr, volumeValue);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParametr, volumeValue);
    }
}
