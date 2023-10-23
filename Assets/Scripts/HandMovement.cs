using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float rotationSpeed = 60f;
    //private Vector3 currentPosition;
    private float rotationInput;
    private float rotationAmount;
    float smooth = 5.0f;
    float min = -1710;
    float max = 1710;

    private void Start()
    {
        //currentPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetAxis("HorizontalPlayer1") == 0)
        {
            Debug.Log("get to 0");
            transform.position = new Vector3(0,0,0);
        }
        float xPos = Mathf.Clamp(xValue, min, max);

        //float tiltAroundZ = Input.GetAxis("Horizontal") * rotationSpeed;
        //Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
        //rotationAmount = Mathf.Lerp(-1710, 1710, rotationInput);

        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        //rotationInput = Input.GetAxis("HorizontalPlayer1") * rotationSpeed * Time.deltaTime;
        //Quaternion hej = new Quaternion(0, 0, rotationAmount, 0);
        //Transform.Rotate()
        //1710 är max
    }
}

