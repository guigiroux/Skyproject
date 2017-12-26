using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArc : MonoBehaviour {
    public GameObject ArrowP;
    public Transform ArrowSpawn;
    public float tendu;
    public int tenduint;
    public GameObject arrow;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            InstantArrow();

        }
        if (Input.GetMouseButton(0))
        {
           
            
            if (arrow != null)
            {
                arrow.transform.position = ArrowSpawn.transform.position;
                arrow.transform.rotation = ArrowSpawn.transform.rotation;
            }

        }
      
            if (Input.GetMouseButtonUp(0))
        {

            Fire();
            Destroy(arrow, 2f);


        }
    }
    void InstantArrow()
    {
        arrow = (GameObject)Instantiate(  ArrowP, ArrowSpawn.position,  ArrowSpawn.rotation);


        // Destroy the bullet after 2 seconds
    }
    void Fire()
    {
        if (arrow != null)
        {

          arrow.GetComponent<Rigidbody>().AddForce((arrow.transform.up * -1) * 2000); 
               
        }
    
    }
}
