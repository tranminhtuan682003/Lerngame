
using UnityEngine;

public class LeoThang : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isladder;
    private bool isclimping;
    [SerializeField] private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if(isladder && Mathf.Abs(vertical) > 0f)
        {
            isclimping = true;
        }
    }
    private void FixedUpdate()
    {
        if(isclimping)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical*speed);
            anim.SetBool("IsClimbing", true);
        }
        else
        {
            rb.gravityScale = 4f;
            anim.SetBool("IsClimbing", false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isladder = true;
         }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isladder = false;
            isclimping = false;
        }
    }
}

