using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    


    PlayerController playerController;

    void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit)
        }
    }

    void OnInteractableHit(RaycastHit hit)
    {
        print("Hit");
    }






}
