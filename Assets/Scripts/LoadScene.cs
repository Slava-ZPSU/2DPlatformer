using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private int LoadSceneWithId = 1;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            PlayerLife.DeathCount = 0;
            UIController.time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.gameObject.CompareTag("Treasure") && 
            other.gameObject.CompareTag("Player")) 
        {
            LoadSceneById();
        }
    }
    public void LoadSceneById()
    {
        SceneManager.LoadScene(LoadSceneWithId);
    }

}
