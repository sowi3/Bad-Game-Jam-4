using System.Collections;
using UnityEngine;

public class BOOLETKILLSYOU : MonoBehaviour
{
    private SphereCollider collider;
    public GameObject audioEmitter;
    public AudioClip aaahh;
    public AudioClip woahThatBulletAlmostHitMeThankfullyItOnlyHitTheWall;

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
        if (other.CompareTag("BlocksBullets"))
        {
            var pitch = Random.Range(0.5f, 2f);
            PlaySoundEffect(woahThatBulletAlmostHitMeThankfullyItOnlyHitTheWall, pitch, 1f, 50f);
            Destroy(gameObject);
        }
        else if (other.CompareTag("AIKillTarget") || other.CompareTag("Enemy"))
        {
            print(other.gameObject+" dies");
            var thisRigidbody = GetComponent<Rigidbody>();
            Destroy(other.gameObject, 0.25f);
            Vector3 fallVelocity = thisRigidbody.linearVelocity;
            fallVelocity.y = 0;
            other.attachedRigidbody.linearVelocity = fallVelocity.normalized * 10f + Vector3.down * 2f;
            other.attachedRigidbody.freezeRotation = false;
            other.GetComponent<Collider>().enabled = false;
            var pitch = Random.Range(0.5f, 2f);
            PlaySoundEffect(aaahh, pitch, 5f, 300f);
            Destroy(gameObject);
            
        } 
    }
        void PlaySoundEffect(AudioClip soundEffect, float pitch = 1, float minDistance = 10f, float maxDistance = 300f)
    {
        var newAudioEmitter = Instantiate(audioEmitter, transform.position, Quaternion.identity);
        AudioSource newAudioEmitterAudioSource = newAudioEmitter.GetComponent<AudioSource>();
        newAudioEmitterAudioSource.clip = soundEffect;
        newAudioEmitterAudioSource.pitch = pitch;
        newAudioEmitterAudioSource.minDistance = minDistance;
        newAudioEmitterAudioSource.maxDistance = maxDistance;
        newAudioEmitterAudioSource.Play();
        Destroy(newAudioEmitter, 10);
    }
}
