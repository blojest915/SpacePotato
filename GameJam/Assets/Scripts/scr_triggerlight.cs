 using UnityEngine;
using System.Collections;

public class scr_triggerlight : MonoBehaviour {

	private Light light01;
	private bool isOn = true;

    private bool isTurningOff = false;

    public float duration = 10.0f;

    private float setDuration;

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
        setDuration = duration;
        myLight.material = offMaterial;
        light01.enabled = false;
        isOn = false;
    }

    void resetDuration()
    {
        duration = setDuration;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ToggleLight();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && isOn)
        {
            isTurningOff = true;
        }
    }


    void ToggleLight()
	{
        isTurningOff = false;
        resetDuration();
        if (isOn)
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
            AudioSource audio = GetComponent<AudioSource>();
            audio.pitch += Random.Range(-0.5f,0.5f);
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

    

    void Update()
    {
        if (isTurningOff)
        {
            duration = duration -= Time.deltaTime;
            float amplitude = duration;
            light01.intensity = amplitude;
            if (duration < 0)
            {
                ToggleLight();
            }
        }
    }
    
}