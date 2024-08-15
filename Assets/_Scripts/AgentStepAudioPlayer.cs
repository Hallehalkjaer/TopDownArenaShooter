using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AgentStepAudioPlayer : MonoBehaviour
{
    
    protected AudioSource audioSource;

    [field: SerializeField]
    protected float pitchRandomness = 0.05f;
    protected float basepitch;

    [field: SerializeField]
    protected AudioClip stepClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        basepitch = audioSource.pitch;
    }

    protected void PlayClipWithVariablePitch(AudioClip clip)
    {
        var randomPitch = UnityEngine.Random.Range(-pitchRandomness, pitchRandomness);
        audioSource.pitch = basepitch + randomPitch;
        PlayClip(clip);
    }

    protected void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayStepSound()
    {
        PlayClipWithVariablePitch(stepClip);
    }
}
