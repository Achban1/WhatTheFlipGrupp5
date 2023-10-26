using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    private Rifle rifle;
    private Bomb bomb;
    private GrenadeWeapon grenade;

    private Transform handController;
    private Transform theHand;

    void Start()
    {
        handController = transform.GetChild(2);
        theHand = handController.transform.GetChild(0);
        Debug.Log(theHand.name);

        rifle = GameObject.FindObjectOfType<Rifle>();
        bomb = GameObject.FindObjectOfType<Bomb>();
        grenade = GameObject.FindObjectOfType<GrenadeWeapon>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.gameObject.GetComponent<Rifle>() != null)
        {

            Rifle rifleScript = other.gameObject.GetComponent<Rifle>();
            rifle.MoveRifle(theHand);
            Vector2 rifleDirection = rifle.transform.right;
            Vector3 playerLocalScale = transform.localScale;
            float playerDir = playerLocalScale.x;
            if ((rifleDirection.x > 0 && playerDir < 0) || (rifleDirection.x < 0 && playerDir > 0))
            {
                rifle.FlipRifle(rifleDirection);
            }
        }

        else if (other.gameObject.GetComponent<Bomb>() != null)
        {
        }


    }
}

