using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    protected Transform interactionTransform = default;

    public float radius = 1f;

    protected LayerMask playerLayer;

    protected bool interacted = false;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        playerLayer = LayerMask.GetMask(LayerMask.LayerToName(9));
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Physics.CheckSphere(interactionTransform.position, radius, playerLayer) && Input.GetKeyDown(KeyCode.E))
        {
            if (!interacted)
            {
                Interact();
            }
            else
            {
                Debug.Log("Can't do that");
            }
            
        }
    }

    protected virtual void Interact()
    {
        Debug.Log("Interact");
        //interacted = true;
    }

    protected virtual void OnDrawGizmosSelected()
    {
        interactionTransform = transform.GetChild(0);
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
