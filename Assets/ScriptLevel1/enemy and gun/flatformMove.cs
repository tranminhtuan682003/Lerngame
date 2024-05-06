using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class flatformMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float x;
    [SerializeField] private float y;
    private float originalPositionX;
    //[SerializeField] private Transform player;
    void Start()
    {
        originalPositionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        Vector3 position = transform.position;
        float leftLimit = originalPositionX - x;
        float rightLimit = originalPositionX + y;

        position.x += speed * Time.deltaTime;
        transform.position = position;
        if (position.x < leftLimit || position.x > rightLimit)
        {
            speed = -speed;
        }
    }
}
