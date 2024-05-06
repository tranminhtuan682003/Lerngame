using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanongunController : MonoBehaviour
{
    [SerializeField] private float HealthCanon, MaxHealthCanon;
    void Start()
    {
        HealthCanon = MaxHealthCanon;
    }
    public void TakeDamage(int amount)
    {
        HealthCanon -= amount;
        if(HealthCanon <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bulletplayer")
        {
            TakeDamage(5);
        }
    }
}
