/*
* Author: Janelle Ng
* Date: 15-06-2025
* Description: Handles keycard pickup, differentiating between real and fake.
*/

using UnityEngine;
using UnityEngine.UI;

public class Keycard : MonoBehaviour
{
    public bool isReal = false; //Check if the keycard is real or fake
    public float fakeDuration = 2f; // Duration to show fake keycard message
    public Text fakeKeycardText;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isReal)
        {
            UIManager.Instance?.AddKeycard();
            Destroy(gameObject); //Delete if the keycard is taken

        }
        else
        {
            if (fakeKeycardText)
            {
                fakeKeycardText.text = "Fake keycard!";
                fakeKeycardText.gameObject.SetActive(true);
                StartCoroutine(HideFakeMessage());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private System.Collections.IEnumerator HideFakeMessage()
    {
        yield return new WaitForSeconds(fakeDuration);
        fakeKeycardText?.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
