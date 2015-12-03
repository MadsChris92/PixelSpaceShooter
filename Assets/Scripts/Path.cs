using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {

    public bool loops = false;
    public Transform[] points;

    public void OnDrawGizmos() {
        if (points.Length > 0) {
            for (int i = 1; i < points.Length; i++) {
                Gizmos.DrawLine(points[i - 1].position, points[i].position);
            }
            if (loops) {
                Gizmos.DrawLine(points[points.Length - 1].position, points[0].position);
            }
        }
    }
}
