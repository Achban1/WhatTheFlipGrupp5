using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public GameObject hand;
    public GameObject[] weapons;
    private Fire fireScript;

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
            string nameOfWeaponGameObject = other.gameObject.name;

            Debug.Log(nameOfWeaponGameObject);
            foreach (GameObject weapon in weapons)
            {
                if (weapon != null && weapon.name == nameOfWeaponGameObject)
                {
                    Transform childTransform = transform.GetChild(2);
                    
                    if (fireScript != null)
                    {
                        Transform newParent = childTransform.GetChild(0);
                        fireScript.PutWeaponInHand(nameOfWeaponGameObject);
                    }
                }
            }
            Destroy(other.gameObject);
        }
    }
}
