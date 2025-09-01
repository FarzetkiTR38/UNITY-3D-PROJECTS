using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    
    ItemData itemToDisplay;

    public Image itemDisplayImage;

    public enum InventoryType
    {
        Item, tool
    }

    public InventoryType inventoryType;

    int slotIndex;

    public void Display(ItemData itemToDisplay)
    {


        if(itemToDisplay != null)
        {
            itemDisplayImage.sprite = itemToDisplay.thumbnail;
            this.itemToDisplay = itemToDisplay;
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
