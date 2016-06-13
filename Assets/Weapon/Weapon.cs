using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    GameObject bullet;
    GameObject firePoint;

    public float range;

	// Use this for initialization
	void Start () {
	
	}
	
    public void shoot(bool direction)
    {
        Vector3 traj;

        if(direction)
        {
            traj = new Vector3(range, 0, 0);
        }
        else
        {
            traj = new Vector3(-range, 0, 0);
        }

        GameObject go = (GameObject) Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(traj);
    }

    public float getRange()
    {
        return range;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
