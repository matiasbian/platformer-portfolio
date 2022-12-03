using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public ParticleSystem[] fireworks;
    bool startAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnim () {
        if (startAnim) return;
        StartCoroutine(StartFireworks());
    }

    public void StopAnim () {
        StopAllCoroutines();
        startAnim = false;
    }

    IEnumerator StartFireworks () {
        while (true) {
            int randomIndex = Random.Range(0, fireworks.Length);
            fireworks[randomIndex].Play();
            source.PlayOneShot(clip);
            float randomWait = Random.Range(0.2f, 0.6f);
            yield return new WaitForSeconds(randomWait);
        }
    }
}
