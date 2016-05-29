using UnityEngine;
using System.Collections;

public class LoseScript : MonoBehaviour {

    public RestartScript restart;

    private static bool gameover;
    
    void Start()
    {
        GameObject.FindWithTag("Music").BroadcastMessage("PlayLevelMusic");
        gameover = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameover == false)
        {
            if (other.gameObject.CompareTag("DeadZone"))
            {
                GameOver();
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
