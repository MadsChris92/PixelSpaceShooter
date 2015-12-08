using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPanelScript : MonoBehaviour {

    public string itemName, itemDesc;
    public Sprite itemIcon;
    Text uiName, uiDesc;
    Image uiImage;

	// Use this for initialization
	void Start () {
        Text[] stuff = GetComponentsInChildren<Text>();
        foreach (Text thing in stuff) {
            if(thing.name == "ItemName") {
                uiName = thing;
            } else if(thing.name == "ItemDesc") {
                uiDesc = thing;
            }
        }
        uiName.text = "your mom";
        uiDesc.text = "She is a very nice lady";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
