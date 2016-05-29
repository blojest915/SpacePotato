using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinScript : MonoBehaviour {
    
    public int score = 0;
    public Text ScoreCountText;
    public Text lightCountText;
    public RestartScript restart;

    private int TotalLights;
    private int LitLights;

    private int TimerMultiplier;

    private int levelAmount = 8;
    private int CurrentLevel;
    
	void Start () {
        TotalLights = GameObject.FindGameObjectsWithTag("Light").Length;
        updateTextScore();
        updateLightCount();
        TimerMultiplier = 4;
    }

    void CheckCurrentLevel()
    {
        for (int i = 1; i < levelAmount; i++)
        {
            if (SceneManager.GetActiveScene().name == "level" + i)
            {
                CurrentLevel = i;
                Debug.Log(CurrentLevel);
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
            updateLevelScore();
        }
        else
        {
            updateLevelScore();
        }
        
    }


    public void incrementLights()
    {
        LitLights++;
        score += 1000;
        updateTextScore();
        updateLightCount();
    }

    public void decrementLights()
    {
        LitLights--;
        score -= 1000;
        updateTextScore();
        updateLightCount();
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Lost Multipliser");
        TimerMultiplier--;
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

    void updateTextScore()
    {
        ScoreCountText.text = score.ToString();
    }

    void updateLevelScore()
    {
        if (PlayerPrefs.GetInt("Level" + CurrentLevel.ToString() + "_score") < score)
        {
            PlayerPrefs.SetInt("Level" + CurrentLevel.ToString() + "_score", score);
        }
    }
}
