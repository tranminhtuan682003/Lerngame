using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyHealth : MonoBehaviour
{
    [SerializeField] private int Health, MaxHealth;
    [SerializeField] private Animator animator;
    [SerializeField] private int damage;
    private BlueWizaGun blueWizaGun; // Tham chiếu đến BlueWizaGun
    public playercontroller controller;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        blueWizaGun = FindObjectOfType<BlueWizaGun>(); // Tìm BlueWizaGun trong scene
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
            animator.SetBool("IsDead", true);
            StartCoroutine(ResetAnimator());

            if (blueWizaGun != null)
            {
                blueWizaGun.OnBossDeath(transform);
            }
        }
        else
        {
            animator.SetBool("IsHurt", true);
            StartCoroutine(ResetIsHurt());
        }
    }

    private IEnumerator ResetIsHurt()
    {
        yield return new WaitForSeconds(0.1f); // Thời gian tổn thương (giả định 0.5 giây)
        animator.SetBool("IsHurt", false);
    }


    private IEnumerator ResetAnimator()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        controller.Health += 5;
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
            controller.Takedamage(damage);
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
