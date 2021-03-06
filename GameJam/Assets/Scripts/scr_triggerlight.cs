﻿ using UnityEngine;
using System.Collections;

public class scr_triggerlight : MonoBehaviour {

	private Light light01;
	private bool isOn = true;
    
    public scr_Eyeball eyeball;

    private float setDuration;
    private float lookDelai = 0.5f;

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
            ToggleLight();
        }
    }


    void ToggleLight()
	{
        if (isOn)
		{
            lookDelai = 0.5f;
            light01.enabled = false;
			isOn = false; 
			myLight.material = offMaterial;
			OnEye.SetActive(false);
			OffEye.SetActive(true);
            GameObject.FindGameObjectWithTag("WinCondition").GetComponent<WinScript>().decrementLights();
        }
		else
		{
            AudioSource audio = GetComponent<AudioSource>();
            audio.pitch += Random.Range(-0.3f,0.3f);
            audio.Play();
            light01.enabled = true;
			isOn = true;
			myLight.material = onMaterial;
			OnEye.SetActive(true);
			OffEye.SetActive(false);
			feedback.GetComponent<ParticleSystem> ().Play ();
            GameObject.FindGameObjectWithTag("WinCondition").GetComponent<WinScript>().incrementLights();

            
        }
	}
}