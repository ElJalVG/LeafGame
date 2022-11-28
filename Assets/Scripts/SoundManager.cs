using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        /*if (PlayerPrefs.HasKey("musicVolumen"))
        {
            PlayerPrefs.SetFloat("musicVolumen", 1);
            {
                Load();
            }
        }
        else
        {
            Load();
        }*/
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolumen", volumeSlider.value);
        Debug.Log(volumeSlider.value);
    }
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolumen");
    }
}
