using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    


    PlayerController playerController;

    LandController selectedLand = null;

    void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit);
        }
    }

    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        if(other.tag == "Land")
        {
            LandController land = other.GetComponent<LandController>();
            SelectLand(land);
            return;
        }

        if(selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }
    }

    void SelectLand(LandController land)
    {

        if(selectedLand != null)
        {
            selectedLand.Select(false);
        }

        selectedLand = land;
        land.Select(true);



    }

    public void Interact()
    {
        if(selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }

        Debug.Log("Not on any land ");
    }




}
