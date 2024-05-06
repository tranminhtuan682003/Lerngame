using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapmove : MonoBehaviour
{
    private float startposition;
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    void Start()
    {
        startposition = transform.position.x;
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 position = transform.position;
        float rightlimit = startposition + distance;
        position.x += speed * Time.deltaTime;
        if(position.x > rightlimit)
        {
            position.x = startposition;
        }
        transform.position = position;

    }
}
