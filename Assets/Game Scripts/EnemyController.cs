using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyRigidbody;  // Düþmanýn Rigidbody'si
    [SerializeField] private float moveSpeed;           // Düþmanýn hareket hýzý
    [SerializeField] private Transform playerTransform; // Oyuncunun Transform'u

    private void FixedUpdate()
    {
        // Oyuncunun pozisyonuna doðru hareket et
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        enemyRigidbody.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);

        // Oyuncuya doðru dön
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, moveSpeed * Time.fixedDeltaTime);
        }
    }
}
