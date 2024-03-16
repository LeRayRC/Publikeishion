using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextTrack();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    private void PlayNextTrack()
    {
        // Selecciona aleatoriamente un índice de pista de música
        int randomIndex = Random.Range(0, musicTracks.Length);

        // Asegúrate de que la próxima pista no sea la misma que la pista actual
        while (randomIndex == currentTrackIndex)
        {
            randomIndex = Random.Range(0, musicTracks.Length);
        }

        // Actualiza el índice de pista actual
        currentTrackIndex = randomIndex;

        // Cambia la pista de audio y reproduce
        audioSource.clip = musicTracks[currentTrackIndex];
        audioSource.Play();
    }
}
