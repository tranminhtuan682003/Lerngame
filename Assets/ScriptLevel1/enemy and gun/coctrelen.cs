using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coctrelen : MonoBehaviour
{
    [SerializeField] private float speed;
    private float positionystart;
    // Start is called before the first frame update
    void Start()
    {
        positionystart = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        Vector3 position = transform.position;
        float bottomlimit = positionystart - 0.5f;
        position.y += speed * Time.deltaTime;
        transform.position = position;
        if(position.y < bottomlimit || position.y > positionystart)
        {
            speed = -speed;
        }

    }
}
