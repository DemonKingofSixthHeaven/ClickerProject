using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public Image image;
    public Color selectedColor, notSelectedColor;
    public Sprite selected, notSelected;
    private bool inThis;

    private void Awake()
    {
        Deselect();
    }

    private void Update()
    {
        int selectedNum = System.Array.IndexOf(InventoryManager.instance.inventorySlots, this);
        InventoryItem itemInSlot = GetComponentInChildren<InventoryItem>();
    }

    public void Select()
    {
        
       // image.sprite = selected;
    }

    public void Deselect()
    {
        
        //image.sprite = notSelected;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
