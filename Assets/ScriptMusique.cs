using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMusique : MonoBehaviour {
    public AudioClip Village, Cimetiere, Glace, Volcan, Boss, Fin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerStay(Collider other)
    { if (this.transform.parent.GetComponent<AudioSource>().isPlaying == false)
        {
            this.transform.parent.GetComponent<AudioSource>().Play();

        }

        if (other.gameObject.name == "Character")
        {
            switch (this.gameObject.name)
            {
                case "VillageTrigg":
                    if (this.transform.parent.GetComponent<AudioSource>().clip != Village)
                    {

                        village();
                    }

                    break;

                case "CimTrigg":
                    if (this.transform.parent.GetComponent<AudioSource>().clip != Cimetiere)
                    {
                        cimetiere();
                    }
                    break;
                case "GlaceTrigg":
                    if (this.transform.parent.GetComponent<AudioSource>().clip != Glace)
                    {
                        glace();
                    }
                    break;
                case "VolcanTrigg":
                    if (this.transform.parent.GetComponent<AudioSource>().clip != Volcan)
                    {
                        volcan();
                    }
                    break;
                case "BossTrigg":
                    if (this.transform.parent.GetComponent<AudioSource>().clip != Boss)
                    {
                        boss();
                    }
                    break;
                case "FinTrigg":
                    if (this.transform.parent.GetComponent<AudioSource>().clip != Fin)
                    {
                        fin();
                    }
                    break;
            }
        }
    }
    public void village()
    {
        this.transform.parent.GetComponent<AudioSource>().clip = Village;
        this.transform.parent.GetComponent<AudioSource>().Play();
    }
    public void cimetiere()
    {
        this.transform.parent.GetComponent<AudioSource>().clip = Cimetiere;
        this.transform.parent.GetComponent<AudioSource>().Play();
    }
    public void glace()
    {
        this.transform.parent.GetComponent<AudioSource>().clip = Glace;
        this.transform.parent.GetComponent<AudioSource>().Play();
    }
    public void volcan()
    {
        this.transform.parent.GetComponent<AudioSource>().clip = Volcan;
        this.transform.parent.GetComponent<AudioSource>().Play();
    }
    public void boss()
    {
        this.transform.parent.GetComponent<AudioSource>().clip = Boss;
        this.transform.parent.GetComponent<AudioSource>().Play();
    }
    public void fin()
    {
        this.transform.parent.GetComponent<AudioSource>().clip = Fin;
        this.transform.parent.GetComponent<AudioSource>().Play();
    }

}
