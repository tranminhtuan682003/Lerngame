using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAttack : MonoBehaviour
{
    private float StartPosition;
    [SerializeField] private float X;
    [SerializeField] private float Speed;
    //[SerializeField] private float scale;
    [SerializeField] private int Health, MaxHealth;

    void Start()
    {
        Health = MaxHealth;
        StartPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        Vector3 position = transform.position;
        float RightLimit = StartPosition + X;
        position.x += Speed * Time.deltaTime;
        transform.position = position;
        if(position.x > RightLimit)
        {
            position.x = StartPosition;
            transform.position = position;
        }
    }
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
