using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public GameObject projectile;
    public float shotsPerSecond;
    public bool alwaysFire = false;
    float fireDelay = 0;

	public void Fire() {
        if(fireDelay == 0) {
            fireDelay = 1 / shotsPerSecond;
            GameObject bull = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

        }
    }
	
	// Update is called once per frame
	void Update () {
        fireDelay = Mathf.Max(0, fireDelay-Time.deltaTime);
        if (alwaysFire) Fire();
	}
}
