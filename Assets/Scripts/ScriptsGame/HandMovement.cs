using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HandMovement : MonoBehaviour
{
    public float rotationSpeed = 60f;
    private float rotationInput;
    private float rotationAmount;
    float smooth = 5.0f;
    float min = 90;
    float max = -90;
    float timer = 0f;

    private void Start()
    {
    }

    void Update()
    {
        float zValue = Input.GetAxis("HorizontalPlayer1");
        if (zValue == 0)
        {
            timer = 0f;
        }
        else
        {
            zValue *= 2;
            float clampedValue = Mathf.Clamp(zValue, -1f, 1f); 
            float zPos = Mathf.Lerp(min, max, (clampedValue + 1f) / 2f); 
            transform.rotation = Quaternion.Euler(0, 0, zPos);
            timer += Time.deltaTime;
        }
    }
}

