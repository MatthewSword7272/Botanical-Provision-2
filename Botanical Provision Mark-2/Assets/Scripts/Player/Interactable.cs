
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //object interactivity radius 
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
        hasInteracted = false;
        player = playerTransform;
        Interact();
    }
    public void OnDefocus()
    {
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
