using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    float maxVolume_;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        maxVolume_ = audioSource.volume;
        PlayNextTrack();
        Debug.Log("Volume = " + audioSource.volume);
    }

    private void Update()
    {
        if(audioSource != null){


              audioSource.volume = Mathf.Lerp(0.0f, maxVolume_,GameSceneLink.instance.backgroundMusicVolume_);
            
            if (!audioSource.isPlaying)
            {
                PlayNextTrack();
            }
        }
    }

    private void PlayNextTrack()
    {
        // Selecciona aleatoriamente un indice de pista de musica
        int randomIndex = Random.Range(0, musicTracks.Length);

        // Asegurate de que la proxima pista no sea la misma que la pista actual
        while (randomIndex == currentTrackIndex)
        {
            randomIndex = Random.Range(0, musicTracks.Length);
        }

        // Actualiza el indice de pista actual
        currentTrackIndex = randomIndex;

        // Cambia la pista de audio y reproduce
        audioSource.clip = musicTracks[currentTrackIndex];

        //Ajusta el volumen seg�n el valor del slider del men� settings

        audioSource.Play();
    }
}
