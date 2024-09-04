using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyRigidbody;  // D��man�n Rigidbody'si
    [SerializeField] private float moveSpeed;           // D��man�n hareket h�z�
    [SerializeField] private Transform playerTransform; // Oyuncunun Transform'u

    private void FixedUpdate()
    {
        // Oyuncunun pozisyonuna do�ru hareket et
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        enemyRigidbody.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);

        // Oyuncuya do�ru d�n
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, moveSpeed * Time.fixedDeltaTime);
        }
    }
}
