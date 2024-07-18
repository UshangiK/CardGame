using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Events.FlippedCardEvent += OnFlippedEvent;  
        Events.MissedEvent += OnMissedEvent;
        Events.ScoredEvent += OnScoredEvent;  
        Events.WinEvent += OnWinEvent;  
    }

    private void OnFlippedEvent()
    {
        _audioSource.clip = sounds[0];
        _audioSource.Play();
    }
    
    private void OnMissedEvent()
    {
        _audioSource.clip = sounds[1];
        _audioSource.Play();
    }
    
    private void OnScoredEvent(int score)
    {
        _audioSource.clip = sounds[2];
        _audioSource.Play();
    }
    
    private void OnWinEvent()
    {
        _audioSource.clip = sounds[3];
        _audioSource.Play();
    }
}
