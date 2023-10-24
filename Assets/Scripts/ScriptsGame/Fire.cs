using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject hand;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            var newBullet = Instantiate(bullet, hand.transform.position, transform.rotation);
            Destroy(newBullet, 3f);
        }
    }
}
