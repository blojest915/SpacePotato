using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelManagerScript : MonoBehaviour {
    
    [System.Serializable]
    public class Level
    {
        public string LevelText;
        public string ScoreText;
        public int Unlocked;
        public bool IsInteractable;
        
    }
    public GameObject levelButton;
    public Transform Spacer;
    public List<Level> levelList;
    

	// Use this for initialization
	void Start () {
        //DeleteAll();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FillList();
    }
	
    void FillList()
    {
        foreach (var level in levelList)
        {
            GameObject newButton = Instantiate(levelButton) as GameObject;
            LevelButtonScript button = newButton.GetComponent<LevelButtonScript>();
            button.LevelText.text = level.LevelText;
            button.ScoreText.text = level.ScoreText;
            //Level1, Level2,

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1)
            {
                level.Unlocked = 1;
                level.IsInteractable = true;
            }

            button.unlocked = level.Unlocked;
            button.GetComponent<Button>().interactable = level.IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => loadLevels("level" + button.LevelText.text));

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") > 0)
            {
                button.ScoreText.text = PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score").ToString();
            }

            newButton.transform.SetParent(Spacer, false);
        }
    }
    
    void SaveAll()
    {
        GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        foreach (GameObject buttons in allButtons)
        {
            LevelButtonScript button = buttons.GetComponent<LevelButtonScript>();
            PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
        }
    }

    void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    void loadLevels(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
