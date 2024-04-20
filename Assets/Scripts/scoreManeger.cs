using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class scoreManeger : MonoBehaviour
{
    public static scoreManeger Instance;

    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text player3ScoreText;

    int player1Score = 0;
    int player2Score = 0;
    int player3Score = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        player1ScoreText.text = player1Score.ToString() + " points";
        player2ScoreText.text = player2Score.ToString() + " points";
        player3ScoreText.text = player3Score.ToString() + " points";
    }

  
    public void AddPoint(int playerType)
    {
        if (playerType == 1)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString() + " points";
        }
        else if (playerType == 2)
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString() + " points";
        }
        else if (playerType == 3) 
        {
            player3Score++;
            player3ScoreText.text = player3Score.ToString() + " points";
        }
        else
        {
            print("No player?: " + playerType.ToString());
        }
    }
}
