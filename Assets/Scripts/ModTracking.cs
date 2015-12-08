using UnityEngine;
using System.Collections;
using System;

public class ModTracking : Mod {
    [Range(0.0f, 1.0f)]
    public float trackForce = 0.05f;
    public float trackRange = 5.0f;
    GameObject closestEnemy = null;
    public override void OnUpdate () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        closestEnemy = null;
        float distanceToClosest = trackRange;
        foreach (GameObject enemy in enemies) {
            if (Vector2.Distance(enemy.transform.position, transform.position) < distanceToClosest) {
                closestEnemy = enemy;
                distanceToClosest = Vector2.Distance(enemy.transform.position, transform.position);
            }
        }
        if(closestEnemy != null) {
            Vector3 futureEnemyPosition = closestEnemy.transform.position + (Vector3)closestEnemy.GetComponent<Rigidbody2D>().velocity*Time.deltaTime*Vector2.Distance(transform.position, closestEnemy.transform.position)*5;
            //GetComponent<Rigidbody2D>().AddForce((futureEnemyPosition-transform.position).normalized*trackForce);
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.velocity = Vector3.Lerp(body.velocity, (futureEnemyPosition - transform.position).normalized * GetComponent<Projectile>().shotSpeed, trackForce);
        }
	}

    public override void OnStart() {
    }

    public override void OnHit() {
    }
}
