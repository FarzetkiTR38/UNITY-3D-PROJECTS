using UnityEngine;
using UnityEngine.XR;

public class InventoryManager : MonoBehaviour
{
   
    public static InventoryManager instance {get; private set; }

    private void Awake() 
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }    
        else
        {
            instance = this;
        }
    }

    [Header("Tools")]
    [SerializeField]
    private ItemSlotData[] toolSlots = new ItemSlotData[8]; // 8 slotlu tools inventory
    [SerializeField]
    private ItemSlotData equippedToolSlot = null;

    [Header("Items")]
    [SerializeField]
    private ItemSlotData[] itemSlots = new ItemSlotData[8]; // 8 slotlu items inventory
    [SerializeField]
    private ItemSlotData equippedItemSlot = null;

    public Transform handPoint;

    public void InventoryToHand(int slotIndex, InventorySlot.InventoryType inventoryType)
    {
        /*
        if (inventoryType == InventorySlot.InventoryType.Item)
        {
            ItemData itemToEquip = itemSlots[slotIndex];

            itemSlots[slotIndex] = equippedItemSlot;

            equippedItemSlot = itemToEquip;

            RenderHand();
        }
        else
        {
            ItemData toolToEquip = toolSlots[slotIndex];

            toolSlots[slotIndex] = equippedToolSlot;

            equippedToolSlot = toolToEquip;
        }

        UIManager.instance.RenderInventory();


        */
    }
    
    public void RenderHand()
    {
        
        if(handPoint.childCount > 0)
        {
            
            Destroy(handPoint.GetChild(0).gameObject);
            
        }


        if (equippedItemSlot != null)
        {
            Instantiate(GetEquippedSlotItem(InventorySlot.InventoryType.Item).gameModel, handPoint);
        }
        
    }

    public ItemData GetEquippedSlotItem(InventorySlot.InventoryType inventoryType)
    {
        if(inventoryType == InventorySlot.InventoryType.Item)
        {
            return equippedItemSlot.itemData;
        }

        return equippedToolSlot.itemData;
        
    }
    public ItemSlotData GetEquippedSlot(InventorySlot.InventoryType inventoryType)
    {
        if(inventoryType == InventorySlot.InventoryType.Item)
        {
            return equippedItemSlot;
        }

        return equippedToolSlot;
        
    }

    public ItemSlotData[] GetInventorySlots(InventorySlot.InventoryType inventoryType)
    {
        if(inventoryType == InventorySlot.InventoryType.Item)
        {
            return itemSlots;
        }

        return toolSlots;
        
    }

    public bool SlotEquipped(InventorySlot.InventoryType inventoryType)
    {
        if(inventoryType == InventorySlot.InventoryType.Item)
        {
            return equippedItemSlot != null;
        }

        return equippedToolSlot != null;
        
    }

    public bool IsTool(ItemData item)
    {
        EquipmentData equipment = item as EquipmentData;

        if (equipment != null)
        {
            return true;
        }

        SeedData seed = item as SeedData;
        return seed != null;
    }
    public void EquipEmptySlot(ItemData item)
    {
        if (IsTool(item))
        {
            equippedToolSlot = new ItemSlotData(item);

        }
        else
        {
            equippedItemSlot = new ItemSlotData(item);
        }

        

    }

    void OnValidate()
    {
        ValidateInventorySlot(equippedToolSlot);
        ValidateInventorySlot(equippedItemSlot);

        ValidateInventorySlots(toolSlots);
        ValidateInventorySlots(itemSlots);
    }

    void ValidateInventorySlot(ItemSlotData slot)
    {
        if (slot.itemData != null && slot.quantity == 0)
        {
            slot.quantity = 1;
        }
    }

     void ValidateInventorySlots(ItemSlotData[] array)
    {
        foreach (ItemSlotData slot in array)
        {
            ValidateInventorySlot(slot);
        }
    }



    public void HandToInventory(InventorySlot.InventoryType inventoryType)
    {
        /*
        if (inventoryType == InventorySlot.InventoryType.Item)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i] == null)
                {
                    itemSlots[i] = equippedItemSlot;
                    equippedItemSlot = null;
                    break;
                }
            }

            RenderHand();
        }
        else
        {
            for (int i = 0; i < toolSlots.Length; i++)
            {
                if (toolSlots[i] == null)
                {
                    toolSlots[i] = equippedToolSlot;
                    equippedToolSlot = null;
                    break;
                }
            }
        }

        UIManager.instance.RenderInventory();
        */
    }

}
