using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    [SerializeField] private float ranged;
    [SerializeField] private float speedEnemy;
    [SerializeField] private Vector3 scale;
    private float moveDir;
    private float playerHealth;
    private bool isAttack = false;
    private Animator animator;

    public Transform player;

    [SerializeField] private float eHealth,emaxhealth = 200f;

    void Start()
    {
        eHealth = emaxhealth;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = rb.GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleAttack();
        HandleMovement();
    }

    public void TakeDamage(float damage)
    {
        eHealth -= damage;
        Debug.Log("Enemy Health: " + eHealth);
        if (eHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetposition = player.position;
        }
    }

    private void HandleMovement()
    {
        if (player != null)
        {
            float distanceToPlayer = player.position.x - transform.position.x;
            moveDir = Mathf.Sign(distanceToPlayer);
        }

        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * moveDir, transform.localScale.y, transform.localScale.z);

        rb.velocity = new Vector2(speedEnemy * moveDir, rb.velocity.y);
        animator.SetBool("CanWalk", true);
    }

    private void HandleAttack()
    {
        Vector3 boxCastSize = new Vector3(0.2f, 0.5f, 0f);
        float boxCastDistance = 0f;

        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center + scale * moveDir, boxCastSize, 0f, new Vector2(moveDir, 0f), boxCastDistance);

        if (raycastHit2D.collider != null && raycastHit2D.collider.CompareTag("Player") && !isAttack)
        {
            Debug.Log("Chạm vào người chơi. Bắt đầu tấn công.");

            rb.velocity = Vector2.zero;
            animator.SetBool("IsAttack", true);
            isAttack = true;
            StartCoroutine(ResetAttack());
            Debug.Log("Đã tấn công");
            playercontroller player = raycastHit2D.collider.GetComponent<playercontroller>();
            if (player != null)
            {
                player.Takedamage(10);
            }
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        isAttack = false;
        animator.SetBool("IsAttack", false);
    }
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCollider.bounds.center + scale * moveDir, new Vector3(.2f, .5f, 0f));
    }
}
