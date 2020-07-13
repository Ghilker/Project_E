using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponBehaviour : MonoBehaviour
{
    protected bool canAttack = true;
    protected bool isMelee = true;
    protected bool oneTrigger = true;

    [HideInInspector]
    public float knockBackForce = 0;

    [HideInInspector]
    public int weaponDamage = 0;

    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack && isMelee)
            {
                MeleeAttack();
                canAttack = false;
            }
            else if(canAttack && !isMelee)
            {
                RangedAttack();
                canAttack = false;
            }
        }
    }

    protected virtual void MeleeAttack()
    {
        return;
    }

    public virtual void RangedAttack()
    {
        return;
    }

    protected IEnumerator WaitTimer(BoxCollider colliderWeapon)
    {
        yield return new WaitForSeconds(0.55f);
        colliderWeapon.enabled = false;
        canAttack = true;
        oneTrigger = true;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && oneTrigger)
        {
            oneTrigger = false;
            EnemyStats enemy = other.gameObject.GetComponent<EnemyStats>();
            PlayerStats player = GetComponentInParent<PlayerStats>();
            enemy.healtHP -= player.playerDamageDone + weaponDamage;
        }
    }

}
