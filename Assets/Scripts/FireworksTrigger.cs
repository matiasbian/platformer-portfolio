using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool firstTime = true;
    bool firstTimePopUp = true;
    public AudioSource audioSource;
    public AudioClip victoryClip;
    void Start()
    {
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Firework")) {
            other.GetComponent<Fireworks>().StartAnim();
            if (firstTime) {
                audioSource.PlayOneShot(victoryClip);
                firstTime = false;
            }
        }

        if (other.CompareTag("Castle")) {
            if (firstTimePopUp) {
                PopUpManager.Get().ShowPopUpReset("thanks");
                firstTimePopUp = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Firework")) {
            other.GetComponent<Fireworks>().StopAnim();
        }
    }
}
