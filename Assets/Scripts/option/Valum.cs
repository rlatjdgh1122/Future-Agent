using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valum : MonoBehaviour
{
    [SerializeField] private Slider volumSlider = null;

    [SerializeField] private Text volumeTextUI = null;

    public void VolumSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0,0");
    }

    public void  SaveVolumeButten()
    {
        float volumeValue = volumSlider.value;
        PlayerPrefs.SetFloat("VolemeValue", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumValue = PlayerPrefs.GetFloat("VolemeValue");
        volumSlider.value = volumValue;
        AudioListener.volume = volumValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
