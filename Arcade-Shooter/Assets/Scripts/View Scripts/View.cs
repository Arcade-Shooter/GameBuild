using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{

    private Controller Controller { get; set; }
    private StartView StartView { get; set; }
    private MenuView MenuView { get; set; }
    private SettingsView SettingsView { get; set; }
    private ScoreboardView ScoreboardView { get; set; }
    private GameView GameView { get; set; }
    private PauseView PauseView { get; set; }  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
