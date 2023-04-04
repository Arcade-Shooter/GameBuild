using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game
{

    private Ship Player;
    private int Score;
    private float TimeAlive; //Possible change this to a time component
    private List<Enemy> EnemyList;
    private int Energy;
    private int MaxEnergy;

    public Game()
    {
        this.Player = new Ship();
        this.Score = 0;
        this.TimeAlive = 0;
        this.EnemyList = new List<Enemy>();
        this.Energy = 0;
        this.MaxEnergy = 500;// Magic number
    }

    public void IncrementTime()
    {
        //Increment time
    }

    public void IncreaseScore(int score)
    {
        this.Score += score;
    }
}
