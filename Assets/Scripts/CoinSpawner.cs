using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject fallingCoin;
    public int renderInterval = 1;
    float nextRenderTime;
    Vector2 screenSize;
    public static List<GameObject> fallingCoins;

    void Start()
    {
        screenSize = new Vector2(
            Camera.main.aspect * Camera.main.orthographicSize,
            Camera.main.orthographicSize
        );
        fallingCoins = new List<GameObject>();
    }

    void Update()
    {
        if (Time.time > nextRenderTime)
        {
            RenderCoin();
            nextRenderTime = Time.time + renderInterval;
        }
    }

    void RenderCoin()
    {
        Vector2 spanPosition = new Vector2(Random.Range(-screenSize.x, screenSize.x), screenSize.y);
        GameObject newGameObject = Instantiate(fallingCoin, spanPosition, Quaternion.identity);
        newGameObject.transform.parent = transform;

        fallingCoins.Add(newGameObject);

        if (fallingCoins != null)
        {
            if (fallingCoins[0].transform.position.y < -(screenSize.y))
            {
                Destroy(fallingCoins[0]);
                fallingCoins.RemoveAt(0);
            }
        }
    }
}
