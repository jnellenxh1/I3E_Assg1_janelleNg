/*
* Author: Janelle Ng
* Date: 15-06-2025
* Description: Manages keycard collection, distinguishing between real and fake keycards, and displaying messages accordingly
*/

using UnityEngine;
using UnityEngine.UI;

public class Keycard : MonoBehaviour
{
    public bool isReal = false; // Indicates if the keycard is real or fake
    public float fakeDuration = 2f; 
    public Text fakeKeycardText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //Check if the player collides with the keycard 
        {
            if (isReal)
            {
                UIManager.Instance?.AddKeycard();
                Destroy(gameObject);
            }
            else
            {
                if (fakeKeycardText != null)
                {
                    fakeKeycardText.text = "Fake keycard!"; //If its fake it will display a message
                    fakeKeycardText.gameObject.SetActive(true);
                    StartCoroutine(HandleFakeKeycard());
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    /// handles fake keycard
    private System.Collections.IEnumerator HandleFakeKeycard()
    {
        yield return new WaitForSeconds(fakeDuration);

        if (fakeKeycardText != null)
        {
            fakeKeycardText.gameObject.SetActive(false);
        }

        Destroy(gameObject);
    }
}