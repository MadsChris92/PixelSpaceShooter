using UnityEngine;
using System.Collections;

public class PathFollow : MonoBehaviour {

    public Path path;
    int currentPoint = 0;
    public float closeEnough = 0.1f;
    public float speed = 2.0f;
    [Range(0.0f, 1.0f)]
    public float inertia = 0.2f;

    // Update is called once per frame
    void Update () {
	    if(currentPoint < path.points.Length) {
            if(Vector3.Distance(transform.position, path.points[currentPoint].position) < closeEnough) {
                currentPoint += 1;
            } else {
                //transform.position = Vector3.MoveTowards(transform.position, path.points[currentPoint].position, speed);
                GetComponent<Rigidbody>().velocity = Vector3.Lerp(GetComponent<Rigidbody>().velocity, (path.points[currentPoint].position - transform.position).normalized * speed, inertia);
            }
        } else {
            if (path.loops) currentPoint = 0;
       else Destroy(gameObject);
        }
	}
}
