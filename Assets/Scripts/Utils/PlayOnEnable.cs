using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEnable : MonoBehaviour
{
    public AudioSource audioSource;
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        audioSource.Play();
    }
}
