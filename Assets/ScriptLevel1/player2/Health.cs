using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider health;
    public void TakeDamgae(float damage)
    {
        health.value -= damage / 500;
    }
}
