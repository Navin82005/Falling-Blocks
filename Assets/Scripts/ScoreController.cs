using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreBoard;
    void Start()
    {
        FindObjectOfType<PlayerController>().OnCoinCollect += ScoreOnChange;
    }
    
    void ScoreOnChange()
    {
        int coins = FindObjectOfType<PlayerController>().coins;
        string text = "";
        if (coins < 10) {
            text += "00" + coins;
        } else if (coins < 100) {
            text += "0" + coins;
        }
        else {
            text += coins;
        }
        scoreBoard.text = text;
    }

}
