using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; 

    void Update()
    {
        // Rotate object to the left when Q key is pressed
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Rotate object to the right when E key is pressed
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
