/*
* Author: Janelle Ng
* Date: 15-06-2025
* Description: Manages coin collection, awarding points to the player and destroying the coin object
*/

using UnityEngine;

/// Gives points and destroys the coin upon touching the player
public class CoinBehaviour : MonoBehaviour
{
    public int points = 5;

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player")) //Only respond to player 
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.AddPoints(points);
        }
        else
        {
            Debug.LogWarning("UIManager.Instance is null!"); //check if UIManager is initialized
        }
        Destroy(gameObject);
    }
}
}   