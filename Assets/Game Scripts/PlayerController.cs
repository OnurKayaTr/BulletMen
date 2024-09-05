using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private DynamicJoystick dynamicJoystick;
    [SerializeField] private Transform playerChildTrnsfrm;
    [SerializeField] private float detectionRadius = 10f; // D��manlar� tespit etmek i�in yar��ap
    [SerializeField] private LayerMask enemyLayerMask; // D��manlar� tespit etmek i�in Layer Mask

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
        // D��manlar� tespit et
        Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayerMask);
        enemiesInRange.Clear();
        foreach (var enemy in enemies)
        {
            enemiesInRange.Add(enemy.transform);
        }

        // D��manlar� kontrol et ve bir hedef se�
        if (enemiesInRange.Count > 0)
        {
            // En yak�n d��mana bak
            Transform targetEnemy = enemiesInRange[0];

            // D��man null de�ilse ate� et
            if (targetEnemy != null)
            {
                transform.LookAt(targetEnemy); // D��mana bak
                GameManager.Instance.StartShooting(targetEnemy.position); // Ate� etmeyi ba�lat
            }
        }
        else
        {
            // E�er d��man kalmad�ysa ate� etmeyi durdur
            GameManager.Instance.StopShooting();
        }
    }
}
