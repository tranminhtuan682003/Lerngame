using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthIronBoss : MonoBehaviour
{
    [SerializeField] private int Health, MaxHealth;
    [SerializeField] private Animator animator;
    [SerializeField] private int damage;
    [SerializeField] private float time;
    public DroneController dronecontroller;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Health = MaxHealth;
    }

    void Update()
    {
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
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
}
