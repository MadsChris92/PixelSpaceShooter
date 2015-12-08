using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public float lifeSpan = 1;
    public float damagePerSecond = 1;
    float damage;
    public enum Team {
        player, enemy, fuckTheWorld
    }
    public Team team;
    public float range = 5.0f;
    public GameObject start, mid, end;
    GameObject target;
    bool stopFiring = false;
    Animator animator;
    float startTime;


	// Use this for initialization
	void Start () {
        damage = damagePerSecond * Time.deltaTime;
        animator = GetComponent<Animator>();
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D raycast;
        if (team == Team.player) {
            raycast = Physics2D.Raycast(transform.position, transform.up, range, LayerMask.GetMask("Enemy"));
        } else if (team == Team.enemy) {
            raycast = Physics2D.Raycast(transform.position, transform.up, range, LayerMask.GetMask("Player"));
        } else {
            raycast = Physics2D.Raycast(transform.position, transform.up, range);
        }
        float length;
        if(raycast.collider == null) {
            length = range;
            target = null;
        } else {
            length = raycast.distance;
            length = Mathf.Max(length, 0.31f);
            target = raycast.collider.gameObject;
            if(team == Team.player)
                target.GetComponent<Enemy>().TakeDamage(damage);
        }

        end.transform.localPosition = new Vector2(0, length);
        mid.transform.localPosition = new Vector2(0, length/2);
        mid.transform.localScale = new Vector2(1, (length - 0.31f) / 0.31f);

        if (Time.time-startTime > lifeSpan && stopFiring == false) {
            stopFiring = true;
            animator.SetBool("Done", true);
        }
    }
}
