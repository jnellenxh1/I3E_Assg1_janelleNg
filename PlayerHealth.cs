/*
* Author: Janelle Ng
* Date: 15-06-2025
*Description: Manages player health, damage handling, and respawn functionality with position reset
*/

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip damageSound; //Plays audio when player takes damage
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        UIManager.Instance?.TakeDamage(damage);
        
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
        }
        
        
        Debug.Log($"Player took {damage} damage!");
    }
}