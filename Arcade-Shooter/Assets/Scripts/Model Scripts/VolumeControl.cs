using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider MasterSlider;
    public Slider BackgroundSlider;
    public Slider EffectSlider;
    // Start is called before the first frame update
    void Start()
    {           
        // Initialize sliders with saved values or defaults
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        BackgroundSlider.value = PlayerPrefs.GetFloat("BackgroundVolume", 0.75f);
        EffectSlider.value = PlayerPrefs.GetFloat("EffectVolume", 0.75f);
        
        // Set initial volumes
        SetMasterVolume(MasterSlider.value);
        SetBackgroundVolume(BackgroundSlider.value);
        SetEffectVolume(EffectSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float sliderValue)
    {
        mixer.SetFloat("MasterVolume", sliderValue);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }

    public float GetMasterVolume(){
        return PlayerPrefs.GetFloat("MasterVolume", 0.75f);
    }
     public void SetBackgroundVolume(float sliderValue)
    {
        mixer.SetFloat("BackgroundVolume", sliderValue);
        PlayerPrefs.SetFloat("BackgroundVolume", sliderValue);
    }

    public void SetEffectVolume(float sliderValue)
    {
        mixer.SetFloat("EffectVolume", sliderValue);
        PlayerPrefs.SetFloat("EffectVolume", sliderValue);
    }
}
