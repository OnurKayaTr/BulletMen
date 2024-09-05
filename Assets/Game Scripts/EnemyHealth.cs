using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;  // D��man�n maksimum sa�l���
    private int currentHealth;                     // D��man�n mevcut sa�l���

    private void Start()
    {
        currentHealth = maxHealth;  // Sa�l��� maksimum de�erine ayarla
    }

    // Bu fonksiyon d��mana hasar verir
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;  // Sa�l�ktan hasar miktar�n� ��kar

        if (currentHealth <= 0)
        {
            Die();  // Sa�l�k 0 veya daha az ise �l
        }
    }

    // �l�m i�lemi
    private void Die()
    {
        Debug.Log("Enemy died!");
        StartCoroutine(DestroyAfterDelay(3f));  // 3 saniye sonra d��man� yok et
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);  // D��man� sahneden kald�r
    }
}

