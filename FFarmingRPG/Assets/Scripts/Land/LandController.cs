using JetBrains.Annotations;
using UnityEngine;

public class LandController : MonoBehaviour, ITimeTracker
{


    public enum LandStatus
    {
        Soil, Farmland, Watered
    }


    public Material soilMat, farmlandMat, wateredMat;

    public LandStatus landStatus;

    new Renderer renderer;

    public GameObject select;

    GameTimestamp timeWatered;

    [Header("Crops")]
    public GameObject cropPrefab;

    CropBehaviour cropPlanted = null;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(LandStatus.Soil);

        Select(false);

        TimeManager.instance.RegisterTracker(this);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;

        Material materialToSwitch = soilMat;

        switch (statusToSwitch)
        {
            case LandStatus.Soil:
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farmland:
                materialToSwitch = farmlandMat;
                break;
            case LandStatus.Watered:
                materialToSwitch = wateredMat;
                timeWatered = TimeManager.instance.GetGameTimestamp();
                break;
        }



        renderer.material = materialToSwitch;
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    public void Interact()
    {
        ItemData toolSlot = InventoryManager.instance.equippedTool;
        
        if (toolSlot == null)
        {
            return;
        }

        EquipmentData equipmentData = toolSlot as EquipmentData;
        // as operatörü, güvenli tip dönüştürme (safe cast) yapar.

        if (equipmentData != null)
        {
            EquipmentData.ToolType toolType = equipmentData.toolType;

            switch (toolType)
            {
                case EquipmentData.ToolType.Hoe:
                    if (landStatus == LandStatus.Soil)
                    {
                        SwitchLandStatus(LandStatus.Farmland);
                    }
                    break;
                case EquipmentData.ToolType.WateringCan:
                    if (landStatus == LandStatus.Farmland)
                    {
                        SwitchLandStatus(LandStatus.Watered);
                    }
                    break;

            }

            return;
        }

        SeedData seedTool = toolSlot as SeedData;

        if (seedTool != null && landStatus != LandStatus.Soil && cropPlanted == null)
        {
            GameObject cropObject = Instantiate(cropPrefab, transform);

            cropObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.51f, transform.position.z);
            

            cropPlanted = cropObject.GetComponent<CropBehaviour>();

            cropPlanted.Plant(seedTool);
        }
    }
    public void ClockUpdate(GameTimestamp timestamp)
    {
        if (landStatus == LandStatus.Watered)
        {
            int hoursElapsed = GameTimestamp.CompareTimestamp(timeWatered, timestamp);


            if(cropPlanted != null)
            {
                cropPlanted.Grow();
            }

            if (hoursElapsed > 24)
            {
                SwitchLandStatus(LandStatus.Farmland);
            }
        }

        
    }
    







}
