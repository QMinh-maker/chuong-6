using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint;
    public int healthPoint;
    public System.Action onDead;
    public System.Action onHealthChanged;


    private void Start()
    {
        healthPoint = defaultHealthPoint;
        onHealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;
        onHealthChanged?.Invoke();
        if (healthPoint <= 0) Die();
    }

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
        
    }


    protected virtual void Die()
    {
        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1);       
        Destroy(gameObject);
        onDead?.Invoke();
    }
}


