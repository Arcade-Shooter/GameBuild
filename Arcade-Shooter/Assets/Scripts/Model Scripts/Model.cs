using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{

    private View View { get; set; } [SerializeField]
   
    private Menu Menu { get; set; }
    private Settings Settings { get; set; }
    private Scoreboard Scoreboard { get; set; }
    private Game Game { get; set; }
}
