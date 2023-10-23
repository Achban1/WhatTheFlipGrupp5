using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float rotationSpeed = 500f;
    private Vector2 currentPosition;
    public float rotationAmount;

    private void Start()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        Debug.Log(rotationAmount);
        rotationAmount = Input.GetAxis("HorizontalPlayer1") * rotationSpeed * Time.deltaTime;
        Vector3 hej = new Vector3(0, 0, rotationAmount*100);
        transform.position += hej;
    }
}

