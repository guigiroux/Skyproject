using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGround : MonoBehaviour {
    public float timer;
    public bool kc;
    public ScriptBoss Boss;
    // Use this for initialization
	void Start () {
        Boss = GameObject.Find("Boss").GetComponent<ScriptBoss>();
	}
	
	// Update is called once per frame
	void Update () {
		if (kc == true)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                if (this.gameObject.name == "BreakGround")
                {
                    Boss.bloquage = 1;
                    this.gameObject.SetActive(false);
                }
                if (this.gameObject.name == "BreakGround1")
                {
                    Boss.bloquage = 2;
                    this.gameObject.SetActive(false);

                }

            }
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Boss")
        {
            kc = true;
            
        }
    }
}
