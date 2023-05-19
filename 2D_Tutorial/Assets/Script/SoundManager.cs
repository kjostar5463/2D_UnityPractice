using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SOUND_TYPE
    { 
        JUMP,
        SCORE,
        GAME_OVER
    }

    private AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;

    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Sound(SOUND_TYPE soundType)
    {
        audioSource.PlayOneShot(audioClip[(int)soundType]);
    }



}
