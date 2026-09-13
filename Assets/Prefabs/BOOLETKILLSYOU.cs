using System.Collections;
using UnityEngine;

public class BOOLETKILLSYOU : MonoBehaviour
{
    private SphereCollider collider;
    public GameObject audioEmitter;
    public AudioClip aaahh;

    void Start()
    {
        collider = GetComponent<SphereCollider>();
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(0.15f);
        collider.enabled = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            print("die");
            Destroy(other.gameObject);
            PlaySoundEffect(aaahh);
        }
    }
        void PlaySoundEffect(AudioClip soundEffect, float pitch = 1)
    {
        var newAudioEmitter = Instantiate(audioEmitter, transform);
        AudioSource newAudioEmitterAudioSource = newAudioEmitter.GetComponent<AudioSource>();
        newAudioEmitterAudioSource.clip = soundEffect;
        newAudioEmitterAudioSource.pitch = pitch;
        newAudioEmitterAudioSource.Play();
        Destroy(newAudioEmitter, 10);
    }
}
