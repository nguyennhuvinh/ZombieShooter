using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthPickupController : MonoBehaviour
{
    public float healthAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Check if the player's current health is less than their full health
            if (playerHealth.currentHealth  < playerHealth.fullHealth)
            {
                AudioManager.instance.PlayeSoundHealthBell();
                playerHealth.addHealth(healthAmount);
                Destroy(transform.root.gameObject);
            }
        }
    }
}
