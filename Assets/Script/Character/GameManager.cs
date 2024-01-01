using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    private bool isPaused = false;

    public static GameManager Instance;
    public static event Action<int> LevelLoaded;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void GameOver()
    {
        if (!gameOverUI.activeSelf)
        {
            Time.timeScale = 0f; // Pause the game
            gameOverUI.SetActive(true); // show the game over UI
        }
    }
    
    public void RestartGame() // load scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;  // pause the game 
        }
    }

    public void ReturnToGame() // return after pause
    {
        Time.timeScale = 1f;
    }

    public virtual void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.StartsWith("Level"))
        {
            LevelLoaded?.Invoke(scene.buildIndex);
        }
    }
}