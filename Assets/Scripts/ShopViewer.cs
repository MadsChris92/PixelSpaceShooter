using UnityEngine;
using System.Collections;

public class ShopViewer : MonoBehaviour {

    public Item[] items;
    public GameObject itemPanelPrefab;

	// Use this for initialization
	void Start () {
        float x = 0;
        items = GetComponents<Item>();
        foreach (Item item in items) {
            GameObject panel = Instantiate(itemPanelPrefab);

            RectTransform panelTransform = panel.GetComponent<RectTransform>();
            panelTransform.SetParent(transform);
            panelTransform.localPosition = new Vector2(x+panelTransform.rect.width/2, -panelTransform.rect.height/2);
            x += panelTransform.rect.width;
            panelTransform.localScale = new Vector3(1, 1, 1);

            panel.GetComponent<ItemPanelScript>().SetItem(item);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
