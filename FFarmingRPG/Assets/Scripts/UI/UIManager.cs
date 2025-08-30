using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [Header("Inventory System")]
    public GameObject inventoryPanel;
    public InventorySlot[] toolSlots;
    public InventorySlot[] itemSlots;

    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    public static UIManager instance { get; private set; }

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

    private void Start()
    {
        RenderInventory();    
    }

    public void RenderInventory()
    {
        ItemData[] inventoryToolSlots = InventoryManager.instance.tools;
        ItemData[] inventoryItemSlots = InventoryManager.instance.items;
        RenderInventoryPanel(inventoryToolSlots, toolSlots);
        RenderInventoryPanel(inventoryItemSlots, itemSlots);
    }

    void RenderInventoryPanel(ItemData[] slots, InventorySlot[] uiSlots)
    {
        for(int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Display(slots[i]);
        }


    }

    public void ToggleInventoryPanel()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        
        RenderInventory();
    }

    public void DisplayItemInfo(ItemData data)
    {
        if(data == null)
        {
            itemNameText.text = "";
            itemDescriptionText.text = "";
            return;
        }
        itemNameText.text = data.name;
        itemDescriptionText.text = data.description;
    }

    

    




}
