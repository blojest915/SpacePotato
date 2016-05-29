using UnityEngine;
using System.Collections;

public class scr_Music : MonoBehaviour
{
    private AudioSource mySource;
    public AudioClip myMenuMusic;
    public AudioClip myLevelMusic;
    public AudioClip myWinMusic;
    public AudioClip myLoseMusic;


    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(transform.gameObject);
        mySource = GetComponent<AudioSource>();
        PlayMenuMusic();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void PlayMenuMusic()
    {
        mySource.clip = myMenuMusic;
        mySource.Play();
    }
    public void PlayLevelMusic()
    {
        mySource.clip = myLevelMusic;
        mySource.Play();
    }
    public void PlayWinMusic()
    {
        mySource.clip = myWinMusic;
        mySource.Play();
    }
    public void PlayLoseMusic()
    {
        mySource.clip = myLoseMusic;
        mySource.Play();
    }
}
