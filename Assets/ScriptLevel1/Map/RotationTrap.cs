using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrap : MonoBehaviour
{
    public Transform centerPoint;
    public float rotationSpeed = 50f;
    [SerializeField] private int damage;
    void Update()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.RotateAround(centerPoint.position,Vector3.forward,rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playercontroller.Instance.Takedamage(damage);
        }
    }
}
