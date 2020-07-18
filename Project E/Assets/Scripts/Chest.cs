using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public enum ChestRarity
    {
        Useless,
        Common,
        Rare,
        Rewarding,
        Unique,
        Legendary,
        Artifact
    }

    public ChestRarity chestRarity;

    float[] weights = { 70, 13, 12, 5 }; //currency, weapons, armors, oddities
    float[] currency = { 35, 30, 15, 10, 5, 3, 2 };
    float[] weapons = { 35, 30, 15, 10, 5, 3, 2 };
    float[] armors = { 35, 30, 15, 10, 5, 3, 2 };
    float[] oddities = { 35, 30, 15, 10, 5, 3, 2 };

    public int numberOfItems = 10;
    public int rangeOfItems = 1;


    public GameObject swordPickUp;

    public GameObject currencyPickUp;

    public GameObject armorPickUp;

    public GameObject oddityPickUp;

    public bool sureLoot = false;

    private void Awake()
    {
        numberOfItems = numberOfItems + Random.Range(-rangeOfItems, rangeOfItems + 1);
        Debug.Log(numberOfItems);
    }

    public void Interact()
    {
        if (chestRarity == ChestRarity.Common)
        {
            CheckItem((int)ChestRarity.Common);
        }
        else if (chestRarity == ChestRarity.Rare)
        {
            CheckItem((int)ChestRarity.Rare);
        }
        else if (chestRarity == ChestRarity.Unique)
        {
            CheckItem((int)ChestRarity.Unique);
        }
        else if (chestRarity == ChestRarity.Legendary)
        {
            CheckItem((int)ChestRarity.Legendary);
        }
        else if (chestRarity == ChestRarity.Artifact)
        {
            CheckItem((int)ChestRarity.Artifact);
        }
        if (sureLoot)
        {

        }
    }

    int Choose(float[] probs)
    {
        float total = 0;
        foreach (float elem in probs)
        {
            total += elem;
        }
        float randomPoint = Random.value * total;
        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    void CheckItem(int rarity)
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            int odd = Choose(weights);
            Debug.Log("odd = " + odd);
            if (odd == 3)
            {
                CheckOddities(rarity);
            }
            else if (odd == 2)
            {
                CheckArmors(rarity);
            }
            else if (odd == 1)
            {
                CheckWeapons(rarity);
            }
            else if (odd == 0)
            {
                CheckCurrency(rarity);
            }
        }
    }

    void CheckCurrency(int rarity)
    {
        int odd = Choose(currency);
        odd = Mathf.Clamp(Mathf.Clamp(odd, rarity - 2, rarity + 2), 0, 6);
        if(odd == 0)
        {
            GameObject coinValue = Instantiate(currencyPickUp, transform.position + transform.up, Quaternion.identity);
            coinValue.GetComponent<CurrencyValue>().value = CurrencyValue.Currency.Wood;
            coinValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
            coinValue.GetComponent<Renderer>().material.color = Color.black;
        }
        else if (odd == 1)
        {
            GameObject coinValue = Instantiate(currencyPickUp, transform.position + transform.up, Quaternion.identity);
            coinValue.GetComponent<CurrencyValue>().value = CurrencyValue.Currency.Iron;
            coinValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 2)
        {
            GameObject coinValue = Instantiate(currencyPickUp, transform.position + transform.up, Quaternion.identity);
            coinValue.GetComponent<CurrencyValue>().value = CurrencyValue.Currency.Copper;
            coinValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 3)
        {
            GameObject coinValue = Instantiate(currencyPickUp, transform.position + transform.up, Quaternion.identity);
            coinValue.GetComponent<CurrencyValue>().value = CurrencyValue.Currency.Silver;
            coinValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 4)
        {
            GameObject coinValue = Instantiate(currencyPickUp, transform.position + transform.up, Quaternion.identity);
            coinValue.GetComponent<CurrencyValue>().value = CurrencyValue.Currency.Gold;
            coinValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 5)
        {
            GameObject coinValue = Instantiate(currencyPickUp, transform.position + transform.up, Quaternion.identity);
            coinValue.GetComponent<CurrencyValue>().value = CurrencyValue.Currency.Platinum;
            coinValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 6)
        {
            GameObject coinValue = Instantiate(currencyPickUp, transform.position + transform.up, Quaternion.identity);
            coinValue.GetComponent<CurrencyValue>().value = CurrencyValue.Currency.Diamond;
            coinValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
    }
    void CheckWeapons(int rarity)
    {
        int odd = Choose(weapons);
        odd = Mathf.Clamp(Mathf.Clamp(odd, rarity - 2, rarity + 2), 0, 6);
        if(odd == 0)
        {
            GameObject weaponValue = Instantiate(swordPickUp, transform.position + transform.up, Quaternion.identity);
            weaponValue.GetComponent<SwordPickup>().setDamage = Random.Range(1, rarity + 2);
            weaponValue.GetComponent<SwordPickup>().setName = "Simple Sword";
            weaponValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 1)
        {
            GameObject weaponValue = Instantiate(swordPickUp, transform.position + transform.up, Quaternion.identity);
            weaponValue.GetComponent<SwordPickup>().setDamage = Random.Range(1 + odd, rarity + 4);
            weaponValue.GetComponent<SwordPickup>().setName = "Rusty Sword";
            weaponValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 2)
        {
            GameObject weaponValue = Instantiate(swordPickUp, transform.position + transform.up, Quaternion.identity);
            weaponValue.GetComponent<SwordPickup>().setDamage = Random.Range(1 + odd, rarity + 3 * odd);
            weaponValue.GetComponent<SwordPickup>().setName = "Sword";
            weaponValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 3)
        {
            GameObject weaponValue = Instantiate(swordPickUp, transform.position + transform.up, Quaternion.identity);
            weaponValue.GetComponent<SwordPickup>().setDamage = Random.Range(1 + odd, rarity + 3 * odd);
            weaponValue.GetComponent<SwordPickup>().setName = "Better Sword";
            weaponValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 4)
        {
            GameObject weaponValue = Instantiate(swordPickUp, transform.position + transform.up, Quaternion.identity);
            weaponValue.GetComponent<SwordPickup>().setDamage = Random.Range(1 + odd, rarity + 4 * odd);
            weaponValue.GetComponent<SwordPickup>().setName = "Good Sword";
            weaponValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 5)
        {
            GameObject weaponValue = Instantiate(swordPickUp, transform.position + transform.up, Quaternion.identity);
            weaponValue.GetComponent<SwordPickup>().setDamage = Random.Range(1 + odd, rarity + 5 * odd);
            weaponValue.GetComponent<SwordPickup>().setName = "Great Sword";
            weaponValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
        else if (odd == 6)
        {
            GameObject weaponValue = Instantiate(swordPickUp, transform.position + transform.up, Quaternion.identity);
            weaponValue.GetComponent<SwordPickup>().setDamage = Random.Range(1 + odd, rarity + 6 * odd);
            weaponValue.GetComponent<SwordPickup>().setName = "Ultragreat Sword";
            weaponValue.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
        }
    }
    void CheckArmors(int rarity)
    {
        int odd = Choose(armors);
        odd = Mathf.Clamp(Mathf.Clamp(odd, rarity - 2, rarity + 2), 0, 6);
        if (odd == 0)
        {

        }
        else if (odd == 1)
        {

        }
        else if (odd == 2)
        {

        }
        else if (odd == 3)
        {

        }
        else if (odd == 4)
        {

        }
        else if (odd == 5)
        {

        }
        else if (odd == 6)
        {

        }
    }
    void CheckOddities(int rarity)
    {
        int odd = Choose(oddities);
        odd = Mathf.Clamp(Mathf.Clamp(odd, rarity - 2, rarity + 2), 0, 6);
        if (odd == 0)
        {

        }
        else if (odd == 1)
        {

        }
        else if (odd == 2)
        {

        }
        else if (odd == 3)
        {

        }
        else if (odd == 4)
        {

        }
        else if (odd == 5)
        {

        }
        else if (odd == 6)
        {

        }
    }


}
