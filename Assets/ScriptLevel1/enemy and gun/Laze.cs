using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laze : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 5f; // Khoảng thời gian giữa mỗi lần xuất hiện
    public float objectExistTime = 2f; // Thời gian tồn tại của đối tượng

    void Start()
    {
        // Bắt đầu coroutine để xuất hiện đối tượng
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            // Tạo một đối tượng mới tại vị trí của ObjectSpawner
            GameObject newObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

            // Đợi cho đến khi hết thời gian tồn tại của đối tượng
            yield return new WaitForSeconds(objectExistTime);

            // Hủy đối tượng sau khi tồn tại trong 2 giây
            Destroy(newObject);

            // Đợi cho đến khi hết thời gian giữa mỗi lần xuất hiện
            yield return new WaitForSeconds(spawnInterval - objectExistTime);
        }
    }
}
