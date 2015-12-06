using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float shotSpeed = 2;
    public float lifeSpan = 1;
    public float damage = 1;
    public enum bulletType{
        enemyBullet, playerBullet
    }
    public bulletType bType;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeSpan);
        if(bType == bulletType.playerBullet)
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * shotSpeed;
        }
        if (bType == bulletType.enemyBullet)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * shotSpeed;
        }


    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
