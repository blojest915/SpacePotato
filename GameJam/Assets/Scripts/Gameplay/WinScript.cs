using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinScript : MonoBehaviour {
    
    public int score = 0;
    public Text lightCountText;
    public Text ScoreCountText;
    public Text TimerMultiplierText;
    public RestartScript restart;

    private int TotalLights;
    private int LitLights;

    private float TimerFloat = 100;
    private int TimerMultiplier = 1;

    private int levelAmount = 8;
    private int CurrentLevel;
    
	void Start () {

        TotalLights = GameObject.FindGameObjectsWithTag("Light").Length;
        ScoreCountText.text = "";
        TimerMultiplierText.text = "";
        updateLightCount();
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
    }

    public void decrementLights()
    {
        LitLights--;
        score -= 1;
        updateLightCount();
    }

    void updateLightCount()
    {
        lightCountText.text = LitLights.ToString() + "/" + TotalLights.ToString();
        if (LitLights == TotalLights)
        {
            Time.timeScale = 0f;
            lightCountText.text = "Level Complete";
            CheckCurrentLevel();
            restart.ToggleOn();
        }
    }

    void updateLevelScore()
    {
        TimerMultiplier = (int)TimerFloat;
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
