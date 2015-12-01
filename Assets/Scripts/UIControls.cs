using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControls : MonoBehaviour {

    //Text status;
    public Text status, kalorier;
    public static int controlls;

	// Use this for initialization
	void Start () {
        status.text = "Du har optjent 100 point";
        kalorier.text = "Du har forbrændt 250 kcal";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadOverviewScene()
    {
        Application.LoadLevel("Overview");
    }

    public void loadLevel1()
    {
        Application.LoadLevel("Scene1");
    }
    public void setKeyboard()
    {
        controlls = 0;
    }
    public void setAndroid()
    {
        controlls = 1;
    }
}
