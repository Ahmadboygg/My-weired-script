using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource[] soundVolume;
    void Start()
    {
        if(!PlayerPrefs.HasKey("Sound Volume"))
        {
            PlayerPrefs.SetFloat("Sound Volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    void Update()
    {
        for(int i = 0; i <= soundVolume.Length -1; i++)
        {
            soundVolume[i].volume = volumeSlider.value;
        }
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Sound Volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Sound Volume", volumeSlider.value);
    }
}
