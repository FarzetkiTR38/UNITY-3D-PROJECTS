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

}
