using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    int health;
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
            health--;
            if(health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
