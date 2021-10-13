
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //object interactivity radius 
    private bool isFocus = false;
    public bool hasInteracted = false;
    public Transform interactionTransform;
    private Transform player;
    public float radius = 3f;
    public Canvas popup;
    public virtual void Interact()
    {
        hasInteracted = true;
    }

    public void OnFocus(Transform playerTransform)
    {

        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
        Interact();
    }
    public void OnDefocus()
    {
        isFocus = false;
        hasInteracted = false;
        player = null;
    }
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
    void Start()
    {

        popup = GameObject.FindGameObjectWithTag("popup").GetComponent<Canvas>();
        popup.enabled = false;

    }
}
