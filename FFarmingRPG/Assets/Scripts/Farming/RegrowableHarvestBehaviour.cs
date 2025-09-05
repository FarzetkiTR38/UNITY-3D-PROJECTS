using UnityEngine;

public class RegrowableHarvestBehaviour : InteractableObject
{


    CropBehaviour parentCrop;

    public void SetParent(CropBehaviour parentCrop)
    {
        this.parentCrop = parentCrop;
    }

    public override void PickUp()
    {
        InventoryManager.instance.equippedItem = item;

        InventoryManager.instance.RenderHand();

        parentCrop.Regrow();
        
        print("pickup fnc çalıştı");





    }
}
