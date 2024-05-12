using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    int currentHealth;
    public int maxHealth;

    // ������ �� ������
    public Transform player;
    // ������ ��������� ����
    public GameObject fireballPrefab;
    // ������ ����������� ������
    public float detectionRadius = 10f;
    // �������� ��������� ����
    public float fireballSpeed = 5f;
    // ����� �����������
    public float cooldownTime = 2f;
    // ���� ������ ���������� � ��������
    public float fieldOfView = 90f;
    // ������ �����������
    private float cooldownTimer = 0f;
    // ����������, ��������, ����� �� ��������� ������
    private bool playerDetected = false;
    private FireBallCreate _fireBallCreate;

    void Awake()
    {
        _fireBallCreate = GameObject.Find("FireballCuster").GetComponent<FireBallCreate>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        { Death(); }
    }

    void Death()
    {
        // Death function
        // TEMPORARY: Destroy Object
        Destroy(gameObject);
    }


    void Update()
    {
        // ���������, ��������� �� ����� � ������� �����������
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            // ���������, ��������� �� ����� � ���� ������ ����������
            Vector3 directionToPlayer = player.transform.position - transform.position;
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleToPlayer <= fieldOfView / 2f)
            {
                
                // ��������� ��������� ������ � ������� Raycast
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer, out hit, detectionRadius))
                {
                  
                    if (hit.collider.gameObject == player.gameObject)
                    {
                        playerDetected = true;
                    }
                    else
                    {
                        playerDetected = false;
                    }
                }
            }
            else
            {
                playerDetected = false;
            }

            if (playerDetected)
            {
                // �������������� � ������ ������ �� ��� Y.
                // ��������� ����������� � ������, ��������� ������� � ������.
                Vector3 targetDirection = player.position - transform.position;
                targetDirection.y = 0f;

                // ������� �������, ������� ������� � ����������� �����������.
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

                // ������������ ������ ���������� � ������.
                transform.rotation = targetRotation;

                // �������� �������� �����, ���� ����������� ���������
                if (cooldownTimer <= 0f)
                {
                     _fireBallCreate.ShootFireball();

                    // ���������� ������ ����������� ����� ��������.
                    cooldownTimer = cooldownTime;
                }
            }
        }
        else
        {
            // ���� ����� ��� ������� �����������, ������������� playerDetected � false
            playerDetected = false;
        }

        // ��������� ������ ����������� ������ ����.
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

}
