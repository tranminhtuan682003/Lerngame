using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    private float startposition;
    void Start()
    {
        startposition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 position = transform.position;
        float bottomlimit = startposition - distance;
        position.y -= speed * Time.deltaTime;
        if(position.y < bottomlimit)
        {
            position.y = startposition;
        }
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player2"))
        {
            playercontroller.Instance.Takedamage(20);
        }
    }
}
