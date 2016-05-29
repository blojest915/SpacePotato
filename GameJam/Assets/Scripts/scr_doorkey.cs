using UnityEngine;
using System.Collections;

public class scr_doorkey : MonoBehaviour {

	public Transform porte;
	private bool isOpen = false; 
	public Vector3 directionporte;
	private bool isMoving = false;
	private float i = 0;
	private GameObject player;
	private scr_keyinventory Keyinventory;
	//private GameObject key;
	private scr_keypickup Keypickup;



	// Use this for initialization
	void Start () 
	{
		//porte = gameObject.GetComponentInChildren<Transform> ();
	}

	void Awake () {

		player = GameObject.FindGameObjectWithTag("Player");
		Keyinventory = player.GetComponent <scr_keyinventory> ();
		Keypickup = GameObject.FindGameObjectWithTag ("key").GetComponent <scr_keypickup> ();



	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && Keyinventory.hasKey == true)
		{
			isOpen = true;
			isMoving = true;
			Keyinventory.hasKey = false;
			Keypickup.Destroykey ();

		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player"&& Keyinventory.hasKey == true)
		{
			isOpen = false;
			isMoving = false;


		}
	}





	// Update is called once per frame
	void Update() {

		if (isMoving){

			i += Time.deltaTime;

			if (isOpen){

				porte.transform.position = Vector3.Lerp (porte.transform.position, porte.transform.position+directionporte, Time.deltaTime * 0.5f);

				if (i>2.0f){
					i = 0f;
					isMoving =false;
					isOpen= false;
				}

				//<
				//porte.transform.position = porte.transform.position+directionporte;
				//isMoving = false;
				//isOpen = true;
			}

			if (!isOpen){

				porte.transform.position = Vector3.Lerp (porte.transform.position,porte.transform.position-directionporte, Time.deltaTime * 0.5f);

				if (i>2.0f){
					i = 0f;
					isMoving=false;
					isOpen=true;
					//porte.transform.position = porte.transform.position-directionporte;
					//isMoving = false;
					//isOpen = false;
				}
			}





		}



	}





}

//void OnTriggerEnter (Collider other){

//if(collider.gameObject.tag == "trigger"){
//Instantiate (ampoule, transform.light, transform.light);







// on trigger enter alors this.objet tag ampoule == on



