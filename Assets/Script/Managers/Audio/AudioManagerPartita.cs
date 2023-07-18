using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerPartita : AudioManager
{
    [SerializeField] AudioMixerGroup audioMixerGroup;
    AudioSource towerSource; 
    [SerializeField] AudioClip towerDisappear;  //sparizione torre dal campo (dopo ralph)
 
    protected override void Awake() 
    {
        base.Awake();
        towerSource = gameObject.AddComponent<AudioSource>();
        towerSource.outputAudioMixerGroup = audioMixerGroup;
        towerSource.clip = towerDisappear;
    } 
 
    protected override void Start() 
    {
        base.Start();
    }
 
    public override void PlayTowerDisappear() 
    { 
        towerSource.Play(); 
    }
}
