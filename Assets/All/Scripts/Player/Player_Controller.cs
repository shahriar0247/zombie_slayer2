using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public float speed = 2f;
    float current_speed = 0f;
    float speedsmoothvelocity = 0f;
    float speedsmoothtime = 0.1f;
    float rotationSpeed = 8f;
    float gravity = 3f;

    Transform cam;

    CharacterController controller;
    Animator animator;

    public GameObject graphics;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
      
    }

    void Rotate()
    {
        this.transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X")) ;

    }

    void Movement()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 forward = graphics.transform.forward;
        Vector3 right = graphics.transform.right;


        Vector3 moveto = (forward * movementInput.y + right * movementInput.x).normalized;
        Vector3 gravityvector = Vector3.zero;

        if (!controller.isGrounded)
        {
            gravityvector.y -= gravity;

        }

        if (moveto != Vector3.zero)
        {
            float rotation = movementInput.x * 90;
            if (rotation < 0f)
            {
                rotation += movementInput.y * 45;
            }
            else if (rotation > 0f)
            {
                rotation -= movementInput.y * 45;
            }
            else if (rotation == 0) { 
            if (movementInput.y < 0)
            {
                rotation = 180;
            }
            }
            Debug.Log("mouse input value" + movementInput);
            graphics.transform.rotation = Quaternion.Slerp(graphics.transform.rotation, Quaternion.Euler(0, rotation, 0), rotationSpeed * Time.deltaTime);
            
          
        }
        else
        {
            animator.SetFloat("speed", 0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else
        {
            speed = 2f;
        }

        float targetspeed = speed * movementInput.magnitude;
        current_speed = Mathf.SmoothDamp(current_speed, targetspeed, ref speedsmoothvelocity, speedsmoothtime);
        
        controller.Move(moveto * current_speed * Time.deltaTime);

        controller.Move(gravityvector * Time.deltaTime);

      
     
            animator.SetFloat("speed", current_speed / 10);
       
    }
}
