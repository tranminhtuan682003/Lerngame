using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> pooledObject = new List<GameObject>();
    private int amounttopool = 20;
    [SerializeField] private float timefire;
    [SerializeField] private GameObject bulletPrefab;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {
        for(int i = 0;i< amounttopool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObject.Add(obj);
        }
    }
    void Update()
    {
        
    }
    public GameObject GetpooledObject()
    {
        for (int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeSelf)
            {
                StartCoroutine(WaitFireThenActivate(pooledObject[i]));
                return pooledObject[i];
            }
        }
        return null;
    }

    IEnumerator WaitFireThenActivate(GameObject obj)
    {
        yield return new WaitForSeconds(timefire);
        obj.SetActive(true);
    }

}
