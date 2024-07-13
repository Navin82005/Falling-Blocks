using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    public float screenHalfWidth;
    public int coins;
    public event System.Action OnPlayerDeath, OnCoinCollect;

    void Start()
    {
        float playerWidth = transform.localScale.x / 2f;
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + playerWidth;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Vector2 velocity = input * speed * Time.deltaTime;
        transform.Translate(velocity);

        if (transform.position.x < -screenHalfWidth) {
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        }
        if (transform.position.x > screenHalfWidth) {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Falling Block")
        {
            Destroy(gameObject);
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
            }
        }

        if (collider.tag == "Coin") {
            coins += 1;
            if (OnCoinCollect != null) {
                OnCoinCollect();
            }
            Destroy(collider.gameObject);
            CoinSpawner.fallingCoins.RemoveAt(0);
        }
    }
}
