
using TreeEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class FPSMovementScript : MonoBehaviour
{
    private static readonly int GunShootHash = Animator.StringToHash("GunShoot");
    public float moveSpeed;
    public float rotateSpeed;

    public GameObject BOLLET;
    public AudioClip[] shootSounds;
    public AudioClip reloadSound;
    public GameObject audioEmitter;
    private float attackCooldown;
    public Animator _animator;
    public ParticleSystem _particleEmitter;

    private int ammo = 25;

    public void Move(float value)
    {
        transform.position += transform.forward * value * moveSpeed;
    }
    public void Rotate(float value)
    {
        Vector3 shit = transform.up * value;
        transform.Rotate(shit * rotateSpeed);
    }

    private bool attacking;
    public void Shoot()
    {
        if (ammo > 0)
        {
            if (attackCooldown <= 0)
            {
                attacking = true;
                _animator.SetBool("Shooting", true);
                ammo--;
                _particleEmitter.Play();
                Vector3 spawnPos = transform.position + transform.right * 0.25f + transform.up * 0.4f;
                var newBullet = Instantiate(BOLLET, spawnPos, transform.rotation);
                float bulletVelocity = Random.Range(10f, 100f);
                float bulletSpread = Random.Range(-1f, 1f);

                newBullet.GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletVelocity + transform.right * bulletSpread;
                Destroy(newBullet, 4);
                var soundClip = shootSounds[Random.Range(0, shootSounds.Length)];
                float pitch = Random.Range(1f,1.2f);
                PlaySoundEffect(soundClip, pitch);
                attackCooldown = 0.05f;
            }
        }
        else
        {
            _animator.SetBool("Shooting", false);
            _animator.Play("Reloading");
            PlaySoundEffect(reloadSound);
            ammo = 19;
            attackCooldown = 3.8f;
        }
    }
    void FixedUpdate()
    {
        attackCooldown -= Time.fixedDeltaTime;
        if (attackCooldown <= 0 && attacking == true)
        {
            attacking = false;
            _animator.SetBool("Shooting", false);
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
