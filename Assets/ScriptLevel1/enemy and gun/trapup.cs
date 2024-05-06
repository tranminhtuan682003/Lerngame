using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapup : MonoBehaviour
{
    [SerializeField] private float speed;
    private float StartPossition;
    [SerializeField] private int damage;
    void Start()
    {
        StartPossition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        Vector3 position = transform.position;
        float toplimit = StartPossition + 2.5f;
        position.y += speed*Time.deltaTime;
        if(position.y >= toplimit)
        {
            speed = -Mathf.Abs(speed);
        }
        if(position.y <= StartPossition)
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
