using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float shotSpeed = 2;
    public float lifeSpan = 1;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeSpan);
        GetComponent<Rigidbody2D>().velocity = transform.up * shotSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
