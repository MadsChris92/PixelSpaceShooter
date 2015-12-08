using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public GameObject projectile, barrel;
    GameObject player;
    public float shotsPerSecond;
    public bool isLaser = false;
    public Transform[] bulletSpawns;
    AudioSource audioSource;
    float fireDelay = 0;
    Vector3 _dir;

    public FireType fireType = FireType.All;
    public enum FireType {
        Alternate,
        All,
        Barrel
    }
    int fireAlt = 0;

    void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Fire() {
        if(fireDelay == 0) {
            if (audioSource != null) {
                audioSource.Play();
            }
            if (shotsPerSecond > 0)
                fireDelay = 1 / shotsPerSecond;

            if (fireType == FireType.All) {
                foreach (Transform spawn in bulletSpawns) {
                    GameObject clone = (GameObject) Instantiate(projectile, spawn.position, spawn.rotation);
                    if (isLaser) clone.transform.SetParent(transform);
                }
            }
            else if(fireType == FireType.Alternate) {
                GameObject clone = (GameObject) Instantiate(projectile, bulletSpawns[fireAlt].position, bulletSpawns[fireAlt].rotation);
                if (isLaser) clone.transform.SetParent(transform);
                fireAlt = (fireAlt + 1) % bulletSpawns.Length;
            }
            else if(fireType == FireType.Barrel) {
                GameObject clone = Instantiate(projectile, bulletSpawns[0].position, barrel.transform.rotation) as GameObject;
                if (isLaser) clone.transform.SetParent(barrel.transform);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(fireType == FireType.Barrel)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Vector3 targetDir = player.transform.position - barrel.transform.position;
            Vector3 newDir = Vector3.RotateTowards(barrel.transform.position, targetDir, 5, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            //barrel.transform.rotation = Quaternion.LookRotation(newDir);
            barrel.transform.up = newDir;

        }
        
        fireDelay = Mathf.Max(0, fireDelay-Time.deltaTime);
	}
}
