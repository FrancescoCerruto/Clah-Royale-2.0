using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    protected AudioSource trackSource;    //soundtrack
    [SerializeField] AudioClip soundTrack;
    [SerializeField] AudioMixerGroup soundMixerGroup;


    protected virtual void Awake()
    {
        instance = this;
        trackSource = gameObject.AddComponent<AudioSource>();
        trackSource.loop = true;    //riparte in loop
        trackSource.clip = soundTrack;
        trackSource.outputAudioMixerGroup = soundMixerGroup;
    }

    protected virtual void Start()
    {
        trackSource.Play();
    }

    public virtual void PlayTowerDisappear()
    {}
}
