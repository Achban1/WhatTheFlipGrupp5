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
        //currentPosition = transform.position;
    }

    void Update()
    {
        float zValue = Input.GetAxis("HorizontalPlayer1");
        if (zValue == 0)
        {
            Debug.Log("get to 0");
            timer = 0f;
        }
        else
        {
            float clampedValue = Mathf.Clamp(zValue, -1f, 1f); // Adjust the range of the input
            float t = Mathf.PingPong(timer, 1f);
            float zPos = Mathf.Lerp(min, max, (clampedValue + 1f) / 2f); // Map the clamped value to the range between 0 and 1
            transform.rotation = Quaternion.Euler(0, 0, zPos);
            timer += Time.deltaTime;
        }
    }
}

