using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;  // Düþmanýn maksimum saðlýðý
    private int currentHealth;                     // Düþmanýn mevcut saðlýðý

    private void Start()
    {
        currentHealth = maxHealth;  // Saðlýðý maksimum deðerine ayarla
    }

    // Bu fonksiyon düþmana hasar verir
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;  // Saðlýktan hasar miktarýný çýkar

        if (currentHealth <= 0)
        {
            Die();  // Saðlýk 0 veya daha az ise öl
        }
    }

    // Ölüm iþlemi
    private void Die()
    {
        Debug.Log("Enemy died!");
        StartCoroutine(DestroyAfterDelay(3f));  // 3 saniye sonra düþmaný yok et
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);  // Düþmaný sahneden kaldýr
    }
}

