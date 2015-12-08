using UnityEngine;
using System.Collections;

public class DragMenu : MonoBehaviour {

    public RectTransform panel;
    public Transform hiddenTransform, shownTransform;
    Vector3 dragOffset;
    bool hidden = true;
    bool dragging = false;
    float dragDuration;

    // Update is called once per frame
    void Update() {
        if (dragging) {
            transform.position = new Vector3((Input.mousePosition+dragOffset).x, transform.position.y);
        } else {
            if (hidden) {
                transform.position = (hiddenTransform.position + transform.position) / 2;
            } else {
                transform.position = (shownTransform.position + transform.position) / 2;
            }
        }
	}

    public void startDrag() {
        dragOffset = transform.position - Input.mousePosition;
        dragging = true;
        dragDuration = Time.time;
    }

    public void endDrag() {
        dragDuration = Time.time - dragDuration;
        if(dragDuration < 0.2f) {
            toggleHidden();
        } else {
            if (transform.position.x - hiddenTransform.position.x > (shownTransform.position.x - hiddenTransform.position.x) / 2) {
                hidden = false;
            } else {
                hidden = true;
            }
        }
        dragging = false;
    }

    void toggleHidden() {
        hidden = !hidden;
    }

    public void loadStatusScene() {
        Application.LoadLevel("StatusScreen");
    }

    public void loadShopScene() {
        Application.LoadLevel("ShopScreen");
    }

    public void loadLevel1() {
        Application.LoadLevel("Scene1");
    }
}
