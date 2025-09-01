using UnityEngine;

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
    public ItemData[] tools = new ItemData[8]; // 8 slotlu tools inventory
    public ItemData equippedTool = null;

    [Header("Items")]
    public ItemData[] items = new ItemData[8]; // 8 slotlu items inventory
    public ItemData equippedItem = null;

    public void InventoryToHand(int slotIndex, InventorySlot.InventoryType inventoryType)
    {
        
        if(inventoryType == InventorySlot.InventoryType.Item)
        {
            ItemData itemToEquip = items[slotIndex];

            items[slotIndex] = equippedItem;

            equippedItem = itemToEquip;
        }
        else 
        {
            ItemData toolToEquip = tools[slotIndex];

            tools[slotIndex] = equippedTool;

            equippedTool = toolToEquip;
        }

        UIManager.instance.RenderInventory();
    


    }

    public void HandToInventory(InventorySlot.InventoryType inventoryType)
    {

        if(inventoryType == InventorySlot.InventoryType.Item)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if(items[i] == null)
                {
                    items[i] = equippedItem;
                    equippedItem = null;
                    break;
                }
            }
        }
        else 
        {
            for(int i = 0; i < tools.Length; i++)
            {
                if(tools[i] == null)
                {
                    tools[i] = equippedTool;
                    equippedTool = null;
                    break;
                }
            }            
        }

        UIManager.instance.RenderInventory();

    }

}
