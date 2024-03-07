using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static float time = 0;
    private bool runTimer = false;

    void Start()
    {
        if (transform.Find("DeathCounter") != null) {
            transform.Find("DeathCounter").GetComponent<TextMeshProUGUI>().text = "Death: " + PlayerLife.DeathCount;
        }

        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Final") { 
            runTimer = false;
        } else {
            runTimer = true;
        }

        if (transform.Find("FinalTime") != null) {
            transform.Find("FinalTime").GetComponent<TextMeshProUGUI>().text = "Time: " + time.ToString("F2");
        }
    }
    private void Update()
    {
        if (runTimer) {
            time += Time.deltaTime;
        }
        if (transform.Find("Timer") != null) {
            transform.Find("Timer").GetComponent<TextMeshProUGUI>().text = time.ToString("F2");
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
