using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    int currentHealth;
    public int maxHealth;

    // Ссылка на игрока
    public Transform player;
    // Префаб огненного шара
    public GameObject fireballPrefab;
    // Радиус обнаружения игрока
    public float detectionRadius = 10f;
    // Скорость огненного шара
    public float fireballSpeed = 5f;
    // Время перезарядки
    public float cooldownTime = 2f;
    // Угол обзора противника в градусах
    public float fieldOfView = 90f;
    // Таймер перезарядки
    private float cooldownTimer = 0f;
    // Переменная, хранящая, видит ли противник игрока
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
        // Проверяем, находится ли игрок в радиусе обнаружения
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Проверяем, находится ли игрок в поле зрения противника
            Vector3 directionToPlayer = player.transform.position - transform.position;
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleToPlayer <= fieldOfView / 2f)
            {
                
                // Проверяем видимость игрока с помощью Raycast
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
                // Поворачиваемся к игроку только по оси Y.
                // Вычисляем направление к игроку, игнорируя разницу в высоте.
                Vector3 targetDirection = player.position - transform.position;
                targetDirection.y = 0f;

                // Создаем поворот, который смотрит в вычисленном направлении.
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

                // Поворачиваем объект противника к игроку.
                transform.rotation = targetRotation;

                // Стреляем огненным шаром, если перезарядка завершена
                if (cooldownTimer <= 0f)
                {
                     _fireBallCreate.ShootFireball();

                    // Сбрасываем таймер перезарядки после выстрела.
                    cooldownTimer = cooldownTime;
                }
            }
        }
        else
        {
            // Если игрок вне радиуса обнаружения, устанавливаем playerDetected в false
            playerDetected = false;
        }

        // Уменьшаем таймер перезарядки каждый кадр.
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

}
