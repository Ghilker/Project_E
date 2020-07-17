using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovements : MonoBehaviour
{
    NavMeshAgent player;
    GameObject _object;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            if (Vector3.Distance(transform.position, target.transform.position) <= player.stoppingDistance && !target.GetComponent<Interactable>().interacted)
            {
                _object.GetComponent<Interactable>().Interact(_object, this.gameObject);
            }
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Ground"))
                {
                    player.SetDestination(hit.point);
                    OnDefocus();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Interactable"))
                {
                    _object = hit.collider.gameObject;
                    OnFocus(_object);
                }
            }
        }
    }

    void OnFocus(GameObject _object)
    {
        if(target != null)
        {
            target = null;
        }
        target = _object;
        player.stoppingDistance = 3f;
        player.SetDestination(target.transform.position);
    }
    void OnDefocus()
    {
        if(target != null)
        {
            target = null;
        }
        player.stoppingDistance = 0f;
    }
}
