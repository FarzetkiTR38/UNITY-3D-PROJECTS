using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    Transform playerPos;

    public float offsetZ;
    public float smoothing = 4f;


    void Start()
    {
        playerPos = FindAnyObjectByType<PlayerController>().transform;

        offsetZ = Mathf.Abs(transform.position.z - playerPos.position.z);
    }


    void Update()
    {
        FallowPlayer();
    }


    void FallowPlayer()
    {
        Vector3 targetPosition = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z - offsetZ);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }


}
