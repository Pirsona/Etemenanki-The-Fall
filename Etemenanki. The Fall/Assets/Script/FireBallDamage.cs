using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDamage : MonoBehaviour
{
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerController.gameObject == other.gameObject) 
        {
            playerController.lifes = false;
        }
        else
        {
          Destroy(gameObject);
        }
    }
}
