﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    private float rotationHorizontal = 0f, moveHorizontal, moveVertical;
    public float movementSpeed = 0, rotationSpeed = 0;
    Animator anim;
    public float fireRate = 1;
    float counter;
    int alt = 0;
    public Transform[] bulletSpawn;
    public GameObject bullet;

    void Start () {
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        counter += Time.deltaTime;
     if(counter > fireRate && alt == 1)
        {
            Debug.Log("test");
            GameObject clone = Instantiate(bullet, bulletSpawn[alt].transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 700);
            counter = 0;
            alt--;
        }
        if (counter > fireRate && alt == 0)
        {
            Debug.Log("test");
            GameObject clone = Instantiate(bullet, bulletSpawn[alt].transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 700);
            counter = 0;
            alt++;
        }


        keyboardControl();
        rotationManager();
    }

    void rotationManager()
    {
        rotationHorizontal = Mathf.Clamp(rotationHorizontal, -20, 20);
        if (moveHorizontal > 0)
        {
            rotationHorizontal -= rotationSpeed;
            transform.localEulerAngles = new Vector3(0, 0, rotationHorizontal);
        }
        if (moveHorizontal < 0)
        {
            rotationHorizontal += rotationSpeed;
            transform.localEulerAngles = new Vector3(0, 0, rotationHorizontal);
        }
        if (moveHorizontal == 0)
        {
            rotationHorizontal = Mathf.Lerp(rotationHorizontal, 0, Time.deltaTime * 2);
            transform.localEulerAngles = new Vector3(0, 0, rotationHorizontal);
        }
    }

    void keyboardControl()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * movementSpeed;
        moveVertical = Input.GetAxisRaw("Vertical") * movementSpeed;
        transform.position += new Vector3(moveHorizontal, moveVertical, 0);
        if(moveVertical > 0)
        {
            anim.SetBool("Boost", true);
        }
        else
        {
            anim.SetBool("Boost", false);
        }
    }
}
