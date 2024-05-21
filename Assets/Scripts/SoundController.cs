using UnityEngine;
using UnityEngine.UI;

public class SoundSliderController : MonoBehaviour
{
  public Slider masterSoundSlider_;
  public Slider weaponSoundSlider_;

    void Start()
    {
        masterSoundSlider_.value = GameSceneLink.instance.backgroundMusicVolume_;
        weaponSoundSlider_.value = GameSceneLink.instance.weaponMusicVolume_;

        // Asigna la funci�n OnSoundSliderChanged() al evento OnValueChanged del slider
        masterSoundSlider_.onValueChanged.AddListener(delegate { OnSoundSliderChanged(); });
        weaponSoundSlider_.onValueChanged.AddListener(delegate { OnSoundSliderChanged(); });

        // Establece el valor inicial del slider al volumen actual del audio
        // masterSoundSlider_.value = audioSource_.volume;
    }

    void OnSoundSliderChanged()
    {
        // Ajusta el volumen del audio seg�n el valor del slider
        GameSceneLink.instance.backgroundMusicVolume_ = masterSoundSlider_.value;
        GameSceneLink.instance.weaponMusicVolume_ = weaponSoundSlider_.value;
    }
}
