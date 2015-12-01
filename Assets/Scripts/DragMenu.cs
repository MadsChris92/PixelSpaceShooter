using UnityEngine;
using System.Collections;

public class DragMenu : MonoBehaviour {

    public RectTransform panel;
    Vector3 hiddenPosition, shownPosition;
    Vector3 dragOffset;
    bool hidden = true;
    bool dragging = false;
    float dragDuration;

	// Use this for initialization
	void Start () {
        hiddenPosition = new Vector3(transform.position.x, transform.position.y);
        shownPosition = hiddenPosition + new Vector3(panel.rect.width, 0.0f);
	}

    // Update is called once per frame
    void Update() {
        if (dragging) {
            transform.position = new Vector3((Input.mousePosition+dragOffset).x, transform.position.y);
        } else {
            if (hidden) {
                transform.position = (hiddenPosition + transform.position) / 2;
            } else {
                transform.position = (shownPosition + transform.position) / 2;
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
            if (transform.position.x - hiddenPosition.x > (shownPosition.x - hiddenPosition.x) / 2) {
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
}
