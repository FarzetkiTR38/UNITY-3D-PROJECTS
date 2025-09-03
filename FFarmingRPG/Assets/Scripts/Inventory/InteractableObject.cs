using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    public ItemData item;

    public void PickUp()
    {

        InventoryManager.instance.equippedItem = item;
        
        InventoryManager.instance.RenderHand();

        Destroy(gameObject);
    }


}
