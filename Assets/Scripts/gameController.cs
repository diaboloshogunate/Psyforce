using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public PlayerController[] players;
    public Canvas gameOverCanvas;
    public Canvas winCanvas;
    protected bool isGameOver = false;
    protected bool isWin = false;

    private PlayerController p1Script;
    private PlayerController p2Script;
    
    void Update() {
        if (HasDied() && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(gameOver(gameOverCanvas));
        }

        if(HasWon() && !isWin)
        {
            isWin = true;
            StartCoroutine(WinCanvasAndExit(winCanvas));
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }

    bool HasWon()
    {
        foreach (PlayerController player in players)
        {
            if (player.hasWon)
                return true;
        }
        return false;
    }

    bool HasDied()
    {
        foreach (PlayerController player in players)
        {
            if (!player.isAlive)
                return true;
        }
        return false;
    }

    IEnumerator gameOver(Canvas canvas)
    {
        isGameOver = true;
        Instantiate(canvas);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    IEnumerator WinCanvasAndExit(Canvas canvas)
    {
        Instantiate(canvas);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
