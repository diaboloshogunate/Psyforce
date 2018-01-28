using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepsAudioScript : MonoBehaviour {
    public AudioClip footstepClip1;
    public AudioClip footsetpClip2;

    private AudioSource audioSource;
    private AudioClip currentClip;

    private Animator animator;
    // Use this for initialization
    void Awake() {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("!!!! Got animator");
        currentClip = footstepClip1;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).ToString());
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("player - 1 - walk"))
        {
            audioSource.clip = currentClip;
            audioSource.PlayOneShot(currentClip);
            Debug.Log("Clip Played?!");
        }
    }
}