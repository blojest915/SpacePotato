using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class scr_QuitLevel : MonoBehaviour {

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level_Select");
            Time.timeScale = 1.0f;
            if (GameObject.FindWithTag("Music") != null)
            {
                GameObject.FindWithTag("Music").BroadcastMessage("PlayMenuMusic");
            }
        }
    }
}
