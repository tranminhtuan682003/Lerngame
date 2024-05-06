using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFire : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private float Speed = 5f;
    public float horizontal;
    void Start()
    {
        
    }
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        move();
    }
    private void move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal == 0)
        {
            anim.SetBool("IsAttackFire", true);
        }
    }
}
