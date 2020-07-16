using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int healtHP = 100;
    public float knockBackResistance = 0.5f;

    public GameObject death;

    private void Update()
    {
        if(healtHP <= 0)
        {
            Instantiate(death, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
