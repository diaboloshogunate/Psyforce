using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneFade))]
public class gameController : MonoBehaviour {

    public PlayerController[] players;
    public static gameController instance = null;
 

    [Header("State transition canvases")]
    public Canvas gameOverCanvas;
    public Canvas winCanvas;
    public List<string> sceneNamesInOrder;


    protected bool isGameOver = false;
    protected bool isWin = false;

    private PlayerController p1Script;
    private PlayerController p2Script;

    private SceneFade fader;

    private void Awake()
    {

        this.fader = GetComponent<SceneFade>();
        // Ensure that if the instance of GameManager is not set, it is set to this instance.
        if (instance == null)
            instance = this;
        //If it is set, destroy this instance so there aren't two
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        if (HasDied() && !isGameOver)
        {
            isGameOver = true;
            Instantiate(gameOverCanvas);
        }

        if(HasWon() && !isWin)
        {
            isWin = true;
            fader.FadeTo(sceneNamesInOrder[0]);
            sceneNamesInOrder.RemoveAt(0);
            //Instantiate(winCanvas);
            //StartCoroutine(RestartGame());
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

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    private void OnLevelWasLoaded(int level)
    {
        this.isWin = false;
        this.isGameOver = false;
        players = FindObjectsOfType<PlayerController>();
    }
}
