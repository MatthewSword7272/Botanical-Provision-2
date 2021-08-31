
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //object interactivity radius 
    bool isFocus = false;    
    bool hasInteracted = false;
    public Transform interactionTransform;
    Transform player;
    public float radius = 3f;

    public virtual void Interact() { 
    
    }

    public void OnFocus(Transform playerTransform) {
    
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }
    public void OnDefocus() {
        isFocus = false;
        hasInteracted = false;
        player = null;
    }
    void OnDrawGizmosSelected() {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    
    }
    void Update() {
        if (isFocus) {
            float distance = Vector3.Distance(player.position,transform.position);
            if (distance >= radius &&  !hasInteracted) {
                Interact();
                   hasInteracted = true;
                Debug.Log("interact");
            }
        }
    }

}
