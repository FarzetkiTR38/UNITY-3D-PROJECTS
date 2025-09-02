using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data.Common;

public class UIManager : MonoBehaviour, ITimeTracker
{


    [Header("Status Bar")]
    public Image toolEquipedSlot;

    public TMP_Text timeText;
    public TMP_Text dateText;

    public HandInventorySlot toolHandSlot;
    public HandInventorySlot itemHandSlot;


    [Header("Inventory System")]
    public GameObject inventoryPanel;
    public InventorySlot[] toolSlots;
    public InventorySlot[] itemSlots;

    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    public static UIManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
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
        AssignSlotIndexes();

        TimeManager.instance.RegisterTracker(this);
    }

    public void AssignSlotIndexes()
    {
        for (int i = 0; i < toolSlots.Length; i++)
        {
            toolSlots[i].AssignIndex(i);
            itemSlots[i].AssignIndex(i);
        }
    }

    public void RenderInventory()
    {
        ItemData[] inventoryToolSlots = InventoryManager.instance.tools;
        ItemData[] inventoryItemSlots = InventoryManager.instance.items;
        RenderInventoryPanel(inventoryToolSlots, toolSlots);
        RenderInventoryPanel(inventoryItemSlots, itemSlots);


        toolHandSlot.Display(InventoryManager.instance.equippedTool);
        itemHandSlot.Display(InventoryManager.instance.equippedItem);


        ItemData equippedTool = InventoryManager.instance.equippedTool;

        if (equippedTool != null)
        {
            toolEquipedSlot.sprite = equippedTool.thumbnail;
            toolEquipedSlot.gameObject.SetActive(true);

            return;
        }

        toolEquipedSlot.gameObject.SetActive(false);
    }

    void RenderInventoryPanel(ItemData[] slots, InventorySlot[] uiSlots)
    {
        for (int i = 0; i < uiSlots.Length; i++)
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
        if (data == null)
        {
            itemNameText.text = "";
            itemDescriptionText.text = "";
            return;
        }
        itemNameText.text = data.name;
        itemDescriptionText.text = data.description;
    }


    public void ClockUpdate(GameTimestamp timestamp)
    {

        int hours = timestamp.hour;
        int minutes = timestamp.minute;

        string prefix = "AM ";

        if (hours > 11)
        {
            prefix = "PM ";
            hours -= 12;

        }

        timeText.text = prefix + hours.ToString() + ":" + minutes.ToString("00");

        int days = timestamp.day;
        string season = timestamp.season.ToString();
        string dayOfTheWeek = timestamp.GetDayOfTheWeek().ToString();

        dateText.text = season + " " + days.ToString() + "(" + dayOfTheWeek + ")";
    }







}
