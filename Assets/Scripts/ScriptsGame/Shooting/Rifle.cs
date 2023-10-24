using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public GameObject rifleBullet;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            var newBullet = Instantiate(rifleBullet, transform.position, transform.rotation);
            Destroy(newBullet, 3f);
        }
    }
}
