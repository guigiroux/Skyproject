using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereNuque : MonoBehaviour {
    public PlayerScript Player;
    public ScriptBoss scriptboss;
    public float corelife;

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Character").GetComponent<PlayerScript>();
        scriptboss = GameObject.Find("Boss").GetComponent<ScriptBoss>();
        corelife = 350;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(corelife <= 0)
        {
            scriptboss.bloquage = 6;
            Destroy(this.gameObject);
                    }
	}
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "sword")
        {
            corelife -= Player.force;
        }
    }
}
