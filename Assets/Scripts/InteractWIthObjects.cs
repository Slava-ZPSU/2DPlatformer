using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractWIthObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    private Collider2D door = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door")) {
            door = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door")) {
            door = null;
        }
    }

    void OnInteract()
    {
        if (door != null) {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (transform.Find("Key")) {
            Debug.Log("Door opened");
            ui.transform.Find("EventText").GetComponent<TextMeshProUGUI>().text = "Door opened";
            ui.transform.Find("KeyImage").GetComponent<Image>().sprite = null;
            door.gameObject.GetComponent<LoadScene>().LoadSceneById();
        } else {
            Debug.Log("You need a key to open the door");
            ui.transform.Find("EventText").GetComponent<TextMeshProUGUI>().text = "You need a key to open the door";
        }
    }
}
