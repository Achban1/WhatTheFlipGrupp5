using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public GameObject rifleBullet;
    public GameObject gunPoint;
    private Transform theHand;
    private Transform player;

    private bool isPickedUp;
    private Rigidbody2D rb;
    private Transform rifleTransform;

    private Vector2 rifleDir = new Vector2(1, 0);
    private Quaternion rot;

    private bool isFacingRight = true; // New variable to keep track of the direction

    void Start()
    {
        //gunPoint = transform.GetChild(0);
        player = GameObject.FindGameObjectWithTag("Player1").transform;
        rb = GetComponent<Rigidbody2D>();
        rifleTransform = GetComponent<Transform>();
        rot = transform.rotation;
    }

    public void FlipRifle(Vector2 dir)
    {
        rifleDir = dir;
        isFacingRight = !isFacingRight; // Flip the direction
        Vector3 newScale = transform.localScale;
        newScale.x *= -1; // Flip the scale
        transform.localScale = newScale;
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
        float xScale = player.localScale.x;
        if (xScale > 0 )
        {
            rifleDir.x = -1f;
        }

        transform.position = hand.position;

        //rb.velocity = Vector2.zero;
        //rb.gravityScale = 0f;
        Destroy(rb);


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector2 bulletOffset = new Vector2(0, 0.68f);
            if (rifleDir.x > 0)
            {
                Instantiate(rifleBullet, (Vector2)gunPoint.transform.position+bulletOffset, Quaternion.Euler(0, 0, 180));
            }
            if (rifleDir.x < 0)
            {
                Instantiate(rifleBullet, (Vector2)gunPoint.transform.position - bulletOffset, Quaternion.Euler(0, 0, 0));
            }


            //Vector2 bulletOffset = new Vector2(0, -0.185f);
            //Quaternion rightRotation = Quaternion.Euler(0, 0, -90);
            //Quaternion leftRotation = Quaternion.Euler(0, 0, 90);
            //Vector2 scale = new Vector2(transform.localScale.x, transform.localScale.y);
            //var newBullet = Instantiate(rifleBullet, (Vector2)gunPoint.transform.position + bulletOffset, Quaternion.identity);
            //newBullet.transform.localScale = scale;
            //Debug.Log(player.rotation); 
            //Destroy(newBullet, 3f);
        }
        if (isPickedUp && theHand != null)
        {
            Vector2 gunPosOffset = new Vector2(0, -0.8f);
            transform.position = (Vector2)theHand.position + gunPosOffset;
            transform.rotation = rot;
            float xScale = player.localScale.x;
            if (xScale > 0)
            {
                rifleDir.x = -1f;
            }
            else if (xScale < 0)
            {
                rifleDir.x = 1f;
            }
        }
    }
}
