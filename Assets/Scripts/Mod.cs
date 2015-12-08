using UnityEngine;
using System.Collections;

public abstract class Mod : MonoBehaviour {

    // Use this for initialization
    public abstract void OnStart();

    // Update is called once per frame
    public abstract void OnUpdate();

    public abstract void OnHit();
}
