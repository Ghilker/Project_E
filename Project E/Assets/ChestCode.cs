using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCode : MonoBehaviour
{
    Renderer color;

    public Transform interactionTransform;

    public float radius = 1f;

    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(interactionTransform.position, radius, playerLayer) && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interact");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
