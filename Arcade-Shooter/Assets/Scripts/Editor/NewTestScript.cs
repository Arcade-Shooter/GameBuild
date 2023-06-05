using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{

    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        int a = 2;
        int b = 3;
        Assert.AreEqual(a + b, 5);
        // Use the Assert class to test conditions
    }

    [Test]
    public void EnemyShootBackTest(){
        //generate a enemy ship
        GameObject enemyShip = new GameObject();
        //set the enemy ship position
        enemyShip.transform.position = new Vector3(0, 0, 0);
        //add scripts to the enemy ship
        enemyShip.AddComponent<EnemyShipController>();
        //give a bullet prefab to the enemy ship
        enemyShip.GetComponent<EnemyShipController>().Bullet = Resources.Load<GameObject>("Assets/Prefabs/Bullets/EnemyBullet.prefab");
        //call the shoot function
        enemyShip.GetComponent<EnemyShipController>().EnemyShoot();
        //set a null bullet to recieve the bullet that shoot from the enemy ship
        GameObject bullet = null;
        //find all the objects in the scene
        UnityEngine.Object[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();   //get all objects in the scene

        foreach (var obj in allObjects) //loop through all objects in the scene
        {
            if (obj.name == "EnemyBullet(Clone)")   //if the object is the bullet
            {
                bullet = obj as GameObject; //get the bullet
            }
        }

        Assert.IsNotNull(bullet);   //check if the bullet is not null

    }

    [Test]
    public void MusicVolumeAdjustTest(){
        //generate a music player
        GameObject musicPlayer = new GameObject();
        //add scripts to the music player
        musicPlayer.AddComponent<VolumeControl>();
        //set the music player's master volume to 0
        musicPlayer.GetComponent<VolumeControl>().SetMasterVolume(0f);
        //check if the master volume is 0
        Assert.AreEqual(musicPlayer.GetComponent<VolumeControl>().GetMasterVolume(), 0f);
        //set the music player's master volume to 1
        musicPlayer.GetComponent<VolumeControl>().SetMasterVolume(-2f);
        //check if the master volume is 1
        Assert.AreEqual(musicPlayer.GetComponent<VolumeControl>().GetMasterVolume(), -2f);
    }

    
}
