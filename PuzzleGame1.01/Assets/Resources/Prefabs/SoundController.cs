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
    public bool sfxOn;

    public GameObject soundOnIcon;
    public GameObject soundOffIcon;
    public GameObject sfxOnIcon;
    public GameObject sfxOffIcon;


    // Use this for initialization
    private void Awake()
    {
        soundOnIcon = GameObject.Find("On");
        soundOffIcon = GameObject.Find("Off");
        sfxOnIcon = GameObject.Find("OnSfx");
        sfxOffIcon = GameObject.Find("OffSfx");

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
        sfxOn = true;
        soundOffIcon.gameObject.SetActive(false);
        sfxOffIcon.gameObject.SetActive(false);

    }
    public void PlayCoinset()
    {
        audiosc.PlayOneShot(coinSet);       
    }	

    public void PlayCoinDrop()
    {
        audiosc.PlayOneShot(coinDrop);
    }

    
    public void StopAudio()
    {
        if (soundOn)
        {
            audiosc.Stop();
            soundOnIcon.gameObject.SetActive(false);
            soundOffIcon.gameObject.SetActive(true);
            soundOn = false;
        }
        else
        {
            soundOnIcon.gameObject.SetActive(true);
            soundOffIcon.gameObject.SetActive(false);
            audiosc.Play();
            soundOn = true;
        }
       
    }
    public void StopSfx()
    {
        if (sfxOn)
        {
            sfxOnIcon.gameObject.SetActive(false);
            sfxOffIcon.gameObject.SetActive(true);
            sfxOn = false;
        }
        else
        {
            sfxOnIcon.gameObject.SetActive(true);
            sfxOffIcon.gameObject.SetActive(false);
            sfxOn = true;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
