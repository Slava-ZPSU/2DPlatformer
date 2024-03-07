using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject ui;
    [SerializeField]
    private Animator animator;

    public static int DeathCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ui = GameObject.Find("UICanvas");
        ui.transform.Find("DeathCounter").GetComponent<TextMeshProUGUI>().text = "Death count: " + DeathCount;
        animator = GetComponent<Animator>();
    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap")) {
            Die();
        }
        if (other.gameObject.CompareTag("PitFall")) {
            RestartLevel();
        }
    }

    private void Die()
    {
        //rb.bodyType = RigidbodyType2D.Static;
        rb.simulated = false;
        //RestartLevel();
        animator.SetTrigger("Death");
    }

    private void RestartLevel()
    {
        DeathCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
