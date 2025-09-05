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
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3))
        {
            OnInteractableHit(hit);
            
            print("ray çarptı");
        }
    }

    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        if (other.tag == "Land")
        {
            LandController land = other.GetComponent<LandController>();
            print("şu an landın üstündesin");
            SelectLand(land);
            return;
        }

        if (other.tag == "Item")
        {
            selectedInteractable = other.GetComponent<InteractableObject>();
            print("şu an itemin üstündesin");
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

        if(InventoryManager.instance.equippedTool == null)
        {
            return;
        }

        if (selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }
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
        }

    }




}