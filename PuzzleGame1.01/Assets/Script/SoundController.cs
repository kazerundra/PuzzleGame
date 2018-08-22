using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour {

    public AudioClip bgm;
    public AudioClip coinDrop;
    public AudioClip coinSet;
    public AudioSource audiosc;

    public bool soundOn;


    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void Start () {
        audiosc = GetComponent<AudioSource>();
        
        audiosc.clip = bgm;
        audiosc.Play();
        soundOn = true;
        
		
	}
    public void PlayCoinset()
    {
        audiosc.PlayOneShot(coinSet);
    }	
    public void StopAudio()
    {
        if (soundOn)
        {
            audiosc.Stop();
            soundOn = false;
        }
        else
        {
            audiosc.Play();
            soundOn = true;
        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
