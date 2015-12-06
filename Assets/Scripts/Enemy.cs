using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject explosion;

    float health=4;
    public Weapon[] weapons;
	public enum enemyTypes {
        Weak, Middle, Strong,
    }
    public enemyTypes type;

	void Start () {
        if (type == enemyTypes.Weak)
        {
            health *= 0.5f;
        }
        if (type == enemyTypes.Middle) {
            health *= 1.0f;
        }
        if (type == enemyTypes.Strong) {
            health *= 2.0f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        foreach (Weapon weapon in weapons)
        {
            weapon.Fire();
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "PlayerProjectile") {
            health -= other.gameObject.GetComponent<Projectile>().damage;
            if (health <= 0) {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
