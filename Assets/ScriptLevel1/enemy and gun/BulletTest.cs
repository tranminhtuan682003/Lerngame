using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private float timelife;

    private void FixedUpdate()
    {
        Vector2 enemyDirection = FindObjectOfType<EnemyTest>().GetEnemyRotation(); // Lấy hướng quay của enemy
        rb.velocity = enemyDirection * speed; // Sử dụng hướng quay của enemy để di chuyển đạn
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap"))
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator WaitforActive()
    {
        yield return new WaitForSeconds(timelife);
        gameObject.SetActive(false);
    }
}
