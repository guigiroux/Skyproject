using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class degatsjoueur : MonoBehaviour {
    public GameObject Feedback;
    public float timer;
	// Use this for initialization
	void Start () {
        Feedback = GameObject.Find("Feedback");

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Character")
        {
            print("bite");
            Feedback.transform.GetChild(0).gameObject.SetActive(true);

            Invoke("UIFalse", 0.8f);
            other.gameObject.GetComponent<PlayerScript>().PV -= 20;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f)
            {
                Feedback.transform.GetChild(0).gameObject.SetActive(true);

                Invoke("UIFalse", 0.74f);
                other.gameObject.GetComponent<PlayerScript>().PV -= 20;
                timer = 0;
            }
        }
    }
    void UIFalse()
    {
        Feedback.transform.GetChild(1).gameObject.SetActive(false);
        Feedback.transform.GetChild(0).gameObject.SetActive(false);

    }
}
