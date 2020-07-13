using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerHealthHP = 100;
    public float playerSpeed = 10f;
    public float playerRotationSpeed = 10f;
    public float playerJumpHeight = 5f;
    public float playerDashDistance = 5f;
    public int playerDamageDone = 5;
    public int playerDamageResistance = 0;
    public bool playerIsDead = false;

    private void Update()
    {
        if(playerHealthHP <= 0)
        {
            playerIsDead = true;
        }
    }
}
