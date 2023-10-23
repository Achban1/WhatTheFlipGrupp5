using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotationController : MonoBehaviour
{
    public float rotationSpeed = 5f; 

    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetRotation *= Quaternion.Euler(0, 0, 180);
            //CameraShake.Instance.ShakeCamera(3f, 0.1f);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
