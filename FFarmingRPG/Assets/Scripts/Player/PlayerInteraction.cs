using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{



    PlayerController playerController;

    LandController selectedLand = null;

    InteractableObject selectedInteractable = null;

    void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit);
        }
    }

    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        if (other.tag == "Land")
        {
            LandController land = other.GetComponent<LandController>();
            print("land getcomponent çalıştı");
            SelectLand(land);
            return;
        }

        if (other.tag == "Item")
        {
            selectedInteractable = other.GetComponent<InteractableObject>();
            print("Item getcomponent çalıştı");
            return;
            
        }

        if (selectedInteractable != null)
        {
            selectedInteractable = null;
        }

        if (selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }
    }

    void SelectLand(LandController land)
    {

        if (selectedLand != null)
        {
            selectedLand.Select(false);
        }

        selectedLand = land;
        land.Select(true);



    }

    public void Interact()
    {

        if(InventoryManager.instance.equippedTool != null)
        {
            return;
        }

        if (selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }

        Debug.Log("Not on any land ");
    }


    // playercontroller içinden çağrılacak
    // sağ tık ile itemi envantere koyacak elinden alınmış olacak
    public void ItemInteract()
    {


        if (InventoryManager.instance.equippedItem != null)
        {
            InventoryManager.instance.HandToInventory(InventorySlot.InventoryType.Item);
            return;
        }

        if (selectedInteractable != null)
        {
            selectedInteractable.PickUp();
            print("Bir şeyler almaya çalışıyoz da olmuyor awk ");
        }

    }




}
