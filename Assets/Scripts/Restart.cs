using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
    public void RestartScene() {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
