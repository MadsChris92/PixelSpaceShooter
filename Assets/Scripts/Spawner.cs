using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Path[] paths;
    public GameObject[] enemies;

    float time = 0, count = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        count += Time.deltaTime;

        spawnEnemy(0, 0, 0, 5, 0.5f);
	}

    void spawnEnemy(int enem, int pat, int minTim, int maxTim, float rate)
    {
        if (time > minTim && time < maxTim  && count > rate)
        {
            GameObject clone = Instantiate(enemies[enem], paths[pat].transform.position, new Quaternion(Quaternion.identity.x, Quaternion.identity.y, Quaternion.identity.z -180, 1)) as GameObject;
            clone.GetComponent<PathFollow>().path = paths[pat];
            count = 0;
        }
        
    }
}
