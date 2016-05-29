using UnityEngine;
using System.Collections;

public class scr_MusicSpawner : MonoBehaviour {
    public GameObject myMusic;

	// Use this for initialization
	void Start () {

        if(GameObject.FindGameObjectWithTag("Music") == null)
        {
           GameObject myMusicObject = Instantiate(myMusic, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
