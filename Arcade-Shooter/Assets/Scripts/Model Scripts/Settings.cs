using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{

    private int SoundEffetLevel;
    private int MusicLevel;
    private float UIScale;

    public Settings()
    {
        SoundEffetLevel = 50; // Out of 100
        MusicLevel = 50; // Out of 100
        UIScale = 1.0f;
    }

    public void ReadFromFile()
    {

    } 

    public void WriteToFile() 
    {
        
    }
}
