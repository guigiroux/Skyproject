using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptmonolithe : MonoBehaviour
{

    
    // Use this for initialization
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Character" &&  QueteScript.UneQuete == 7 )
        {
            if (this.transform.GetChild(5).transform.position.y > 170)
            {
                this.transform.GetChild(5).Translate(Vector3.down * Time.deltaTime * 50, Space.World);
                this.transform.parent.GetChild(3).gameObject.SetActive(true);
            }
        }
        if (QueteScript.UneQuete == 7 && this.transform.parent.GetChild(3).childCount == 0) 
        {
            if (this.transform.GetChild(5).transform.position.y < 300)
            {
                this.transform.GetChild(5).Translate(Vector3.up * Time.deltaTime * 50, Space.World);
            }
            GameObject.Find("Neige").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Neige").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.Find("Neige").transform.GetChild(3).gameObject.SetActive(true);
            GameObject.Find("TerrainZoneBase").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.Find("TerrainZoneBase").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find("TerrainZoneBase").transform.GetChild(4).gameObject.SetActive(true);



            QueteScript.UneQuete = 7;
            
        }
    }

}
