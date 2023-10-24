using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HandMovement : MonoBehaviour
{
    public PlayerID playerID;
    
    public float rotationSpeed = 60f;
    private float rotationInput;
    private float rotationAmount;
    float smooth = 5.0f;
    float min = 90;
    float max = -90;
    float timer1 = 0f;
    float timer2 = 0f;

    float zValue1;
    float zValue2;

    private void Start()
    {
    }

    void Update()
    {
        switch (playerID)
        {
            case PlayerID.Player1:
                zValue1 = Input.GetAxis("HorizontalPlayer1");
                if (zValue1 == 0)
                {
                    timer1 = 0f;
                }
                else
                {
                    zValue1 *= 2;
                    float clampedValue = Mathf.Clamp(zValue1, -1f, 1f);
                    float zPos = Mathf.Lerp(min, max, (clampedValue + 1f) / 2f);
                    transform.rotation = Quaternion.Euler(0, 0, zPos);
                    timer1 += Time.deltaTime;
                }
                return;
            case PlayerID.Player2:
                zValue2 = Input.GetAxis("HorizontalPlayer2");
                if (zValue2 == 0)
                {
                    timer2 = 0f;
                }
                else
                {
                    zValue2 *= 2;
                    float clampedValue = Mathf.Clamp(zValue1, -1f, 1f);
                    float zPos = Mathf.Lerp(min, max, (clampedValue + 1f) / 2f);
                    transform.rotation = Quaternion.Euler(0, 0, zPos);
                    timer2 += Time.deltaTime;
                }
                return;
        }
    }
}

