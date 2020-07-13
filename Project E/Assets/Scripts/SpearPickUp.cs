using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearPickUp : PickUps
{
    public GameObject spear;

    protected override void PickUpObject(GameObject other)
    {
        base.PickUpObject(other);
        PickUpManager manager = other.GetComponent<PickUpManager>();
        PlayerSpear spearComponent = spear.GetComponentInChildren<PlayerSpear>();
        if (spearComponent.tagCustom == "Weapon")
        {
            if (manager.Weapons.Count <= 5)
            {
                manager.Weapons.Add(spear);
            }
            else
            {
                return;
            }

        }
        spearComponent.weaponDamage = setDamage;
        spearComponent.knockBackForce = setKnockBack;
        spearComponent.name = setName;
        spearComponent.tagCustom = setTag;
        Destroy(this.gameObject);
    }
}