using UnityEngine;
using UnityEngine.EventSystems;


public class HandInventorySlot : InventorySlot
{
    

    public override void OnPointerClick(PointerEventData eventData)
    {
        InventoryManager.instance.HandToInventory(inventoryType);
    }


}
