using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    private float rotationHorizontal = 0f, moveHorizontal, moveVertical;
    public float movementSpeed = 0, rotationSpeed = 0;
    public Dragging drag;
    Animator anim;
    public Weapon[] weapons;

    void Start () {
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Weapon weapon in weapons) {
            weapon.Fire();
        }
        rotationManager();
        /*
        if(Application.platform == RuntimePlatform.Android)
        {
            
        }
        else
        {
            keyboardControl();
        }
        */
        
        appControl();
      
    }

    void appControl()
    {
        if (drag.clicked)
        {
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
//            transform.position = curPosition;
            transform.position = transform.position - drag.transform.position + curPosition;
        }
        
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
