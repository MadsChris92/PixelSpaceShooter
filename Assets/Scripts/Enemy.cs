using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    float health;
	public enum enemyTypes {
        Weak, Middle, Strong,
    }
    public enemyTypes type;

	void Start () {
        if (type == enemyTypes.Weak)
        {
            health = 2;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if(c.transform.tag == "PlayerProjectile")
        {
            health -= c.gameObject.GetComponent<Projectile>().damage;
            if(health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
