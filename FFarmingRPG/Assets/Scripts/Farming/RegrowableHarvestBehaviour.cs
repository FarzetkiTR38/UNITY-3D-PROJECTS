using UnityEngine;

public class RegrowableHarvestBehaviour : InteractableObject
{

    CropBehaviour parentCrop;

    public void SetParent(CropBehaviour parentCrop)
    {
        this.parentCrop = parentCrop;
        print("setparent fnc çalıştı");
    }

    public override void PickUp()
    {
        InventoryManager.instance.EquipEmptySlot(item);

        InventoryManager.instance.RenderHand();

        parentCrop.Regrow();
        
        print("pickup fnc çalıştı");
    }
}
