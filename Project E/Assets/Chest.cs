using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{

    int[] weights = { 60, 30, 10 };

    protected override void Awake()
    {
        base.Awake();
        interactionTransform = transform.GetChild(0);
    }

    protected override void Interact()
    {
        base.Interact();
        int odd = Random.Range(0, 100);
        if(odd < 60)
        {
            Debug.Log("Found coins");
        }
        else
        {
            odd = odd - 60;
        }

    }

}
