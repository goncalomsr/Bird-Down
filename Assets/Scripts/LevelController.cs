using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private bool gameStart = false;
    private int gameStartCountdown = 3;

    public EnemySpawnController enemySpawnController;

    public int playerPoints = 0;
    public int displayedPoints = 0;
    public Text pointsUI;


    public int waveID;
    public int numberOfEnemies;

    private void Start()
    {
        StartOfGame();
        gameStart = true;
    }

    private void Update()
    {
        pointsUI.text = playerPoints.ToString();
    }

    // Countdown??
    public void StartOfGame()
    {
        new WaitForSeconds(3f);
    }

    public void IncrementPoints()
    {
        playerPoints++;
        print(playerPoints);
    }
}
