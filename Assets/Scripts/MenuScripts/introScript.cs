using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class introScript : MonoBehaviour {

    public Canvas canvas;

    private VideoPlayer vPlayer;
    private VideoClip clip;
   
  

    private void Awake()
    {
        vPlayer = GetComponent<VideoPlayer>();
        vPlayer.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer vPlayer)
    {
        canvas.gameObject.SetActive(true);
    }
}
