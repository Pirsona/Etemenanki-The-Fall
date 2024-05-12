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
        // ������� ��������� ��������� ���� �� �������.
        // ���� ��� ���������� � ������� ����������.
        GameObject fireball = Instantiate(_actor.fireballPrefab, transform.position, Quaternion.identity);

        // �������� ��������� Rigidbody ��������� ����.
        Rigidbody fireballRigidbody = fireball.GetComponent<Rigidbody>();

        // ��������� ����������� � ������ � ������ aimHeightOffset.
        Vector3 targetPosition = _actor.player.position + Vector3.up * aimHeightOffset;
        Vector3 direction = (targetPosition - transform.position).normalized;

        // ������� ��������� ���� �������� � ������ �����������.
        fireballRigidbody.velocity = direction * _actor.fireballSpeed * Time.deltaTime;
    }
}
