using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused = true;
    public static GameManager instance;
    public AudioClip pew;
    public AudioClip pickUp;
    public AudioSource source;
    public static GameManager sfxInstance;

    void Awake()
    {
        //Set instance
        instance = this;
        //If sfxInstance is not null and not equal to the "this" variable, return
        if (sfxInstance != null && sfxInstance != this)
        {
            return;
        }

        //Set sfxInstnance to "this"
        sfxInstance = this;
        //Don't destroy on load
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;
        GameUI.instance.TogglePauseMenu(gamePaused);
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void AddScore(int score)
    {
        curScore += score;
        GameUI.instance.UpdateScoreText(curScore);
        if(curScore >= scoreToWin)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        GameUI.instance.SetEndGame(true, curScore);
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoseGame()
    {
        GameUI.instance.SetEndGame(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}
