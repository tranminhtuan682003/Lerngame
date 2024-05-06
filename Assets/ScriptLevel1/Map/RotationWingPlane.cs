using UnityEngine;

public class RotationWingPlane : MonoBehaviour
{
    public Transform centerPoint;
    public float rotationSpeed = 50f;
    void Update()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.RotateAround(centerPoint.position, Vector3.forward, rotation);
    }
}
