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
        if (GameObject.FindWithTag("Music") != null)
        {
            GameObject.FindWithTag("Music").BroadcastMessage("PlayLevelMusic");
        }
        isActive = false;
        RestartImage.enabled = false;
        RestartText.enabled = false;
        YesText.enabled = false;
        NoText.enabled = false;
    }

	public void ToggleOn()
    {
        isActive = true;
        RestartImage.enabled = true;
        RestartText.enabled = true;
        YesText.enabled = true;
        NoText.enabled = true;
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("Level_Select");
        Time.timeScale = 1.0f;
        if (GameObject.FindWithTag("Music") != null)
        {
            GameObject.FindWithTag("Music").BroadcastMessage("PlayMenuMusic");
        }

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
