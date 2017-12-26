using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueteScript : MonoBehaviour {
    public GameObject Quete;
    public static bool queteaffichee;
    public SpawnZombie spawnzombie, SpawnZGlace, SpawnZFlamme;
    public PlayerScript player;
    public static int SuiteQuete;
    public static int UneQuete;
    public bool opening, rituelmagie;
    public float timeporte;
    public Text obj;
	// Use this for initialization
	void Start () {
        obj = GameObject.Find("objectif").GetComponent<Text>();
        Quete = GameObject.Find("Quete");
        spawnzombie = GameObject.Find("Spawnz").GetComponent<SpawnZombie>();
        SpawnZGlace = GameObject.Find("SpawnGlace").GetComponent<SpawnZombie>();
        SpawnZFlamme = GameObject.Find("SpawnFire").GetComponent<SpawnZombie>();
        player = GameObject.Find("Character").GetComponent<PlayerScript>();
        queteaffichee = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (UneQuete == 7)
        {

            if (GameObject.Find("Monolithe").transform.position.y < 115)
            {
                GameObject.Find("Monolithe").transform.Translate(Vector3.up * Time.deltaTime * 15, Space.World);

            }
        }

        if (UneQuete == 2)
        {
            obj.text = spawnzombie.zombiemort + "/" + "10 zombies" + "Ouvrez la porte !";
            
        }
        if (UneQuete == 6)
        {
            obj.text = SpawnZGlace.zombiemort + "/" + "10 zombies.";
        }
        if (UneQuete == 8)
        {
            obj.text = SpawnZFlamme.zombiemort + "/" + "10 zombies.";
        }

        if (Input.GetMouseButtonDown(0) && queteaffichee == true)
            {
                Quete.transform.GetChild(0).gameObject.SetActive(false);
                Quete.transform.GetChild(1).gameObject.SetActive(false);
            queteaffichee = false;

        }

        if (opening == true)
        {
            timeporte += Time.deltaTime;
            if (timeporte < 6)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 8, Space.World);
                
            }
            if (timeporte >= 6)
            {
                timeporte = 0;
                opening = false;

            }

        }
        if(rituelmagie == true)
        {
            timeporte += Time.deltaTime;
            if (timeporte <= 6)
            {
                GameObject.Find("MagicCircle").transform.GetChild(0).gameObject.SetActive(true);
               
                foreach (Transform item in GameObject.Find("MagicCircle").transform.GetChild(0).GetChild(0))
                {
                    item.transform.Rotate(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360));
                }
            }

        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Character" && UneQuete == 6 && GameObject.Find("SecteNeige").transform.childCount == 0)
        {
            GameObject.Find("Neige").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Neige").transform.GetChild(1).gameObject.SetActive(true);

            UneQuete = 7;
        }
        if (other.gameObject.name == "Character" && this.gameObject.name == "Quete4" )
        {
            if (this.transform.childCount == 0)
            {
                Quete.transform.GetChild(0).gameObject.SetActive(true);
                Quete.transform.GetChild(1).gameObject.SetActive(true);
                rituelmagie = true;
                Quete.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Vous sentez la magie influer en vous... Vous pouvez maintenant brûler et vous soigner ! Vous décidez de retouner au village avertir le villageois de ce culte secret. (Utilisez maintenant 3 et 4 du clavier pour changer de sort)";
                queteaffichee = true;
                UneQuete = 4;
                player.ActivableWeapon = 4;
            }
          
        }
        if (other.gameObject.name == "Character" && this.gameObject.name == "QueteFin")
        {
            Quete.transform.GetChild(0).gameObject.SetActive(true);
            Quete.transform.GetChild(1).gameObject.SetActive(true);
            Quete.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Le temps que vous arpentiez les zones enneigées, les villageois se sont fait attaquer par des adeptes du culte... au loin, la zone volcanique se réveille et gronde, vous vous sentez plus proche de la vérité que jamais";
            queteaffichee = true;
            UneQuete = 8;
        }
        if (other.gameObject.name == "Interactable" && Input.GetMouseButtonDown(1))
        {
            Quete.transform.GetChild(0).gameObject.SetActive(true);
            Quete.transform.GetChild(1).gameObject.SetActive(true);
            queteaffichee = true;

            switch (this.gameObject.name)
            {
                case "Quete1":
                    if (UneQuete == 0)
                    {
                        Quete.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Bonjour étranger, bienvenue dans notre village, j'ai entendu dire que vous étiez un fort guerrier venu se reposer ici pour un certains temps, cependant des événements étranges se produisent en ce moment, le climat change sans cesse et les animaux de la ferme environnante disparaissent les uns après les autres... Pourriez-vous allez vérifier ? Voici une épée et un arc au cas ou vous rencontriez des danger (Utilisez 1 et 2 pour changer d'arme)";
                        UneQuete = 1;
                        player.ActivableWeapon = 2;
                    }
                    if (UneQuete == 4)
                    {
                        Quete.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Des sorciers dans le cimetière vous me dites ? Quel malheur, c'est le culte du démon qui est revenu sur nos terres, ils disposaient d'un campement dans les terres du sud, près du lac. Cette région dégage une froideur inexplicable depuis quelque temps...";
                        UneQuete = 5;

                    }
                    



                    break;
                case "Quete2":
                    if (UneQuete == 1)
                    {
                        Quete.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Les animaux ont l'air d'avoir servis dans un sacrifice... Des morts sortis de leur tombe infestent le cimetière ! Il faut les éradiquer pour poursuivre.";
                        UneQuete = 2;
                    }
                    

                    break;
                case "Quete3":
                    if (spawnzombie.zombiemort >= 10 && UneQuete == 2)
                    {
                        obj.text = "";
                        opening = true;
                        player.exp += 150;
                        spawnzombie.zombiemort = 0;
                        Quete.transform.GetChild(1).gameObject.GetComponent<Text>().text = "La porte s'ouvre... Des gens sont en train de pratiquer une sorte de rituel...";
                        UneQuete = 3;

                    }

                    break;
                
                case "Quete5":

                    Quete.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Vous tombez sur un cadavre de géant prisonnié des glaces et en prime le lac est complètement gelé... Vous apercevez au loin des sectateurs en train de psalmodier une incantation, vous décidez de déblayez le chemin des zombies avant de vous aventurer sur la glace";
                    UneQuete = 6;
                    break;
                    
                default: break;
                    
            }
           

            print("bite");
        }
    }
}
