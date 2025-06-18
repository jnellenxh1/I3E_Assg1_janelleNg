/*
* Author: Janelle Ng
* Date: 15-06-2025
* Description: Simple door opening/closing behavior with keycard 
*/

using UnityEngine;


public class Door : MonoBehaviour
{
    /// Whether the door is currently open
    private bool isOpen = false;

    /// Handle player entering door trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //Check if the player enters the door trigger area
        {
            // Check if UIManager exists and player has keycard and door isn't already open
            if (UIManager.Instance != null && UIManager.Instance.HasKeycard && !isOpen)
            {
                OpenDoor();
                UIManager.Instance.RemoveKeycard();
            }
            else if (!isOpen)
            {
                // Door is locked
                Debug.Log("Door is locked! Need a keycard.");
            }
        }
    }

    /// Open the door
    private void OpenDoor()
    {
        isOpen = true;
        
        // Simply deactivate the door GameObject to "open" it
        gameObject.SetActive(false);
        
        Debug.Log("Door opened with keycard!");
    }

    /// Public property to check if door is currently open
    public bool IsOpen 
    { 
        get { return isOpen; } 
    }

    /// Reset door to closed state 
    public void ResetDoor()
    {
        isOpen = false;
        gameObject.SetActive(true);
    }
}