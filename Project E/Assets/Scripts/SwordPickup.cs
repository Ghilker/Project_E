using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : PickUps
{
    public GameObject sword;

    protected override void PickUpObject(GameObject other)
    {
        base.PickUpObject(other);
        PickUpManager manager = other.GetComponent<PickUpManager>();
        PlayerSword swordComponent = sword.GetComponentInChildren<PlayerSword>();
        if(swordComponent.tagCustom == "Weapon")
        {
            if(manager.Weapons.Count <= 5)
            {
                manager.Weapons.Add(sword);
            }
            else
            {
                return;
            }
            
        }
        swordComponent.weaponDamage = setDamage;
        swordComponent.knockBackForce = setKnockBack;
        swordComponent.name = setName;
        swordComponent.tagCustom = setTag;
        Destroy(this.gameObject);
    }
}
