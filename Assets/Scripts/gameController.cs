using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public Canvas gameOverCanvas;

    private PlayerController p1Script;
    private PlayerController p2Script;
    

	// Use this for initialization
	void Start () {
        p1Script = player1.GetComponent<PlayerController>();
        p2Script = player2.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        if (!p1Script.isAlive || !p2Script.isAlive)
        {
            gameOverCanvas.gameObject.SetActive(true);
            Animation anim = gameOverCanvas.GetComponent<Animation>();
            StartCoroutine(gameOver(anim));
        }
    }

    IEnumerator gameOver(Animation anim)
    {
        anim.Play();
        // This is awful but I'm not sure what to do about it.
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
