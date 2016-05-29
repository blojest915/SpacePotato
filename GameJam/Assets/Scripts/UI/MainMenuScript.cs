using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public Canvas optionsMenu;
    public Canvas quitMenu;
    public Button startButton;
    public Button optionsButton;
    public Button creditsButton;
    public Button quitButton;
    
	void Start ()
    {
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        startButton = startButton.GetComponent<Button>();
        optionsButton = optionsButton.GetComponent<Button>();
        creditsButton = creditsButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        optionsMenu.enabled = false;
        quitMenu.enabled = false;
	}

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_Select");
    }

    public void OpenOptions()
    {
        optionsMenu.enabled = true;
        setStartMenu(false);
    }

    public void CloseOptions()
    {
        optionsMenu.enabled = false;
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
        optionsButton.enabled = state;
        creditsButton.enabled = state;
        quitButton.enabled = state;
    }

    
}
