using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptbarrel : MonoBehaviour {
    public AudioClip explo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.name == "flamme")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
          if ( this.GetComponent<AudioSource>().clip != explo){

                this.GetComponent<AudioSource>().clip = explo;
                this.GetComponent<AudioSource>().Play();
            }
            if (this.gameObject.name == "Barrels1") {
                GameObject.Find("Floor1").SetActive(false);
                GameObject.Find("Sol1").transform.GetChild(1).gameObject.SetActive(true);
                Destroy(this.gameObject,1f);


            }
            if (this.gameObject.name == "Barrels")
            {
                GameObject.Find("Floor").SetActive(false);
                GameObject.Find("Sol").transform.GetChild(1).gameObject.SetActive(true);
                Destroy(this.gameObject,1f);
            }
        }
    }
}
