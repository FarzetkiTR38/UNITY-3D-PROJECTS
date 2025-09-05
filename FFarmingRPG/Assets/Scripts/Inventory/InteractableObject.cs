using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    public ItemData item;

    public virtual void PickUp()
    {

        InventoryManager.instance.equippedItem = item;
        
        InventoryManager.instance.RenderHand();

        Destroy(gameObject);
    }


}
