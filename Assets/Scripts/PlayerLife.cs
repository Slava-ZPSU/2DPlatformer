using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        rb.simulated = false;
        animator.SetTrigger("Death");
    }

    private void RestartLevel()
    {
        DeathCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
