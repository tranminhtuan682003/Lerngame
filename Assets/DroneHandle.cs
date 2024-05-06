using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHandle : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float maxHealth;
    public Transform player;
    private float health;
    private float damage;
    [SerializeField] private float time;
    public DroneGun droneGun;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        FollowPlayer();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            animator.SetBool("Death", true);
            StartCoroutine(ResetAnimator());
        }
        else
        {
            animator.SetBool("IsHurt", true);
            StartCoroutine(ResetIsHurt());
        }
    }
    private IEnumerator ResetIsHurt()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsHurt", false);
    }


    private IEnumerator ResetAnimator()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        playercontroller.Instance.Health += 20;
        Debug.Log("da cong 20 mau");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bulletplayer"))
        {
            TakeDamage(5);
        }
        if (collision.gameObject.CompareTag("BulletBlueWiza"))
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("player2"))
        {
            animator.SetBool("IsAttack", true);
            playercontroller.Instance.Takedamage(damage);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            animator.SetBool("IsAttack", false);
        }
    }
    private void FollowPlayer()
    {
        if (droneGun.isplayer)
        {
            Vector3 playerPosition = player.position;
            Vector3 dronePosition = transform.position;
            Vector3 direction = (playerPosition - dronePosition).normalized;
            float moveSpeed = 1f;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            if (transform.position.x > playerPosition.x)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }
            else
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
        }
    }

}
