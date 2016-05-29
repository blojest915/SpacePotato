using UnityEngine;
using System.Collections;

public class scr_Music : MonoBehaviour
{
    private AudioSource mySource;
    public AudioClip myMenuMusic;
    public AudioClip myLevelMusic;
    public AudioClip myWinMusic;
    public AudioClip myLoseMusic;
    private float i = 0;
    bool hasStarted = false;

    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(transform.gameObject);
        mySource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        i += Time.deltaTime;

        if (i > 1 && !hasStarted)
        {
            hasStarted = true;
            StartUpDelay(1);
        }
    }

    void StartUpDelay(int musicNumber)
    {
        if (musicNumber == 1)
        {
            PlayMenuMusic();
        }
        else if (musicNumber == 2)
        {
            PlayLevelMusic();
        }
        else if (musicNumber == 3)
        {
            PlayWinMusic();
        }
        else if (musicNumber == 4)
        {
            PlayLoseMusic();
        }
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
