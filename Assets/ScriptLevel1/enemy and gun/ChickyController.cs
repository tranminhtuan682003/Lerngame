using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickyController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float damage = 0.1f;
    [SerializeField] private float Health, Maxhealth = 200;
    [SerializeField] private float distance;
    [SerializeField] private List<GameObject> door;
    private Animator animator;
    private Transform player;
    private playercontroller controller;
    
    private bool isin;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = FindObjectOfType<playercontroller>();
    }

    private void Start()
    {
        foreach (GameObject go in door)
        {
            go.SetActive(false);
        }
        player = GameObject.FindGameObjectWithTag("player2").GetComponent<Transform>();
        Health = Maxhealth;
    }

    void Update()
    {
        if (PlayerInSight())
        {
            FollowPlayer();
        }
        if(isin)
        {
            AttackPlayer();
        }
    }

    private void FollowPlayer()
    {
        Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (targetPosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        else
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, distance, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("player2"))
            {
                foreach (GameObject go in door)
                {
                    go.SetActive(true);
                }
                Debug.DrawRay(transform.position, (hit.point - (Vector2)transform.position).normalized * hit.distance, Color.red);
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player2"))
        {
            isin = true;
        }
        if (collision.CompareTag("bulletplayer"))
        {
            TakeDamage(5);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player2") && isin)
        {
            isin = false;
        }
    }
    private void AttackPlayer()
    {
        animator.SetBool("IsAttack", true);
        playercontroller.Instance.Takedamage(damage);
        StartCoroutine(ResetAttack());
        if (Health <= Maxhealth / 2)
        {
            animator.SetBool("IsAttack2", true);
            damage = 2;
        }
    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsAttack2", false);
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        Debug.Log("Chicky nhận : " + amount + " sát thương");
        if (Health <= 0)
        {
            animator.SetTrigger("IsDeath");
            StartCoroutine(DisableObjectAfterAnimation());
        }
    }

    private IEnumerator DisableObjectAfterAnimation()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        foreach (GameObject go in door)
        {
            go.SetActive(false);
        }
        controller.Health += 10;
        Debug.Log("Đã nhận máu: " + controller.Health);
    }
}
