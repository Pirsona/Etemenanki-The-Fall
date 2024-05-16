using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Actor : MonoBehaviour
{
    int currentHealth;
    public int maxHealth;
    
    public string NumberOFEnemy;

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
    private Actor _actor;
    private CapsuleCollider _capsuleCollider;
    public Animator animator;
    

    void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _actor = GetComponent<Actor>();
        _fireBallCreate = GameObject.Find("FireballCuster"+NumberOFEnemy).GetComponent<FireBallCreate>();
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
        animator.SetBool("die", true);
          _actor.enabled = false;
        _capsuleCollider.enabled = false;
        
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
                animator.SetBool("ReadyToAttack", true);
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
            animator.SetBool("ReadyToAttack", false);
            animator.SetBool("idle", true);
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
