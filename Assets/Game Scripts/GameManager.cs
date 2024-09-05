using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Ateþ etmeyi baþlatan metod
    public void StartShooting(Vector3 targetPosition)
    {
        // Oyuncunun ShootingSystem'ine ateþ et komutunu gönder
        FindObjectOfType<ShootingSystem>().Shoot(targetPosition);
    }

    // Ateþ etmeyi durduran metod
    public void StopShooting()
    {
        // Oyuncunun ShootingSystem'ine ateþ etmeyi durdur komutunu gönder
        FindObjectOfType<ShootingSystem>().StopShooting();
    }
}
