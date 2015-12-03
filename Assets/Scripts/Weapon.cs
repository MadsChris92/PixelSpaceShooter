using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public GameObject projectile;
    public float shotsPerSecond;
    public Transform[] bulletSpawns;
    AudioSource audioSource;
    float fireDelay = 0;

    public FireType fireType = FireType.All;
    public enum FireType {
        Alternate,
        All
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
                    Instantiate(projectile, spawn.position, spawn.rotation);
                }
            } else if(fireType == FireType.Alternate) {
                Instantiate(projectile, bulletSpawns[fireAlt].position, bulletSpawns[fireAlt].rotation);
                fireAlt = (fireAlt + 1) % bulletSpawns.Length;
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
        fireDelay = Mathf.Max(0, fireDelay-Time.deltaTime);
	}
}
