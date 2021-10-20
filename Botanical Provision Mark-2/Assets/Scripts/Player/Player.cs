using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Interactable focus;
    public float speed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groudMask;
    bool isGrounded;
    public bool playerInZone = false;
    public bool playerInInventory = false;
    public bool playerInPickUp = false;
    bool isMoving = false;
    AudioSource audioSource;
    public AudioClip walking;
    public AudioClip running;
    

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groudMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (!playerInInventory && !playerInPickUp)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 15f;
                audioSource.clip = running;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 6f;
                audioSource.clip = walking;
            }

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(speed * Time.deltaTime * moveDir.normalized);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (horizontal < 0 || vertical != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
           
            if (isMoving)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.Stop();
            }
           
        }


        //leftclick
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Debug.Log("left click");
                }
            }
        }
        //press Left-Mouse Button to get Fruit
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {

                    SetFocus(interactable);

                }
            }

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Cursor.visible)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else 
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }


    }
    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        if (newFocus != focus)
        {
            if (focus != null) focus.OnDefocus();
            {
                focus = newFocus;
            }
        }
        newFocus.OnFocus(transform);
    }

}