using UnityEngine;
using System.Collections;

public class LoseScript : MonoBehaviour {

    public RestartScript restart;

    private static bool gameover;
    
    void Start()
    {
        gameover = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameover == false)
        {
            if (other.gameObject.CompareTag("DeadZone"))
            {
                GameOver();
                if (GameObject.FindWithTag("Music") != null)
                {
                    GameObject.FindWithTag("Music").BroadcastMessage("PlayLoseMusic");
                }
                Time.timeScale = 0f;
                restart.ToggleOn();
            }
        }

    }

    public void GameOver()
    {
        gameover = true;
    }
    
}
