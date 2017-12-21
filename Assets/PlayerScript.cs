using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public int lvl, force, agi,intel, esprit, endu, PV, exp, nextlvlup;
    // Use this for initialization
    void Start () {
        PV = 50;
        endu = 50;
        esprit = 50;
        intel = 10;
        force = 10;
        agi = 10;
        

	}
	
	// Update is called once per frame
	void Update () {
        if(exp >= nextlvlup)
        {
            levelUp();

        }
        if(PV <= 0)
        {
            print("T'es mort");
        }
    }
    void levelUp()
    {
        print("levelup");
        exp += 1;
        lvl += 1;
        endu += 10;
        esprit +=10;
        intel += 10;
        agi += 10;
        force += 20;
        nextlvlup += 100;
    }
}
