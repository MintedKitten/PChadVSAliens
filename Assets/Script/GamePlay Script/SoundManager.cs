using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider volumeSlider;
    void Start()
    {
        if(!PlayerPrefs.HasKey("audiovolume"))
        {
            PlayerPrefs.SetFloat("audiovolume",1);
            load();
        }
        else
        {
            load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Changevolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("audiovolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("audiovolume",volumeSlider.value);
    }
}
