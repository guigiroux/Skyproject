using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystPorteG : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            this.transform.GetChild(0).Translate(new Vector3(-3.70f, 0, +0.5f));
            this.transform.GetChild(1).Translate(new Vector3(+3.70f, 0, +0.5f));



        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            this.transform.GetChild(0).Translate(new Vector3(+3.70f, 0, -0.5f ));
            this.transform.GetChild(1).Translate(new Vector3(-3.70f, 0, -0.5f));



        }
    }

}
