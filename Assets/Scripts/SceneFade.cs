using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 0f;
    private int fadeDir = -1;
    private bool isVisible = false;
    private string scene;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    void OnGUI()
    {
        if (!isVisible)
        {
            return;
        }

        Time.timeScale = 0;
        alpha += fadeDir * fadeSpeed * Time.unscaledDeltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);


        if (scene != null && alpha == 1f)
        {
            SceneManager.LoadScene(this.scene);
            FadeFrom();
        }

        if (alpha == 0f)
        {
            isVisible = false;
            Time.timeScale = 1f;
        }
    }
    
    public void FadeTo()
    {
        this.isVisible = true;
        this.fadeDir = 1;
        this.scene = null;
    }

    public void FadeTo(string scene)
    {
        this.isVisible = true;
        this.fadeDir = 1;
        this.scene = scene;
    }

    void FadeFrom()
    {
        this.fadeDir = -1;
        this.isVisible = true;
        this.scene = null;
    }
}
