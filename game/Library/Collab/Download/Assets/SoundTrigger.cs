using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = GlobalVariables.volume / 4;
        audioSource.PlayOneShot(sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
