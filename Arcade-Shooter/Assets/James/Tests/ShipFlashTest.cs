using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShipFlashTest
{
    [Test]
    public void _1_TEST_SHIPFLASH_FUCTION_EXISTS()
    {
        //Spawn a Module
        GameObject Thruster = new GameObject();
        // Thruster.AddComponent<AnimShipFlash>();
        //run Module.AnimShipFlash.Flash();
        Thruster.GetComponent<AnimShipFlash>().Flash();
    }

    // //test default ship color isnt
    // public void _1_TEST_SHIP_DEFAULT_COLOR_NOT_WHITE()
    // {
    //     //Spawn a Module
    //     if()
    // }



    // A Test behaves as an ordinary method
    // [Test]
    // public void ShipFlashTestSimplePasses()
    // {
    //     // Use the Assert class to test conditions
    // }

    // // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // // `yield return null;` to skip a frame.
    // [UnityTest]
    // public IEnumerator ShipFlashTestWithEnumeratorPasses()
    // {
    //     // Use the Assert class to test conditions.
    //     // Use yield to skip a frame.
    //     yield return null;
    // }
}
