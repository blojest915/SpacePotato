using UnityEngine;
using System.Collections;

public class scr_triggerdoors : MonoBehaviour {

	public Transform porte;
	private bool isOpen = false; 
	public Vector3 directionporte;
	private bool isMoving = false;
	private float i = 0;



	// Use this for initialization
	void Start () 
	{
	//porte = gameObject.GetComponentInChildren<Transform> ();
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			isOpen = true;
			isMoving = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			isOpen = false;
			isMoving = true;
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



