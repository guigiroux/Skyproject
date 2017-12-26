using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
public class LittleEnemy : MonoBehaviour
{   
    public Transform Player;
    public AudioClip damage, triggered;
    public PlayerScript playerscript;
    public GameObject Feedback;
    public Animator animator;
    public bool Attaque, death;
    public float TempsDamage, zlife;
    public int zlvl;
    int i = 0;
    public int j = 0;


    void Start()
    {
        Player = GameObject.Find("Character").transform;
        playerscript = Player.gameObject.GetComponent<PlayerScript>();
        animator = this.GetComponent<Animator>();
        Feedback = GameObject.Find("Feedback");
        switch(this.transform.tag)
        {
            case "ZombieFeu": this.zlife = 800; zlvl = 300;  break;
            case "ZombieGlace": this.zlife = 600; zlvl = 14;  break;
            case "Zombie": this.zlife = 100; zlvl = 8; break;

            case "SecteBase": this.zlife = 200; zlvl = 8; break;
            case "SecteDark": this.zlife = 500; zlvl = 14; break;
            case "SecteEth": this.zlife = 1000; zlvl = 300; break;

            default: this.zlife = 300; break;
        }

    }
    void Awake()
    {
        if (Time.time > .1f)
        {
            GetComponent<NavMeshAgent>().enabled = true;
        }

    }

    void Update()
    {
     
      if (j == 1)
        {
            this.GetComponent<NavMeshAgent>().destination = Player.position;

        }
        if (Attaque )
        {
            TempsDamage += Time.deltaTime;
            if(TempsDamage > 2)
            {
                Degats();
                TempsDamage = 0;
            }
        }
        if (zlife <= 0 && death == false)
        {
            death = true;
            UIFalse();
            animator.SetInteger("j", 3);
            Destroy(this.gameObject, 3 );
            GetComponent<NavMeshAgent>().enabled = false;
                if (this.transform.parent.parent.GetComponent<SpawnZombie>() != null) {
                this.transform.parent.parent.GetComponent<SpawnZombie>().zombiemort += 1; }
            if ( playerscript.lvl <= zlvl){
                playerscript.exp += 10;


            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.name)
        {
            case "Character":
                if (j == 1)
                {
                    j += 1;
                    animator.SetInteger("j", j);

                }
                if (j == 0 && this.gameObject.tag != "SecteDark"){

                    j += 1; animator.SetInteger("j", j);
                    if (this.GetComponent<AudioSource>().isPlaying == false)
                    {
                        this.GetComponent<AudioSource>().clip = triggered;
                        this.GetComponent<AudioSource>().Play();
                    }
                    
                }
                
        
                if (j == 2 && this.gameObject.tag != "SecteDark") { Attaque = true; }
                break;
        }
       
        
        
        

    }
    public void OnTriggerStay(Collider other)
    {
        if (j == 0 && this.gameObject.tag == "SecteDark" && other.gameObject.name == "Character")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            TempsDamage += Time.deltaTime;

            if (TempsDamage > 5)
            {
                DegatsDistance();
            }
            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Character" && this.gameObject.tag != "SecteDark")
        {
            TempsDamage = 0;
            j -= 1;
            animator.SetInteger("j", j);

            Attaque = false;
        }
        if (other.gameObject.name == "Character" && this.gameObject.tag == "SecteDark") { j = 0; this.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
  
    public void OnCollisionEnter(Collision other)
    {

     
        if (other.gameObject.name == "sword")
        {
            print("Serieuxla");
            zlife -= playerscript.force;
            animator.SetBool("degat", true);
            Invoke("DegatFalse", 1f);
            if (this.GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<AudioSource>().clip = damage;
                this.GetComponent<AudioSource>().Play();
            }


        }
        if (other.gameObject.name == "arrow(Clone)")
        {

            zlife -= playerscript.agi ;
            animator.SetBool("degat", true);
            Invoke("DegatFalse", 1f);
            if (this.GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<AudioSource>().clip = damage;
                this.GetComponent<AudioSource>().Play();
            }


        }
    }
   
    
    void OnParticleCollision(GameObject other)
    {
       if (other.gameObject.name == "flamme")
        {
            this.zlife -= playerscript.intel / 10;
            animator.SetBool("degat", true);
            Invoke("DegatFalse", 1f);
            this.GetComponent<AudioSource>().clip = damage;
            this.GetComponent<AudioSource>().Play();
        }

    }
    public void Degats()
    {
    
        switch (this.transform.tag)
        {
            case "ZombieFeu": playerscript.PV -= 40; break;
            case "ZombieGlace": playerscript.PV -= 70; break;
            case "Zombie": playerscript.PV -= 10; break;

            case "SecteBase": playerscript.PV -= 20; break;
            //   case "SecteDark": playerscript.PV -= 40; break;
            case "SecteEth": playerscript.PV -= 40; break;

            default: this.zlife = 300; break;
        }
        Feedback.transform.GetChild(0).gameObject.SetActive(true);

        Invoke("UIFalse", 0.8f);

    }
    public void DegatsDistance()
    {
        
    playerscript.PV -= 40;
    Invoke("UIFalse", 1.2f);
    Feedback.transform.GetChild(1).gameObject.SetActive(true);
    this.transform.GetChild(1).gameObject.SetActive(false);

        TempsDamage = 0;


    }
    void DegatFalse() {
        animator.SetBool("degat", false);
      
    }
    void UIFalse()
    {
        Feedback.transform.GetChild(1).gameObject.SetActive(false);
        Feedback.transform.GetChild(0).gameObject.SetActive(false);

    }
}