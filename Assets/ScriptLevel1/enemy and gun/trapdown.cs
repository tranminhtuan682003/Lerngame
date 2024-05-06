using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdown : MonoBehaviour
{
    [SerializeField] private float speed;
    private float positionStart;
    [SerializeField] private int damage;
    private void Start()
    {
        positionStart = transform.position.y;
    }
    private void Update()
    {
        move();
    }
    private void move()
    {
        Vector3 position = transform.position;
        float bottomlimit = positionStart - 2.5f;
        position.y += -speed * Time.deltaTime;
        if (position.y <= bottomlimit)
        {
            speed = -Mathf.Abs(speed);
        }
        if (position.y >= positionStart)
        {
            speed = Mathf.Abs(speed);
        }
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playercontroller.Instance.Takedamage(100);
        }
    }
}
