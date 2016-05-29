using UnityEngine;
using System.Collections;

public class scr_keypickup : MonoBehaviour {


	private GameObject player;
	private scr_keyinventory Keyinventory;
	public GameObject key;
	public GameObject keyinstance;

	// Use this for initialization
	void Awake () {

		player = GameObject.FindGameObjectWithTag("Player");
		Keyinventory = player.GetComponent <scr_keyinventory> ();
		keyinstance = Instantiate (key, transform.position, transform.rotation) as GameObject;

	
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject == player) {

			Keyinventory.hasKey = true;
			//Destroy (this.gameObject);
			//Instantiate (key, player.transform.position, player.transform.rotation);
			//key.transform.position = Vector3.Lerp (key.transform.position, player.transform.position, Time.deltaTime * 0.5f);
			//key.transform.parent = player.transform;
			//key.parent=null;
			keyinstance.transform.SetParent (player.transform);
				



		}
	}

		public void Destroykey(){

			Destroy (keyinstance);
		}
	}
	
	// Update is called once per frame
