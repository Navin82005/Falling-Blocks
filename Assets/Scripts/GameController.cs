using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text scorePoints;
    bool isGameOver;

    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += GameOver;
    }

    void Update()
    {
        if (isGameOver) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
            }
        }
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        scorePoints.text = FindObjectOfType<PlayerController>().coins.ToString();
        isGameOver = true;
    }
}
