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


    // Update is called once per frame
    void Update()
    {
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

                    if (interactable.name == "Berry Bush")
                    {
                        healthSlider.value += 25;
                        hungerSlider.value += 25;
                    }
                    else if (interactable.name == "Banana Tree")
                    {
                        healthSlider.value += 50;
                        hungerSlider.value += 50;

                    }
                    // motor.MovetoPoint(hit.point);
                    


                }
            }
        }
        //press E to get Fruit
        if (Input.GetMouseButtonDown(1)) {
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
        void SetFocus(Interactable newFocus) {
            focus = newFocus;
        if (newFocus != focus) {
            if (focus != null)focus.OnDefocus();
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