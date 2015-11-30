using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {
    public Transform[] starSpawm;
    int randomPos, randomSpeed;
    float count = 0;
    public GameObject star;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        Debug.Log(count);
        if (count > 1)
        {
            randomSpeed = Random.Range(1,100);
            randomPos = Random.Range(0, 8);
            GameObject clone = Instantiate(star, starSpawm[randomPos].transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(Vector3.down * 10 * randomSpeed);
            count = 0;
        }
        if (count > 0.5f)
        {
            randomSpeed = Random.Range(1, 100);
            randomPos = Random.Range(0, 8);
            GameObject clone = Instantiate(star, starSpawm[randomPos].transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(Vector3.down * 10 * randomSpeed);
            count = 0;
        }
        if (count > 0.3f)
        {
            randomSpeed = Random.Range(1, 100);
            randomPos = Random.Range(0, 8);
            GameObject clone = Instantiate(star, starSpawm[randomPos].transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(Vector3.down * 10 * randomSpeed);
            count = 0;
        }

    }
}
