using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPlane : MonoBehaviour
{
    [SerializeField] private float life;
    private Animator animator;
    private bool isBoom = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isBoom && (collision.gameObject.CompareTag("tilemap")))
        {
            isBoom = true;
            animator.SetBool("IsBoom", true);
            StartCoroutine(DestroyAfterDelay());
        }
        if (collision.gameObject.CompareTag("player2"))
        {
            isBoom = true;
            playercontroller.Instance.Takedamage(50);
            animator.SetBool("IsBoom", true);
            StartCoroutine(DestroyAfterDelay());
        }
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
