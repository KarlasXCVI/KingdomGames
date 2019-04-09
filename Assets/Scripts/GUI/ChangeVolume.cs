using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {

    // Reference to Audio Source component
    public AudioSource BackGroundSound;
    public AudioSource CurrencySound;
    public AudioSource MouseclickSound;
    public AudioSource ObstacleCollisionSound;
    public AudioSource TimeFractureSound;

    public Slider BGMVolume;
    public Slider SoundVolume;

    // Use this for initialization
    void Start()
    {
        // check if the player has a music volume preference
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            // if yes, apply it.
            BGMVolume.value = PlayerPrefs.GetFloat("BGMVolume");
        }
        else
        {
            BGMVolume.value =  100;
        }

        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            // if yes, apply it.
            SoundVolume.value = PlayerPrefs.GetFloat("SoundVolume");
        }
        else
        {
            BGMVolume.value = 100;
        }
    }

    void Update()
    {
        // Setting volume option of Audio Source to be equal to musicVolume
        //BackGroundSound.volume = BGMVolume.value;
        //CurrencySound.volume = SoundVolume.value;
        //MouseclickSound.volume = SoundVolume.value;
        //ObstacleCollisionSound.volume = SoundVolume.value;
        //TimeFractureSound.volume = SoundVolume.value;
    }

    public void StartGaVolumePrefs()
    {
        PlayerPrefs.SetFloat("BGMVolume", BGMVolume.value);

        PlayerPrefs.SetFloat("SoundVolume", SoundVolume.value);
    }

}
