 using UnityEngine;
using System.Collections;

public class scr_triggerlight : MonoBehaviour {

	private Light light01;
	private bool isOn = true; 

	private Renderer myLight; 
	public Material onMaterial;
	public Material offMaterial;
	public GameObject OnEye;
	public GameObject OffEye;
	public GameObject feedback;

	// Use this for initialization
	void Start () 
	{
		light01 = gameObject.GetComponentInChildren<Light> ();
		myLight = gameObject.GetComponentInChildren<Renderer> ();

		myLight.material = offMaterial;
        light01.enabled = false;
        isOn = false;
    }


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			ToggleLight ();
		}
	}

		
	void ToggleLight()
	{
		if(isOn)
		{
			light01.enabled = false;
			isOn = false; 
			myLight.material = offMaterial;
			OnEye.SetActive(false);
			OffEye.SetActive(true);
            GameObject.FindGameObjectWithTag("WinCondition").GetComponent<WinScript>().decrementLights();
        }
		else
		{
			light01.enabled = true;
			isOn = true;
			myLight.material = onMaterial;
			OnEye.SetActive(true);
			OffEye.SetActive(false);
			feedback.GetComponent<ParticleSystem> ().Play ();
            GameObject.FindGameObjectWithTag("WinCondition").GetComponent<WinScript>().incrementLights();
		//	feedback.SetActive(true);

			//feedback.playOnAwake = true;

        }
	}
	

		
// Update is called once per frame
void Update() {}

	//void OnTriggerEnter (Collider other){

		//if(collider.gameObject.tag == "trigger"){
			//Instantiate (ampoule, transform.light, transform.light);
}
		


			


		// on trigger enter alors this.objet tag ampoule == on



