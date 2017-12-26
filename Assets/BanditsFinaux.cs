using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditsFinaux : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.childCount == 0)
        {
            this.transform.parent.GetChild(0).gameObject.SetActive(true);
            this.transform.parent.GetChild(1).gameObject.SetActive(false);

        }
    }
}
