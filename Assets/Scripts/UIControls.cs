using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControls : MonoBehaviour {

    //Text status;
    public Text pointScore, calorieScore, distanceScore;
    public int calories = 862, kilometers = 13;
    public int points = 13*5;
    public static int controlls;

	// Use this for initialization
	void Start () {
        pointScore.text = "You've earned "+points+(points>1?" points":" point");
        calorieScore.text = /*"You have burned "+*/calories+" kcal";
        distanceScore.text = /*"You have travelled " + */kilometers + " km";
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
