using UnityEngine;
using UnityEngine.UI;

public class SoundSliderController : MonoBehaviour
{
    public Slider soundSlider_;
    public AudioSource audioSource_;
    public GameObject audioManager_;

    void Start()
    {
        // Asigna la función OnSoundSliderChanged() al evento OnValueChanged del slider
        soundSlider_.onValueChanged.AddListener(delegate { OnSoundSliderChanged(); });

        // Establece el valor inicial del slider al volumen actual del audio
        soundSlider_.value = audioSource_.volume;
    }

    void OnSoundSliderChanged()
    {
        // Ajusta el volumen del audio según el valor del slider
        audioSource_.volume = soundSlider_.value;
    }
}
