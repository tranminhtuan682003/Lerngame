using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flatformup : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float x;
    private float positionystart;

    void Start()
    {
        positionystart = transform.position.y;
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        Vector3 position = transform.position;
        float toplimit = positionystart + x;
        position.y += speed * Time.deltaTime;
        if (position.y >= toplimit)
        {
            position.y = positionystart;
        }
        transform.position = position;
    }
}
