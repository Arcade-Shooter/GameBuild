using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard
{

    private List<int> Scores; //Temporary placeholder. Will probably have a score record class

    public Scoreboard() 
    {
        Scores = new List<int>();
        ReadFromFile();//import scores // Maybe do this when loading the scoreboard rather than constantly
    }

    public void ReadFromFile()
    {

    }

    public void WritetoFile()
    {

    }
}
