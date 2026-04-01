using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : LoadMonoBehaviour
{
    private static SoundsManager instance;
    public static SoundsManager Instance => instance;

    [Header("Audio Sources")]
    [SerializeField] protected AudioSource audioSource;

    [Header("Audio Clips")]
    [SerializeField] protected AudioClip wingSound;
    [SerializeField] protected AudioClip hitSound;
    [SerializeField] protected AudioClip pointSound;

    protected override void Awake()
    {
        base.Awake();
        if (SoundsManager.instance != null) Debug.LogError("Only 1 SoundsManager allow to exist");
        SoundsManager.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioSource();
        this.LoadWingSound();
        this.LoadHitSound();
        this.LoadPointSound();
    }

    protected virtual void LoadAudioSource()
    {
        if (this.audioSource != null) return;
        this.audioSource = GetComponent<AudioSource>();
        Debug.LogWarning(transform.name + ": LoadAudioSource", gameObject);

        this.audioSource.playOnAwake = false;
    }

    protected virtual void LoadWingSound()
    {
        if (this.wingSound != null) return;
        this.wingSound = Resources.Load<AudioClip>("Audio/wing");
        Debug.LogWarning(transform.name + ": LoadWingSound", gameObject);
    }

    protected virtual void LoadHitSound()
    {
        if (this.hitSound != null) return;
        this.hitSound = Resources.Load<AudioClip>("Audio/hit");
        Debug.LogWarning(transform.name + ": LoadHitSound", gameObject);
    }

    protected virtual void LoadPointSound()
    {
        if (this.pointSound != null) return;
        this.pointSound = Resources.Load<AudioClip>("Audio/point");
        Debug.LogWarning(transform.name + ": LoadPointSound", gameObject);
    }

    public void PlayWing()
    {
        this.audioSource.PlayOneShot(this.wingSound);
    }

    public void PlayHit()
    {
        this.audioSource.PlayOneShot(this.hitSound);
    }

    public void PlayPoint()
    {
        this.audioSource.PlayOneShot(this.pointSound);
    }
}
