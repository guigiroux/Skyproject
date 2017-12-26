using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptTeleportation : MonoBehaviour {
    public bool TPFIN;
    public GameObject Player;
    public Rigidbody rb;
    public GameObject Quete;

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("FPSController");
        rb = Player.GetComponent<Rigidbody>();
        Quete = GameObject.Find("Quete");

    }

    // Update is called once per frame
    void Update () {
        if (TPFIN == true)
        {
            Player.GetComponent<FirstPersonController>().enabled = false;
            Player.transform.position = new Vector3(GameObject.Find("SpawnNebuleuse").transform.position.x, GameObject.Find("SpawnNebuleuse").transform.position.y + 2, GameObject.Find("SpawnNebuleuse").transform.position.z);
            //Player.GetComponent<Rigidbody>().freezeRotation = true;
            Player.transform.eulerAngles = new Vector3(0, -266, 0);
            // Player.transform.GetChild(0).eulerAngles = new Vector3(0, 160, 0);
            Player.transform.GetChild(0).GetChild(0).GetComponent<PlayerScript>().CurrentWeapon = 0;
            Player.transform.GetChild(0).GetChild(0).GetComponent<PlayerScript>().enabled = false;


            Quete.transform.GetChild(0).gameObject.SetActive(true);
            Quete.transform.GetChild(1).gameObject.SetActive(true);
            Quete.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Bien joué Héros. Malgré les pertes, vous avez empêché le culte et leur innommable démon de consumer ce monde. Vous êtes maintenant au coeur des dimensions, le chemin qui vous mènera à vôtre prochaine aventure n'est pas loin...";

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("ZoneBase");
            }
            // Camera.main.transform.eulerAngles = new Vector3(15.3f, 0, 0);
            //RigidbodyConstraints.FreezeRotationX;
        }   
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character" && this.gameObject.name == "TPVolcan")
        {
            QueteScript.UneQuete = 9;
            other.transform.parent.parent.position = new Vector3(GameObject.Find("TPBOSS").transform.position.x, GameObject.Find("TPBOSS").transform.position.y + 2, GameObject.Find("TPBOSS").transform.position.z);
            GameObject.Find("TerrainZoneFinale").transform.GetChild(0).gameObject.SetActive(true);
        
              }
        if (other.gameObject.name == "Character" && this.gameObject.name == "PortailBoss")
        {
            TPFIN = true;
        }
    }
}
