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

    // Ate� etmeyi ba�latan metod
    public void StartShooting(Vector3 targetPosition)
    {
        // Oyuncunun ShootingSystem'ine ate� et komutunu g�nder
        FindObjectOfType<ShootingSystem>().Shoot(targetPosition);
    }

    // Ate� etmeyi durduran metod
    public void StopShooting()
    {
        // Oyuncunun ShootingSystem'ine ate� etmeyi durdur komutunu g�nder
        FindObjectOfType<ShootingSystem>().StopShooting();
    }
}
