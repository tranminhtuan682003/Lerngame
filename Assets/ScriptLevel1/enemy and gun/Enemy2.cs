using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Health healthPlayer;
    public playercontroller playercontrollerr;
    public int damage = 20;
    public float speed;
    private Transform target;
    private int health = 40;
    void Start()
    {
        health = 40;
        target = GameObject.FindGameObjectWithTag("player2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player2")
        {
            Debug.Log("hit");
            playercontrollerr.Takedamage(damage);
            healthPlayer.TakeDamgae(damage);
            
        }
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
