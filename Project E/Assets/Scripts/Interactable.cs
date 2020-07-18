using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region drop down menu selection
    public enum objType
    {
        Chest,
        Enemy,
        Npc,
        Item
    }
    #endregion

    public objType Type;

    [HideInInspector]
    public bool interacted = false;

    public virtual void Awake()
    {

    }

    public virtual void Interact(GameObject _object, GameObject otherObj)
    {
        Interactable getType = _object.GetComponent<Interactable>();
        if (getType.Type == objType.Chest)
        {
            //Debug.Log("Open");
            interacted = true;
            _object.GetComponent<Chest>().Interact();
        }
        else if(getType.Type == objType.Enemy)
        {
            Debug.Log("Kill");
        }
        else if (getType.Type == objType.Npc)
        {
            Debug.Log("Talk");
        }
        else if (getType.Type == objType.Item)
        {
            Debug.Log("Collect");
        }
    }
}
