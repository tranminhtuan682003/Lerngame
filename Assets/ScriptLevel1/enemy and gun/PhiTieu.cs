using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhiTieu : MonoBehaviour
{
    [SerializeField] private float speed;
    private float Startposition;
    [SerializeField] private int damage;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private playercontroller controller;
    void Start()
    {
        Startposition = transform.position.x;
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        Vector3 position = transform.position;
        float leftlimit = Startposition - x;
        float rightlimit = Startposition + y;

        position.x += speed * Time.deltaTime;
        transform.position = position;
        if (position.x >= rightlimit)
        {
            position.x = leftlimit;
            transform.position = position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            controller.Takedamage(damage);
        }
    }
}
