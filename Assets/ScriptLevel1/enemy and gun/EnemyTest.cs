using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField] private Transform bulletposition;
    float rotationSpeed = 90f;
    void Start()
    {
        
    }

    void Update()
    {
        Fire();
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    public Vector3 GetEnemyRotation()
    {
        return transform.up; // Đối với ví dụ này, giả sử enemy quay quanh trục Y (up)
    }
    private void Fire()
    {
        GameObject bullet = ObjectPool.instance.GetpooledObject();
        if (bullet != null)
        {
            bullet.transform.position = bulletposition.position;
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, GetEnemyRotation()); // Sử dụng hướng quay của enemy
            bullet.SetActive(true);
        }
    }

}
