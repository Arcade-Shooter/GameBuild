using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu
{

    private State MenuState; 
    
    public Menu()
    {
        MenuState = State.Start;
    }

    public void ChangeState(State ChangeTo)
    {
        MenuState = ChangeTo;
    }

}


public enum State
{
    Start,
    Menu,
    Settings,
    Scoreboard,
    Game,
    Pause
}