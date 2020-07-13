using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public List<GameObject> Weapons;
    public Transform sidePosition;

    GameObject currentWeapon;

    private void Awake()
    {
        Weapons = new List<GameObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && Weapons.Count != 0)
        {
            WeaponSwitch();
        }
    }
    void WeaponSwitch()
    {
        if(currentWeapon != null)
        {
            Destroy(currentWeapon);
        }
        if (currentWeapon == null)
        {
            currentWeapon = Instantiate(Weapons[0], sidePosition);
            Weapons.Add(Weapons[0]);
            Weapons.Remove(Weapons[0]);
        }
    }

}
