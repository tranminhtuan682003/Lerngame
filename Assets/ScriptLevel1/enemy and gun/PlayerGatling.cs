using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGatling : MonoBehaviour
{
    public Transform player;
    public Transform BulletSpawpoint;
    public GameObject BulletPrefab;
    public float SpeedBullet;
    public Transform bulletprefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, BulletSpawpoint.position, BulletSpawpoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(player.localScale.x) * SpeedBullet, 0f);
        if (player.localScale.x < 0)
        {
            bullet.transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        if (player.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }

}
