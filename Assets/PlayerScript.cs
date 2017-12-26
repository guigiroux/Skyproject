using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerScript : MonoBehaviour {
    public float nowmana, lvl, force, agi, intel, esprit, endu, PV, exp, nextlvlup;
    public RectTransform pv, mana, xp;
    public int CurrentWeapon, ActivableWeapon;
    public Text manat, pvt, xpt;
    // Use this for initialization
    void Awake () {
        PV = 50;
        nowmana = 50;
        endu = 50;
        esprit = 50;
        intel = 10;
        force = 10;
        agi = 10;
        nextlvlup = 100;



    }
	
	// Update is called once per frame
	void FixedUpdate () {
        manat.text = Mathf.Round(nowmana) + "/" + esprit;
        pvt.text = Mathf.Round(PV) + "/" + endu;
        xpt.text = exp + "/" + nextlvlup;

        switch (Input.inputString)
        {
            case "1" : if (ActivableWeapon >= 1) { this.transform.GetChild(0).gameObject.SetActive(true); CurrentWeapon = 1; this.transform.GetChild(1).gameObject.SetActive(false); this.transform.GetChild(2).gameObject.SetActive(false); this.transform.GetChild(3).gameObject.SetActive(false); } break;
            case "2": if (ActivableWeapon >= 2) { this.transform.GetChild(1).gameObject.SetActive(true); CurrentWeapon = 2; this.transform.GetChild(0).gameObject.SetActive(false); this.transform.GetChild(2).gameObject.SetActive(false); this.transform.GetChild(3).gameObject.SetActive(false); } break;
            case "3": if (ActivableWeapon >= 3) { this.transform.GetChild(2).gameObject.SetActive(true); CurrentWeapon = 3; this.transform.GetChild(1).gameObject.SetActive(false); this.transform.GetChild(0).gameObject.SetActive(false); this.transform.GetChild(3).gameObject.SetActive(false); } break;
            case "4": if (ActivableWeapon >= 4) { this.transform.GetChild(3).gameObject.SetActive(true); CurrentWeapon = 4; this.transform.GetChild(1).gameObject.SetActive(false); this.transform.GetChild(2).gameObject.SetActive(false); this.transform.GetChild(0).gameObject.SetActive(false); } break;
        }
        switch (Input.inputString)
        {
            case "&": if (ActivableWeapon >= 1) { this.transform.GetChild(0).gameObject.SetActive(true); CurrentWeapon = 1; this.transform.GetChild(1).gameObject.SetActive(false); this.transform.GetChild(2).gameObject.SetActive(false); this.transform.GetChild(3).gameObject.SetActive(false); } break;
            case "é": if (ActivableWeapon >= 2) { this.transform.GetChild(1).gameObject.SetActive(true); CurrentWeapon = 2; this.transform.GetChild(0).gameObject.SetActive(false); this.transform.GetChild(2).gameObject.SetActive(false); this.transform.GetChild(3).gameObject.SetActive(false); } break;
            case " \" ": if (ActivableWeapon >= 3) { this.transform.GetChild(2).gameObject.SetActive(true); CurrentWeapon = 3; this.transform.GetChild(1).gameObject.SetActive(false); this.transform.GetChild(0).gameObject.SetActive(false); this.transform.GetChild(3).gameObject.SetActive(false); } break;
            case "'": if (ActivableWeapon >= 4) { this.transform.GetChild(3).gameObject.SetActive(true); CurrentWeapon = 4; this.transform.GetChild(1).gameObject.SetActive(false); this.transform.GetChild(2).gameObject.SetActive(false); this.transform.GetChild(0).gameObject.SetActive(false); } break;
        }
        if (exp >= nextlvlup)
        {
            levelUp();

        }
        if(PV <= 0)
        {
            SceneManager.LoadScene("ZoneBase");

            print("T'es mort");
        }
        if (Input.GetMouseButtonDown(0) && CurrentWeapon == 1)
        {
           this.transform.GetChild(0).GetComponent<Animator>().SetBool("Attack", true);    
        }
        if (nowmana < esprit)
        {if(CurrentWeapon == 1 || CurrentWeapon == 2)
            {
                nowmana += 0.1f;
            }
        if(CurrentWeapon == 3 && Input.GetMouseButton(0) != true || CurrentWeapon == 4 && Input.GetMouseButton(0) != true)
            {

                nowmana += 0.1f;
            }
            
        }
        if (Input.GetMouseButton(0) && CurrentWeapon == 4 && PV < endu && nowmana > 0)
        {
            this.transform.GetChild(3).GetChild(0).gameObject.SetActive(true); this.nowmana -= 0.2f; PV += 0.3f; if (PV > endu) {PV = endu; }
        }
        if (Input.GetMouseButton(0) && CurrentWeapon == 3 && nowmana > 0)
        {
        this.transform.GetChild(2).GetChild(0).gameObject.SetActive(true); this.nowmana -= 0.2f;
          if (nowmana <= 0){
                this.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            }
                
        }
      
        if (Input.GetMouseButtonUp(0))
        {
            switch (CurrentWeapon)
            {
                case 1: this.transform.GetChild(0).GetComponent<Animator>().SetBool("Attack", false); break;
                case 3: this.transform.GetChild(2).GetChild(0).gameObject.SetActive(false); break;
                case 4: this.transform.GetChild(3).GetChild(0).gameObject.SetActive(false); break;
                default: break;
            }
        }
        
      
    }
    void levelUp()
    {
        print("levelup");
        exp += 1;
        lvl += 1;
        endu += 10;
        esprit +=10;
        nowmana += 10;
        intel += 10;
        agi += 10;
        force += 20;
        PV = endu;
        nextlvlup += 100;
    }
    
}
