using UnityEngine;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {

    public float shotSpeed = 2;
    public float lifeSpan = 1;
    public float damage = 1;
    public GameObject hitSpark;
    public List<Mod> mods;
    public enum bulletType{
        enemyBullet, playerBullet
    }
    public bulletType bType;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeSpan);
        GetComponent<Rigidbody2D>().velocity = transform.up * shotSpeed;
    }

    void Update() {
        transform.up = GetComponent<Rigidbody2D>().velocity.normalized;
        foreach (Mod mod in mods) {
            mod.OnUpdate();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (bType == bulletType.playerBullet && other.transform.tag == "Enemy") {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            if (hitSpark != null) Instantiate(hitSpark, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
