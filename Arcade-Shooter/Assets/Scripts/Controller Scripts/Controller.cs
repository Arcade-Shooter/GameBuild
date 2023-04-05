using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private Model Model { get; set; }
    private StartController StartController { get; set; }
    private MenuController MenuController { get; set; }
    private SettingsController SettingsController { get; set; }
    private ScoreboardController ScoreboardController { get; set; }
    private GameController GameController { get; set; }
    private EnemyController EnemyController { get; set; }
}
