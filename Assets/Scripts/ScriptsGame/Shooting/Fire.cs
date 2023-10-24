using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject hand;
    public GameObject[] weaponsArray;

    bool weaponActive = false;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!weaponActive)
            {
                var newBullet = Instantiate(bullet, hand.transform.position, transform.rotation);
                Destroy(newBullet, 3f);
            }
            
        }
    }

    public void PutWeaponInHand(string weaponName)
    {
        foreach (GameObject weapon in weaponsArray)
        {
            if (weaponName == weapon.name)
            {
                Transform newParent = transform.GetChild(0);
                GameObject newObject = Instantiate(weapon, newParent.position, newParent.rotation, newParent);
                
            }
        }
    }
}
