using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMusicController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource_;
    float maxVolume;
    // Start is called before the first frame update
    void Start()
    {
        audioSource_  = GetComponent<AudioSource>();
        maxVolume = audioSource_.volume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource_.volume = Mathf.Lerp(0.0f, maxVolume,GameSceneLink.instance.weaponMusicVolume_);
    }
}
