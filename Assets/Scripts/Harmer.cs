using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmer : MonoBehaviour
{
    public Sprite sprite;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            //collision.gameObject.GetComponent<PlayerController>().spriteRenderer.sprite = sprite;
        }
    }
}