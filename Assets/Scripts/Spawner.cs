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
        Debug.Log(time);
        if (time < 5 && count > 0.5)
        {
            spawnEnemy(0, 0);
            count = 0;
        }
	}

    void spawnEnemy(int enem, int pat)
    {
        GameObject clone = Instantiate(enemies[enem], paths[pat].transform.position, Quaternion.identity) as GameObject;
        clone.GetComponent<PathFollow>().path = paths[pat];
    }
}
