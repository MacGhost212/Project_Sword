using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float panSpeed = 5f;

    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        float panAmount = panSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
        {
            RotateCameraX(-rotationAmount);
            PanCameraX(-panAmount);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            RotateCameraX(rotationAmount);
            PanCameraX(panAmount);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            RotateCameraY(-rotationAmount);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            RotateCameraY(rotationAmount);
        }
    }

    void RotateCameraX(float amount)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.x += amount;
        transform.eulerAngles = rotation;
    }

    void RotateCameraY(float amount)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += amount;
        transform.eulerAngles = rotation;
    }

    void PanCameraX(float amount)
    {
        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 panVector = forward * amount;
        transform.position += panVector;
    }
}
