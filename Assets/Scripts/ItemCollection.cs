using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollection : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PickUpKey(other);
    }

    private void PickUpKey(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key")) {
            GameObject key = new GameObject();
            key.name = "Key";
            key.transform.parent = transform;
            
            var keyCell = ui.transform.Find("KeyCell").GetComponent<Image>();
            keyCell.fillAmount = 1;
            var keyImage = ui.transform.Find("KeyImage").GetComponent<Image>();
            keyImage.fillAmount = 1;
            keyImage.sprite = other.GetComponent<SpriteRenderer>().sprite;
            Destroy(other.gameObject);
        }
    }
}
