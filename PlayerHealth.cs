/*
* Author: Janelle Ng
* Date: 15-06-2025
* Description: Handles player health and damage response with audio feedback.
*/

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip damageSound;
    private AudioSource audioSource; //plays hurt sound

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        UIManager.Instance?.TakeDamage(damage); //minus health in UIManager

        if (damageSound && audioSource)
            audioSource.PlayOneShot(damageSound);

        Debug.Log($"Player took {damage} damage!");
    }
}
