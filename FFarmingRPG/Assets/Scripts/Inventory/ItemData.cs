using UnityEngine;

// MonoBehaviour scripti sahneye bağlı olan scriptler oluyormuş,
// ScriptableObject yani üst sınıf olarak belirtilen scriptler ise sahneye bağlı değil projeye bağlıdır.
// kalıcı olmasını istediğimiz şeyleri ScriptableObject ile yapacağız


[CreateAssetMenu(menuName = "Items/Item")]
public class ItemData : ScriptableObject
{

    public string description;

    public Sprite thumbnail;

    public GameObject gameModel;



}
