using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    
    ItemData itemToDisplay;
    int quantity;

    public Image itemDisplayImage;

    public TMP_Text quantityText;

    public enum InventoryType
    {
        Item, Tool
    }

    public InventoryType inventoryType;

    int slotIndex;

    public void Display(ItemSlotData itemSlot)
    {
        
        itemToDisplay = itemSlot.itemData;
        quantity = itemSlot.quantity;

        // default quantity text
        quantityText.text = "";

        if (itemToDisplay != null)
        {
            itemDisplayImage.sprite = itemToDisplay.thumbnail;

            if (quantity > 1)
            {
                quantityText.text = quantity.ToString();
            }


            itemDisplayImage.gameObject.SetActive(true);

            return;
        }

        itemDisplayImage.gameObject.SetActive(false);


    }

    // virtual yapıyoruz ki override edebilelim
    // pointer click eventini override edip farklı bir şey yapmasını sağlayacağız
    // virtual yapınca fonksiyon sanal olarak orada duruyor
    // override edince de o fonksiyonun içeriğini değiştiriyoruz
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        InventoryManager.instance.InventoryToHand(slotIndex, inventoryType); 
    }

    public void AssignIndex(int slotIndex)
    {
        this.slotIndex = slotIndex;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.instance.DisplayItemInfo(itemToDisplay);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.instance.DisplayItemInfo(null);
    }


}
