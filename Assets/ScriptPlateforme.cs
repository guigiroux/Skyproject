using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlateforme : MonoBehaviour {
    public Transform platf1, platf2;
    public Vector3 BasePos, basepos;
   
	// Use this for initialization
	void Start () {
        platf1 = GameObject.Find("platf1").transform;
        platf1 = GameObject.Find("platf2").transform;
        basepos = this.transform.position;
     //   Vector3 BasePos = basepos.InverseTransformPoint(transform.position);


    }

    // Update is called once per frame
    void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Character" && GameObject.Find("SpawnFire").GetComponent<SpawnZombie>().zombiemort >= 10)
        {
   
            if (this.transform.position.y <= 255)
            {
                this.transform.Translate(Vector3.up * Time.deltaTime * 15, Space.World);

            }
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            this.transform.position = basepos;
        }
    }
}
