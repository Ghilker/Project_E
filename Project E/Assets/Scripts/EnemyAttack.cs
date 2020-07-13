using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Animator animator;
    BoxCollider colliderWeapon;
    EnemyMovement enemyAttack;
    bool wait = false;
    bool attack = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        colliderWeapon = GetComponentInChildren<BoxCollider>();
        enemyAttack = GetComponentInParent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAttack.canAttack && !wait)
        {
            animator.SetTrigger("Charge");
            wait = true;
            StartCoroutine(ChargeAttack());

        }
        if (attack)
        {
            animator.SetTrigger("Attack");
            attack = false;
            StartCoroutine(WeaponCheck());
        }
        animator.SetTrigger("Idle");
    }
    IEnumerator WeaponCheck()
    {
        yield return new WaitForSeconds(0.8f);
        colliderWeapon.enabled = false;
        yield return new WaitForSeconds(1.3f);
        wait = false;
    }
    IEnumerator ChargeAttack()
    {
        yield return new WaitForSeconds(1.1f);
        colliderWeapon.enabled = true;
        attack = true;
    }
}
