using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour {
    public GameObject Zombie, zombie;
    public Transform North, South, West, East, SpawnZ;
    public int i, zombiemort;
    public float timer;
	// Use this for initialization
	void Start () {

        North = this.transform.Find("North");
        East = this.transform.Find("East");
        West = this.transform.Find("West");
        South = this.transform.Find("South");
        SpawnZ = this.transform.Find("SpawnZombie");

    }

    // Update is called once per frame
    void Update () {
        i = SpawnZ.transform.childCount;
 
            if(i != 5)
            {
            timer += Time.deltaTime;
            }
        
        if (timer > 5)
        {
            Spawn();
            
        }
	}
    void Spawn()
    {
        GameObject zombie = Instantiate(Zombie, new Vector3(Random.Range(West.position.x, East.position.x),0,Random.Range(North.position.z, South.position.z)), Quaternion.identity);
        zombie.transform.parent = SpawnZ.transform;

        timer = 0;

    }
}
