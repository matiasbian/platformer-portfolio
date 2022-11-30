using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksTrigger : MonoBehaviour
{
    // Start is called before the first frame update
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
        }

        if (other.CompareTag("Castle")) {
            PopUpManager.Get().ShowPopUpReset("thanks");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Firework")) {
            other.GetComponent<Fireworks>().StopAnim();
        }
    }
}
