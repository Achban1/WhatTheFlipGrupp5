using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public GameObject hand;
    public GameObject[] weapons;
    private Fire fireScript;

    private Rifle rifle;
    private Bomb bomb;
    private GrenadeWeapon grenade;
    public string[] weaponNames;

    private Transform handController;
    private Transform theHand;

    void Start()
    {
        handController = transform.GetChild(2);
        theHand = handController.transform.GetChild(0);

        fireScript = GameObject.FindObjectOfType<Fire>();
        rifle = GameObject.FindObjectOfType<Rifle>();
        bomb = GameObject.FindObjectOfType<Bomb>();
        grenade = GameObject.FindObjectOfType<GrenadeWeapon>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (other.gameObject.GetComponent<Rifle>() != null)
            {
                rifle.MoveRifle(theHand);
            }
            else if (other.gameObject.GetComponent<Bomb>() != null)
            {
            }

            string nameOfWeaponGameObject = other.gameObject.name;

            Debug.Log(nameOfWeaponGameObject);
            foreach (GameObject weapon in weapons)
            {
                if (weapon != null && weapon.name == nameOfWeaponGameObject)
                {
                    
                    if (fireScript != null)
                    {
                        //fireScript.PutWeaponInHand(nameOfWeaponGameObject);
                    }
                }
            }
            //Destroy(other.gameObject);
        }
    }
}
