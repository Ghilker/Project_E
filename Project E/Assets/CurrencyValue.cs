using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyValue : MonoBehaviour
{
    public enum Currency
    {
        Wood,
        Iron,
        Copper,
        Silver,
        Gold,
        Platinum,
        Diamond
    }

    public Currency value;
}
