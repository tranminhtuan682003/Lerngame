using UnityEngine;

public class GunPlane : MonoBehaviour
{
    public Transform BulletSpawpoint;
    public GameObject BulletPrefab;
    public float bulletsPerSecond = 2f;
    public float SpeedBullet = 10f;
    private bool playerRange;

    private float fireTimer = 0f;

    void Update()
    {
        if(playerRange)
        {
            fireTimer += Time.deltaTime;
            float timeBetweenBullets = 1f / bulletsPerSecond;
            if (fireTimer >= timeBetweenBullets)
            {
                FireBullet();
                fireTimer = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playerRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playerRange = false;
        }
    }
    void FireBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, BulletSpawpoint.position, BulletSpawpoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawpoint.forward * SpeedBullet;
    }
}
