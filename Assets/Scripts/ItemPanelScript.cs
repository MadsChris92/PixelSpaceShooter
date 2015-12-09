using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPanelScript : MonoBehaviour {

    Item item;
    public Text uiTitle, uiDesc;
    public Image uiImage;

	// Use this for initialization
	void Start () {
        foreach (Text thing in GetComponentsInChildren<Text>()) {
            if(thing.name == "ItemName") {
                uiTitle = thing;
            } else if(thing.name == "ItemDesc") {
                uiDesc = thing;
            }
        }
        foreach (Image thing in GetComponentsInChildren<Image>()) {
            if (thing.name == "ItemImage") {
                uiImage = thing;
            }
        }

    }
	
    public void SetItem(Item item) {
        uiTitle.text = item.title;
        uiDesc.text = item.description;
        uiImage.sprite = item.icon;
        this.item = item;
    }
}
