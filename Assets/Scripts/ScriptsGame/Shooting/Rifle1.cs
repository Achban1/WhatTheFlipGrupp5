using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Rifle : MonoBehaviour
{
    public GameObject rifleBullet;
    private Transform gunPoint;
    private Transform theHand;
    private Transform player;

    private bool isPickedUp;
    private Rigidbody2D rb;

    void Start()
    {
        gunPoint = transform.GetChild(0);
        player = GameObject.FindGameObjectWithTag("Player1").transform;

        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveRifle(Transform hand)
    {
        if (theHand == null) 
        {
            theHand = hand;
        }
        isPickedUp = true;
        Transform rifleTransform = transform;
        rifleTransform.SetParent(hand, true);
        rifleTransform.localPosition = Vector3.zero;
        rb.gravityScale = 0;
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            var newBullet = Instantiate(rifleBullet, gunPoint.transform.position, transform.rotation);
            Destroy(newBullet, 3f);
        }
        if (isPickedUp && theHand != null)
        {

            transform.position = theHand.position;
            transform.rotation = player.rotation;

        }
    }

    
}
