using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefap;
    [SerializeField] private Transform Spawnpoint;
    private GameObject player;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int amountBullet;
    private List<GameObject> bulletPool;
    private float nextFireTime;
    [SerializeField] private float bulletSpeed = 1f;
    public bool isplayer;

    void Start()
    {
        CreatBulletPool();
        player = GameObject.FindWithTag("player2"); 
        if (player == null)
        {
            Debug.LogError("Không thể tìm thấy đối tượng người chơi.");
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        if (Time.time >= nextFireTime && isplayer)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate;
        }
        if (player != null && isplayer)
        {
            Vector3 direction = player.transform.position - Spawnpoint.position;
            direction.z = 0;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Spawnpoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    private void CreatBulletPool()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < amountBullet; i++)
        {
            GameObject bullet = Instantiate(bulletPrefap);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3f);
        bullet.SetActive(false);
    }

    private void Fire()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = Spawnpoint.position;
                bullet.transform.rotation = Spawnpoint.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;

                // Bắt đầu Coroutine để đặt viên đạn thành false sau 3 giây
                StartCoroutine(DeactivateBullet(bullet));

                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            isplayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            isplayer = false;
        }
    }
}
