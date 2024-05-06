using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    private int Health;
    private int MaxHealth = 50;
    private Rigidbody2D rb;
    public GameObject door;
    void Start()
    {
        Health = MaxHealth;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }
    public void TakeDamage( int amount)
    {
        Health -= amount;
        if(Health < 0)
        {
            Destroy(gameObject);
            Destroy(door);
        }
    }
}
