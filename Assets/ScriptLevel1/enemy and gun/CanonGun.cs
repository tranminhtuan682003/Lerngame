using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonGun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefap;
    [SerializeField] private Transform Spawnpoint;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int amountBullet;
    private List<GameObject> bulletPool;
    private float nextFireTime;
    [SerializeField] private float bulletSpeed = 1f;
    private bool isplayer;

    void Start()
    {
        CreatBulletPool();
    }

    void Update()
    {
        if (Time.time >= nextFireTime && isplayer)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate;
        }
        //quay quanh truc z xright yup zforward;
        //Spawnpoint.Rotate(Vector3.forward, 60 * Time.deltaTime);
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
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -bulletSpeed;

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
