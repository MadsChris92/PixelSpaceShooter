using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {
    bool instBG = true;
    bool move = false;
    public GameObject starBG;
    GameObject clone1, clone2, clone3, clone4;
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if(instBG == true)
        {
            clone1 = Instantiate(starBG, transform.position, Quaternion.identity) as GameObject;
            clone2 = Instantiate(starBG, transform.position, Quaternion.identity) as GameObject;
            clone3 = Instantiate(starBG, transform.position, Quaternion.identity) as GameObject;
            clone4 = Instantiate(starBG, transform.position, Quaternion.identity) as GameObject;


            clone3.transform.Rotate(180, 0, 0);
            clone4.transform.Rotate(180, 0, 0);
            clone2.transform.position = new Vector3(0, -0.5f, 0);
            clone3.transform.position = new Vector3(0, -0.5f, 0);
            instBG = false;
        }

        clone1.transform.position -= new Vector3(0, Time.deltaTime, 0);
        clone2.transform.position -= new Vector3(0, Time.deltaTime, 0);
        clone3.transform.position -= new Vector3(0, Time.deltaTime/3, 0);
        clone4.transform.position -= new Vector3(0, Time.deltaTime/3, 0);

        if (clone1.transform.position.y < -2 && clone1.transform.position.y > -2.2)
        {
            clone2.transform.position = new Vector3(0, transform.position.y + 5, 0);
        }

        if(clone1.transform.position.y < -16)
        {
            clone1.transform.position = new Vector3(0, transform.position.y + 5, 0);
        }



        if (clone4.transform.position.y < -2 && clone4.transform.position.y > -2.2)
        {
            clone3.transform.position = new Vector3(0, transform.position.y + 5, 0);
        }

        if (clone4.transform.position.y < -16)
        {
            clone4.transform.position = new Vector3(0, transform.position.y+ 5, 0);
        }

    }
}
