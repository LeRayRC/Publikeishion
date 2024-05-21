using UnityEngine;
using UnityEngine.UI;

public class SoundSliderController : MonoBehaviour
{
  public Slider masterSoundSlider_;
  public Slider bulletSoundSlider_;
  public Slider targetSoundSlider_;
  public AudioSource musicAudioSource_;
  public AudioSource bulletAudioSource_;
  public AudioSource targetAudioSource_;
  public GameObject audioManager_;

    void Start()
    {
        // Asigna la funci�n OnSoundSliderChanged() al evento OnValueChanged del slider
        masterSoundSlider_.onValueChanged.AddListener(delegate { OnSoundSliderChanged(); });
        bulletSoundSlider_.onValueChanged.AddListener(delegate { OnSoundSliderChanged(); });
        targetSoundSlider_.onValueChanged.AddListener(delegate { OnSoundSliderChanged(); });

        // Establece el valor inicial del slider al volumen actual del audio
        mastersoundSlider_.value = audioSource_.volume;
    }

    void OnSoundSliderChanged()
    {
        // Ajusta el volumen del audio seg�n el valor del slider
        musicAudioSource_.volume = masterSoundSlider_.value;
        bulletAudioSource_.volume = bulletSoundSlider_.value;
        targetAudioSource_.volume = targetSoundSlider_.value;
    }
}
