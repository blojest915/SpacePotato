using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartScript : MonoBehaviour {

    bool isActive;
    public Image RestartImage;
    public Text RestartText;
    public Text YesText;
    public Text NoText;

    void Start()
    {
        isActive = false;
        RestartImage.enabled = false;
        RestartText.enabled = false;
        YesText.enabled = false;
        NoText.enabled = false;
    }

	public void ToggleOn()
    {
        isActive = true;
        RestartText.enabled = true;
        YesText.enabled = true;
        NoText.enabled = true;
        GameObject.FindWithTag("Music").BroadcastMessage("PlayLoseMusic");
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        GameObject.FindWithTag("Music").BroadcastMessage("PlayLevelMusic");

    }

    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("Level_Select");
        Time.timeScale = 1.0f;
        GameObject.FindWithTag("Music").BroadcastMessage("PlayMenuMusic");

    }

    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.Y))
                RestartCurrentLevel();

            if (Input.GetKeyUp(KeyCode.N))
                GoToLevelSelect();
        }
    }
}
