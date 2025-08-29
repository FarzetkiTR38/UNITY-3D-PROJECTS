using UnityEngine;

public class LandController : MonoBehaviour
{


    public enum LandStatus
    {
        Soil, Farmland, Watered
    }

    
    public Material soilMat, farmlandMat, wateredMat;

    public LandStatus landStatus;
    
    new Renderer renderer;
    
    public GameObject select;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(LandStatus.Soil);

        Select(false);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;

        Material materialToSwitch = soilMat;
        
        switch(statusToSwitch)
        {
            case LandStatus.Soil:
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farmland:
                materialToSwitch = farmlandMat;
                break;
            case LandStatus.Watered:
                materialToSwitch = wateredMat;
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
        SwitchLandStatus(LandStatus.Farmland);
    }







}
