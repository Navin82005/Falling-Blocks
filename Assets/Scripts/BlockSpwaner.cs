using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpwaner : MonoBehaviour
{
    public GameObject fallingBlock;
    public int renderInterval = 1;
    float nextRenderTime;
    Vector2 screenSize;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;
    List<GameObject> fallingBlocks;

    void Start()
    {
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        fallingBlocks = new List<GameObject>();
    }

    void Update()
    {
        if (Time.time > nextRenderTime)
        {
            RenderBlock();
            nextRenderTime = Time.time + renderInterval;
        }
    }

    void RenderBlock()
    {
        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
        float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        Vector2 spanPosition = new Vector2(Random.Range(-screenSize.x, screenSize.x), screenSize.y + spawnSize);
        GameObject newGameObject = Instantiate(fallingBlock, spanPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
        newGameObject.transform.localScale = Vector2.one * spawnSize;
        newGameObject.transform.parent = transform;
        
        fallingBlocks.Add(newGameObject);

        if (fallingBlocks[0].transform.position.y < -(screenSize.y + spawnSize)) {
            Destroy(fallingBlocks[0]);
            fallingBlocks.RemoveAt(0);
        }
    }
}
