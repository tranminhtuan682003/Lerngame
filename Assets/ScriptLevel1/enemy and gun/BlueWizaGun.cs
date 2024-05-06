using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWizaGun : MonoBehaviour
{
    public Transform BulletSpawpoint;
    public GameObject BulletPrefab;
    public float bulletsPerSecond = 2f;
    private float fireTimer;
    public float SpeedBullet;
    public List<Transform> Bosses; // Danh sách chứa tất cả các boss trong trò chơi
    private Transform currentBoss; // Boss mà BlueWizaGun đang theo dõi

    private bool BossInRange;

    void Start()
    {
        // Chọn một boss trong danh sách để theo dõi ban đầu
        if (Bosses.Count > 0)
            currentBoss = Bosses[0];
    }

    void Update()
    {
        if (currentBoss != null)
        {
            Vector3 direction = currentBoss.position - transform.position;
            direction.z = 0; // Đặt Z thành 0 để giữ súng ở mức độ 2D
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (BossInRange)
            {
                float timeBetweenShots = 1f / bulletsPerSecond;
                fireTimer += Time.deltaTime;
                if (fireTimer >= timeBetweenShots)
                {
                    FireBullet();
                    fireTimer = 0f;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            BossInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("player2"))
        {
            BossInRange = false;
        }
    }

    void FireBullet()
    {
        var bullet = Instantiate(BulletPrefab, BulletSpawpoint.position, BulletSpawpoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawpoint.right * SpeedBullet;
    }

    // Phương thức này được gọi khi một boss chết
    public void OnBossDeath(Transform deadBoss)
    {
        // Loại bỏ boss đã chết khỏi danh sách
        Bosses.Remove(deadBoss);

        // Nếu danh sách vẫn còn boss
        if (Bosses.Count > 0)
        {
            // Lấy index của boss hiện tại
            int currentIndex = Bosses.IndexOf(currentBoss);

            // Chọn boss kế tiếp hoặc boss đầu tiên nếu boss hiện tại là boss cuối cùng
            if (currentIndex == -1 || currentIndex == Bosses.Count - 1)
                currentBoss = Bosses[0];
            else
                currentBoss = Bosses[currentIndex + 1];
        }
        else
        {
            // Nếu không còn boss nào, đặt currentBoss thành null
            currentBoss = null;
        }
    }
}
