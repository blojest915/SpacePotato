using UnityEngine;
using System.Collections;

public class scr_HugeEyeball : MonoBehaviour {

    Transform player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }
}
