using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ScriptBoss : MonoBehaviour {
    public GameObject Player;
    public Transform Floor, Floor1;
    public AudioClip jump, attack, degat, mort;
    public int phase, VieBoss, bloquage;
    public float timer, Trapped;
    public Animator animator;
    public NavMeshAgent Nav;
    public Animation anim;
    public Text obj;
    public string time;
    
	// Use this for initialization
	void Awake () {
        animator = this.GetComponent<Animator>();
        anim = this.GetComponent<Animation>();
        Player = GameObject.Find("Character");
        Invoke("Opening", 1.5f);
        Nav = this.GetComponent<NavMeshAgent>();
        Floor = GameObject.Find("Floor").transform;
        Floor1 = GameObject.Find("Floor1").transform;
        obj = GameObject.Find("objectif").GetComponent<Text>();
        timer = 60;


    }

    // Update is called once per frame
    void FixedUpdate () {
        if (bloquage == 3  || bloquage == 4)
        {
            Invoke("StopAttack", 1.2f);

        }
        if (bloquage == 0)
            {
                Nav.destination = Player.transform.position;
      

        }
            // transform.Translate(0, 0, Time.deltaTime * 15);
            if (bloquage == 1)
            {
            if (this.GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<AudioSource>().clip = degat;
                this.GetComponent<AudioSource>().Play();
            }
            Trapped += Time.deltaTime;
            Nav.enabled = false;
            animator.SetBool("Stomp", false);
            animator.SetBool("attack", false);
            if (Trapped <= 1.28f)
            {
                this.transform.position = new Vector3(Floor.position.x, Floor.position.y - 75, Floor.position.z);
               

                animator.SetBool("trapped", true);
            }

                if (Trapped >= 1.28f && Trapped <= 2.67f)
                {
                    this.transform.position = new Vector3(Floor.position.x, Floor.position.y, Floor.position.z);
                }
                if (Trapped >= 2.67f) 
                {
                    animator.SetBool("trapped", false);
                    this.transform.position = new Vector3(Floor.position.x  - 10, Floor.position.y + 75, Floor.position.z);
                    Floor.gameObject.SetActive(true);
                    Nav.enabled = true;
                    bloquage = 0;
                    Trapped = 0;
                }
                }

            
            if (bloquage == 2)
            {
            if (this.GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<AudioSource>().clip = degat;
                this.GetComponent<AudioSource>().Play();
            }
            Trapped += Time.deltaTime;
            Nav.enabled = false;
            animator.SetBool("Stomp", false);
            animator.SetBool("attack", false);
            if (Trapped <= 1.28f)
            {
                this.transform.position = new Vector3(Floor1.position.x, Floor1.position.y - 75, Floor1.position.z);
                animator.SetBool("trapped", true);
            }
                

                if (Trapped >= 1.28f && Trapped <= 2.67f)
                {
                  
                    this.transform.position = new Vector3(Floor1.position.x, Floor1.position.y, Floor1.position.z);
                }
                if (Trapped >= 2.67f)
                {
                    animator.SetBool("trapped", false);

                    this.transform.position = new Vector3(Floor1.position.x - 10, Floor1.position.y + 75, Floor1.position.z);
                  
                        Floor1.gameObject.SetActive(true);
                        Nav.enabled = true;
                        bloquage = 0;
                    Trapped = 0;
                    }  
            }
          
            if(bloquage == 5)
            {
                animator.SetBool("Stomp", false);
                animator.SetBool("attack", false);
                this.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);

                animator.SetBool("freeze", true);
             
                this.transform.GetChild(2).gameObject.SetActive(true);
                timer -= Time.deltaTime;
                obj.text = timer.ToString();
                Nav.enabled = false;


                if (timer <= 0 && bloquage != 6)
                {
                    animator.SetBool("damaged", false);

                    animator.SetBool("freeze", false);
                    this.transform.GetChild(2).gameObject.SetActive(false);
                    Nav.enabled = true;
                    obj.text = "";
                    timer = 60;
                    this.transform.GetChild(0).GetChild(7).GetChild(1).gameObject.GetComponent<SphereGel>().LifeCore = 500;
                    bloquage = 0;


                }
            }
            if(bloquage == 6)
            {
            Nav.enabled = false;
            timer = 0;

            obj.text = "";
            animator.SetBool("dead", true);
                this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.parent.GetChild(3).GetChild(0).gameObject.SetActive(true);

            if (this.GetComponent<AudioSource>().clip != mort)
            {
                this.GetComponent<AudioSource>().clip = mort;
                this.GetComponent<AudioSource>().Play();
            }


        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character" && bloquage == 0)
        {
            animator.SetBool("attack", true);
            this.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            bloquage = 3;
            Nav.enabled = false;
            if (this.GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<AudioSource>().clip = attack;
                this.GetComponent<AudioSource>().Play();
            }


            //animator.SetBool("attack", false);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Character" && bloquage == 0)
        {
            animator.SetBool("Stomp", true);
            Nav.enabled = false;
            this.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            bloquage = 4;

            if (this.GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<AudioSource>().clip = jump;
                this.GetComponent<AudioSource>().Play();
            }
        }
    }
    void Opening()
    {
        print("passé");
        //   this.transform.Translate(new Vector3(0, 0, +50f));
    }
    void StopAttack()
    {
     
        animator.SetBool("attack", false);
        animator.SetBool("Stomp", false);
        if (bloquage != 1 && bloquage != 2)
        {
            Nav.enabled = true;
            this.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            bloquage = 0;
        }


    }
}
