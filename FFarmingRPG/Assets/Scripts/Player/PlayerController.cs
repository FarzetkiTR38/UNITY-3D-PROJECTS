using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Movement Components
    private CharacterController controller;
    private Animator animator;

    private float moveSpeed = 4f;

    [Header("Movement System")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;

    //Interaction Components
    PlayerInteraction playerInteraction;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerInteraction = GetComponentInChildren<PlayerInteraction>();
    }

    void Update()
    {
        Move();

        Interact();

        //testler için:
        if(Input.GetKey(KeyCode.CapsLock))
        {
            TimeManager.instance.Tick();
        }
    }

    public void Interact()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            playerInteraction.Interact();
        }



    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // dir = direction
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;


        if (Input.GetButton("Sprint"))
        {
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        }
        else
        {
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }



        if (dir.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(dir);

            controller.Move(velocity);
        }


        animator.SetFloat("Speed", velocity.magnitude);
        //magnitude, bir vektörün uzunluğunu (büyüklüğünü) verir. Yani matematikteki “hipotenüs hesabı” gibi düşünebilirsin.
    }


}
