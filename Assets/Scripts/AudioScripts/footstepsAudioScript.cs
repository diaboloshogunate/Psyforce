using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepsAudioScript : MonoBehaviour {
    public AudioClip[] footstepClips;

    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        Debug.Log("!!!! Got animator");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(animator.GetCurrentAnimatorClipInfo(0).ToString());
	}
}
