using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFalling : MonoBehaviour
{
    private float StartPosition;
    void Start()
    {
        StartPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap"))
        {
            Vector3 position = transform.position;
            position.y = StartPosition;
        }
    }
}
