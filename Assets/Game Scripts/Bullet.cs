using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 20;  // Merminin verdiði hasar
    [SerializeField] private float bulletLifetime = 5f;  // Merminin yaþam süresi

    private void Start()
    {
        // Mermi sahneye çýktýðýnda, 5 saniye sonra yok edilmesi için Destroy iþlemini baþlat
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Eðer çarpan obje düþman ise
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Düþman üzerinde EnemyHealth componentini bul ve hasar ver
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);  // Hasarý uygula
            }

            // Mermiyi çarpýþma sonrasý sahneden kaldýr
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
