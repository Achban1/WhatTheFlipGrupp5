using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public GameObject hand;
    public GameObject[] weapons;
    private Fire fireScript;
    public string[] weaponNames;

    void Start()
    {
        fireScript = GameObject.FindObjectOfType<Fire>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (other.gameObject.GetComponent<Rifle>() != null)
            {
                fireScript.PutWeaponInHand(0);
            }
            else if (other.gameObject.GetComponent<Bomb>() != null)
            {
                fireScript.PutWeaponInHand(1);
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
            Destroy(other.gameObject);
        }
    }
}
