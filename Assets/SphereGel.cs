using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGel : MonoBehaviour {
    public float LifeCore;
    public PlayerScript Player;
    public ScriptBoss scriptboss;
    public float Timer;
	// Use this for initialization
	void Start () {
        LifeCore = 500;
        Player = GameObject.Find("Character").GetComponent<PlayerScript>();
        scriptboss = GameObject.Find("Boss").GetComponent<ScriptBoss>();

    }

    // Update is called once per frame
    void Update () {
		if(LifeCore <= 0 && scriptboss.bloquage != 6)
        {
            scriptboss.bloquage = 5;
        }
        if(LifeCore > 0 && scriptboss.animator.GetCurrentAnimatorStateInfo(0).IsName("creature1GetHit"))
        {
            Invoke("stophit", 0.15f);
        }
	}
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "arrow(Clone)")
        {
            LifeCore -= Player.agi;
            this.transform.parent.GetChild(2).gameObject.SetActive(true);
            scriptboss.animator.SetBool("damaged", true);

        }
    }
    public void stophit()
    {
        scriptboss.animator.SetBool("damaged", false);

    }
}
