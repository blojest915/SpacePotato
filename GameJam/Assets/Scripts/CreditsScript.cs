using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsScript : MonoBehaviour {

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
