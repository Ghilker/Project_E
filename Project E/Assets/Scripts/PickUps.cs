using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    #region Weapons Stats
    public int setDamage = 0;
    public float setKnockBack = 0f;
    #endregion

    #region Armor Stats
    public int addHealthBonus = 0;
    public int addDefenseBonus = 0;
    public float addSpeedBonus = 0f;
    #endregion

    #region Misc Stats
    public string setName = "Null";
    public string setTag = "Null";
    #endregion

    protected virtual void Start()
    {
        
    }

    protected virtual void PickUpObject(GameObject other)
    {
        if(setTag == "Null")
        {
            Debug.Log("Null");
            return;
        }
    }

}
