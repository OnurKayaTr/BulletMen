using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private DynamicJoystick dynamicJoystick;
    [SerializeField] private Transform playerChildTrnsfrm;
    [SerializeField] private float detectionRadius = 10f; // Düþmanlarý tespit etmek için yarýçap
    [SerializeField] private LayerMask enemyLayerMask; // Düþmanlarý tespit etmek için Layer Mask

    private float horizontal;
    private float vertical;
    private List<Transform> enemiesInRange = new List<Transform>();

    private void Update()
    {
        GetMovementInput();
        DetectEnemiesInRange();
    }

    private void FixedUpdate()
    {
        SetMovement();
        SetRotation();
    }

    private void SetMovement()
    {
        rigidbody.velocity = GetNewVelocity();
    }

    private void SetRotation()
    {
        if (horizontal != 0 || vertical != 0)
        {
            playerChildTrnsfrm.rotation = Quaternion.LookRotation(GetNewVelocity());
        }
    }

    private Vector3 GetNewVelocity()
    {
        return new Vector3(horizontal, rigidbody.velocity.y, vertical) * moveSpeed * Time.fixedDeltaTime;
    }

    private void GetMovementInput()
    {
        horizontal = dynamicJoystick.Horizontal;
        vertical = dynamicJoystick.Vertical;
    }

    private void DetectEnemiesInRange()
    {
        // Düþmanlarý tespit et
        Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayerMask);
        enemiesInRange.Clear();
        foreach (var enemy in enemies)
        {
            enemiesInRange.Add(enemy.transform);
        }

        // Düþmanlarý kontrol et ve bir hedef seç
        if (enemiesInRange.Count > 0)
        {
            // En yakýn düþmana bak
            Transform targetEnemy = enemiesInRange[0];

            // Düþman null deðilse ateþ et
            if (targetEnemy != null)
            {
                transform.LookAt(targetEnemy); // Düþmana bak
                GameManager.Instance.StartShooting(targetEnemy.position); // Ateþ etmeyi baþlat
            }
        }
        else
        {
            // Eðer düþman kalmadýysa ateþ etmeyi durdur
            GameManager.Instance.StopShooting();
        }
    }
}
