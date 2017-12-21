using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptarrow : MonoBehaviour {
    public float prof = 0.30f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy") { 
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.Translate(prof * Vector3.forward);
        this.transform.parent = other.transform;
            }
    }
}
