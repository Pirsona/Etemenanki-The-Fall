using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParticleDamage : MonoBehaviour
{
    private PlayerController playerController;
    private CapsuleCollider capsuleCollider;
    public ParticleSystem particleSystem;
    public float timeToActive;
    public float timetoDeactivate;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(ToggleCoroutine());
    }

    private void Update()
    {
    }

    private IEnumerator ToggleCoroutine()
    {
        while (true)
        {
            // Включаем объект
            particleSystem.Play();
            capsuleCollider.enabled = true;
            yield return new WaitForSeconds(timeToActive / 2);

            // Отключаем объект
            particleSystem.Stop();
            capsuleCollider.enabled = false;
            yield return new WaitForSeconds(timeToActive / 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
        {
            playerController.lifes = false;
        }
    }

 
}
