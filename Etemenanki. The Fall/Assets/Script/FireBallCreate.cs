using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCreate : MonoBehaviour
{
    private Actor _actor;
    public float aimHeightOffset = 5f;

    private void Awake()
    {
        _actor = GameObject.Find("Enemy").GetComponent<Actor>();
    }
    public void ShootFireball()
    {
        // Создаем экземпляр огненного шара из префаба.
        // Новы шар появляется в позиции противника.
        GameObject fireball = Instantiate(_actor.fireballPrefab, transform.position, Quaternion.identity);

        // Получаем компонент Rigidbody огненного шара.
        Rigidbody fireballRigidbody = fireball.GetComponent<Rigidbody>();

        // Вычисляем направление к игроку с учетом aimHeightOffset.
        Vector3 targetPosition = _actor.player.position + Vector3.up * aimHeightOffset;
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Придаем огненному шару скорость в нужном направлении.
        fireballRigidbody.velocity = direction * _actor.fireballSpeed * Time.deltaTime;
    }
}
