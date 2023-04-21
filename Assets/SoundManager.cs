using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource aS;

    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this; ;
        if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int index)
    {
        aS.clip = clips[index]; 
        aS.Play();
    }
}
