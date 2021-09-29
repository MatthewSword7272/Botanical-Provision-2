using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Interactable focus;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groudMask;
    bool isGrounded;
    public bool playerInZone = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groudMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
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


        //leftclick
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Slider healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
                    Slider hungerSlider = GameObject.Find("HungerSlider").GetComponent<Slider>();
                    Debug.Log("left click");
                    if (interactable.name == "Berry Bush")
                    {
                        healthSlider.value += 10;
                        hungerSlider.value += 10;
                    }
                    else if (interactable.name == "Banana Tree")
                    {
                        healthSlider.value += 30;
                        hungerSlider.value += 30;

                    }
                    else if (interactable.name == "Apple Table")
                    {
                        healthSlider.value += 15;
                        hungerSlider.value += 15;
                    }
                    else if (interactable.name == "Carrot Patch")
                    {
                        healthSlider.value += 20;
                        hungerSlider.value += 20;
                    }
                    else if (interactable.name == "Lettuce Patch")
                    {
                        healthSlider.value += 25;
                        hungerSlider.value += 25;
                    }
                    // motor.MovetoPoint(hit.point);
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
    void RemoveFocus()
    {

        if (focus != null)
        {
            focus.OnDefocus();
            focus = null;
        }

    }

}