using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public Canvas rulesMenu;
    public Canvas quitMenu;
    public Button startButton;
    public Button rulesButton;
    public Button creditsButton;
    public Button quitButton;
    
	void Start ()
    {
        rulesMenu = rulesMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        startButton = startButton.GetComponent<Button>();
        rulesButton = rulesButton.GetComponent<Button>();
        creditsButton = creditsButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        rulesMenu.enabled = false;
        quitMenu.enabled = false;
	}

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_Select");
    }

    public void OpenOptions()
    {
        rulesMenu.enabled = true;
        setStartMenu(false);
    }

    public void CloseOptions()
    {
        rulesMenu.enabled = false;
        setStartMenu(true);
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        setStartMenu(false);
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        setStartMenu(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    void setStartMenu (bool state)
    {
        startButton.enabled = state;
        rulesButton.enabled = state;
        creditsButton.enabled = state;
        quitButton.enabled = state;
    }

    
}
