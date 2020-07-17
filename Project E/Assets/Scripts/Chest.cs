using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{

    int[] weights = { 60, 30, 10 };
    public GameObject swordPickUp;
    public GameObject spearPickUp;

    public override void Awake()
    {
        base.Awake();

    }

    /*public override void Interact()
    {
        base.Interact();
        int odd = Random.Range(0, 100);
        if(odd < 60)
        {
            Debug.Log("Found coins");
            return;
        }
        else
        {
            odd = odd - 60;
        }
        if(odd < 30)
        {
            Debug.Log("Found Sword");
            Instantiate(swordPickUp, transform.position + transform.up, Quaternion.identity);
            return;
        }
        else
        {
            Debug.Log("Found Spear");
            Instantiate(spearPickUp, transform.position + transform.up * 1.5f, Quaternion.identity);
        }
        
    }*/

}
