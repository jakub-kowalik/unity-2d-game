using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = GameObject.Find("volumeSlider").GetComponent<Slider>();
        volumeSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });

        musicSource = GameObject.Find("musicSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSliderValueChanged()
    {
        GlobalVariables.volume = volumeSlider.value;
        musicSource.volume = volumeSlider.value;
    }


}
