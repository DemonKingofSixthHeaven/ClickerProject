using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCam;
    public GameObject toRemove;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        var rayHit = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider)
        {
            return;
        }

        MainItem mainItem = rayHit.collider.gameObject.GetComponent<MainItem>();

        if (mainItem != null)
        {
            Item item = mainItem.item;
            bool canAdd = InventoryManager.instance.AddItem(item);
            if (canAdd)
            {
                 toRemove = rayHit.collider.gameObject;
                 Destroy(toRemove);
            }
        }

        InventorySlot slot = rayHit.collider.GetComponent<InventorySlot>();
         InventoryItem slotDebug = rayHit.collider.GetComponent<InventoryItem>();
        

        if (slot != null)
        {
            int selectedNum = System.Array.IndexOf(InventoryManager.instance.inventorySlots, slot);
            InventoryManager.instance.ChangeSelectedSlot(selectedNum);
            if (slotDebug != null)
            {
                print(slotDebug.name);
            }

            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        }
        else
        {
            return;
        }
    }
}
