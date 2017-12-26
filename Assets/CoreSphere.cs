using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSphere : MonoBehaviour {
    public bool deza, chut;
    public int i;
    public ScriptBoss boss;
	// Use this for initialization
	void Start () {
        boss = this.transform.parent.parent.parent.GetComponent<ScriptBoss>();
	}
	
	// Update is called once per frame
	void Update () {
        if (i == 2)
        {
            this.transform.parent.GetChild(1).gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
		if (deza == true)
        {
            Invoke("Dez", 4f);
            deza = false;
        }
        if (boss.bloquage == 1 && chut == false|| boss.bloquage == 2 && chut == false)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            deza = true;
            chut = true;

            
        }
    }

    void Dez()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        
        i += 1;
        chut = false;
    }




}
