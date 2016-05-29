using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinScript : MonoBehaviour {
    
    public Text lightCountText;
    public Text ScoreCountText;
    public Text TimerMultiplierText;
    public RestartScript restart;

    public scr_HugeEyeLid upperHugeEyeLid;
    public scr_HugeEyeLid lowerHugeEyeLid;


    private int TotalLights;
    private int LitLights;

    private float TimerFloat = 100;
    private int TimerMultiplier = 1;
    private int score = 0;
    private int levelAmount = 8;
    private int CurrentLevel;
    
	void Start () {

        TotalLights = GameObject.FindGameObjectsWithTag("Light").Length;
        ScoreCountText.text = "";
        TimerMultiplierText.text = "";
        updateLightCount();

        upperHugeEyeLid.associateEyeLid(true, TotalLights);
        lowerHugeEyeLid.associateEyeLid(false, TotalLights);
    }

    void Update()
    {
        TimerFloat -=  Time.deltaTime;
        if (TimerMultiplier < 1)
        {
            TimerMultiplier = 1;
        }
    }

    void CheckCurrentLevel()
    {
        for (int i = 1; i < levelAmount; i++)
        {
            if (SceneManager.GetActiveScene().name == "level" + i)
            {
                CurrentLevel = i;
                SaveMyGame();
            }
        }
    }

    void SaveMyGame()
    {
        int NextLevel = CurrentLevel + 1;
        if (NextLevel < levelAmount)
        {
            PlayerPrefs.SetInt("Level" + NextLevel.ToString(), 1);
        }
        updateLevelScore();
    }


    public void incrementLights()
    {
        LitLights++;
        score += 1;
        updateLightCount();
        upperHugeEyeLid.RaiseEyeLid();
        lowerHugeEyeLid.RaiseEyeLid();
    }

    public void decrementLights()
    {
        LitLights--;
        score -= 1;
        updateLightCount();
        upperHugeEyeLid.LowerEyeLid();
        lowerHugeEyeLid.LowerEyeLid();
    }

    void updateLightCount()
    {
        lightCountText.text = LitLights.ToString() + "/" + TotalLights.ToString()  + " Eyes Open";
        if (LitLights == TotalLights)
        {
            GameObject.FindWithTag("Music").BroadcastMessage("PlayWinMusic");
            Time.timeScale = 0f;
            lightCountText.text = "Level Complete";
            CheckCurrentLevel();
            restart.ToggleOn();
        }
    }

    void updateLevelScore()
    {
        TimerMultiplier = (int)Mathf.Floor(TimerFloat);
        if (TimerMultiplier < 1)
        {
            TimerMultiplier = 1;
        }
        score = score * TimerMultiplier;
        if (score < 0)
        {
            score = 0;
        }
        ScoreCountText.text = "Score: " + score.ToString();
        TimerMultiplierText.text = "Timer Multiplier: x" + TimerMultiplier.ToString();
        if (PlayerPrefs.GetInt("Level" + CurrentLevel.ToString() + "_score") < score)
        {
            PlayerPrefs.SetInt("Level" + CurrentLevel.ToString() + "_score", score);
        }
    }
}
