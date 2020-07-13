using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : PlayerWeaponBehaviour
{
    Transform weaponPivot;  
    Animator weaponPivotAnimator;
    BoxCollider colliderWeapon;

    public string tagCustom = null;

    private void Awake()
    {
        isMelee = true;
        weaponPivot = GetComponentInParent<Transform>();
        weaponPivotAnimator = GetComponentInParent<Animator>();
        colliderWeapon = GetComponent<BoxCollider>();
    }

    protected override void Update()
    {
        base.Update();
        weaponPivotAnimator.SetTrigger("Idle");
    }

    protected override void MeleeAttack()
    {
        weaponPivotAnimator.SetTrigger("AttackAlt");
        colliderWeapon.enabled = true;
        StartCoroutine(WaitTimer(colliderWeapon));
    }
}
