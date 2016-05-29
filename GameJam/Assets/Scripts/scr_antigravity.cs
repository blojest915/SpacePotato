using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Characters.FirstPerson
{
	[RequireComponent(typeof (CharacterController))]
	[RequireComponent(typeof (AudioSource))]

public class scr_antigravity : MonoBehaviour {

	private GameObject player;
	private FirstPersonController firstperson;



	// Use this for initialization
	void Awake () {

		player = GameObject.FindGameObjectWithTag("Player");
		firstperson = player.GetComponent <FirstPersonController> ();


	}

	void OnTriggerEnter (Collider other){
		if(other.gameObject == player){


				//rstperson.GetComponent.



		}


	}

	// Update is called once per frame
	void Update () {

	}
}

}