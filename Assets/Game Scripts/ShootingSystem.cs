using System.Collections;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.5f; // Ateþ etme sýklýðý
    private bool isShooting = false;

    public void Shoot(Vector3 targetPosition)
    {
        if (!isShooting)
        {
            StartCoroutine(ShootCoroutine(targetPosition));
        }
    }

    public void StopShooting()
    {
        StopAllCoroutines();
        isShooting = false;
    }

    private IEnumerator ShootCoroutine(Vector3 targetPosition)
    {
        isShooting = true;

        while (isShooting)
        {
            // Hedef pozisyon ile ateþ noktasýnýn farkýný alarak yön belirle
            Vector3 direction = (targetPosition - firePoint.position).normalized;

            // Mermi prefabýný sahneye instantiate et
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Rigidbody bileþenini al ve mermiyi hareket ettir
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = direction * 20f; // Mermi hýzý
            }

            // Merminin yok edilip edilmediðini kontrol et
            if (bullet != null)
            {
                Destroy(bullet, 5f);  // Mermiyi 5 saniye sonra yok et
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
}
