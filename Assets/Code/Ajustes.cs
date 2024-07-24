using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ajustes : MonoBehaviour
{
    public GameObject optionsPanel;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void ToggleOptionsPanel()
    {
        bool isActive = !optionsPanel.activeSelf;
        optionsPanel.SetActive(isActive);
        Time.timeScale = isActive ? 0f : 1f;
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
