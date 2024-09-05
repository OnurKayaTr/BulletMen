using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 20;  // Merminin verdi�i hasar
    [SerializeField] private float bulletLifetime = 5f;  // Merminin ya�am s�resi

    private void Start()
    {
        // Mermi sahneye ��kt���nda, 5 saniye sonra yok edilmesi i�in Destroy i�lemini ba�lat
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // E�er �arpan obje d��man ise
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // D��man �zerinde EnemyHealth componentini bul ve hasar ver
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);  // Hasar� uygula
            }

            // Mermiyi �arp��ma sonras� sahneden kald�r
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
