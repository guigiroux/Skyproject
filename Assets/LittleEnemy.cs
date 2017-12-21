using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
public class LittleEnemy : MonoBehaviour
{   
    public Transform Player;
    public PlayerScript playerscript;
    public Animator animator;
    public bool Activate, Attaque, burning;
    public float TempsDamage;
    public int zlife, zlvl;
    int i = 0;
    public int j = 0;


    void Start()
    {
        Player = GameObject.Find("Character").transform;
        playerscript = Player.gameObject.GetComponent<PlayerScript>();
        animator = this.GetComponent<Animator>();
        switch(this.transform.parent.parent.name)
        {
            case "SpawnFire": this.zlife = 800; zlvl = 300;  break;
            case "SpawnGlace": this.zlife = 600; zlvl = 14;  break;
            case "Spawnz": this.zlife = 100; zlvl = 8; break;
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
        if (Activate == true)
        {
            this.GetComponent<NavMeshAgent>().destination = Player.position;
         
        }
      
        if (Attaque )
        {
            this.GetComponent<NavMeshAgent>().destination = this.transform.position;

            TempsDamage += Time.deltaTime;
            if(TempsDamage > 2)
            {
                Degats();
                TempsDamage = 0;
            }
        }
        if (zlife <= 0 )
        {
            animator.SetInteger("j", 3);
            Destroy(this.gameObject, 3 );

           if( playerscript.lvl <= zlvl){
                playerscript.exp += 10;

            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.name == "Character" && j == 1 )
        {
            j += 1;
            animator.SetInteger("j", j);

        }
        if (other.gameObject.name == "Character" && j == 2)

        {
            if (this.gameObject.GetComponent<NavMeshAgent>().speed != 0)
            {

                Attaque = true;
            }
        }
        if (other.gameObject.name == "Character" && j == 0)
        {
            j += 1;
            animator.SetInteger("j", j);

            Activate = true;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            TempsDamage = 0;
            j -= 1;
            animator.SetInteger("j", j);

            Attaque = false;
        }

    }
  
    public void OnCollisionEnter(Collision other)
    {

     
        if (other.gameObject.name == "sword" && i == 0)
        {

            GetComponent<AudioSource>().Play();
            zlife -= playerscript.force;
            
            i = 1;

        }
        if (other.gameObject.name == "arrow(Clone)")
        {
            GetComponent<AudioSource>().Play();
            zlife -= playerscript.agi ;
            i = 1;

        }
    }
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "sword" && i == 1)
        {
            i = 0;

        }
    }
    void OnParticleCollision(GameObject other)
    {
       

    }
    public void Degats()
    {
        switch (this.transform.parent.parent.name)
        {
            case "SpawnFire": playerscript.PV -= 40; break;
            case "SpawnGlace": playerscript.PV -= 70; break;
            case "Spawnz": playerscript.PV -= 10; break;

        }
    }
}