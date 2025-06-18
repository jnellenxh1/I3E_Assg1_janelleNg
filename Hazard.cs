/*
* Author: Janelle Ng
* Date: 15-06-2025
* Description: Damages health upon touching the hazard, calling UIManager to handle damage
*/

using UnityEngine;

/// Damages health upon touching
public class Hazard : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player collides with the hazard
        {
            // Call UIManager directly to handle damage
            if (UIManager.Instance != null)
            {
                UIManager.Instance.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("UIManager.Instance is null! Make sure UIManager is in the scene.");
            }
        }
    }
}