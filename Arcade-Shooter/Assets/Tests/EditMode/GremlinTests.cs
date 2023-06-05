using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{

    //Setup
    Ship testShip;
    Shotgun testGun;


    //This preps the ship to have all the required inventory slots
    [Test]
    public void setup()
    {
        testShip = new GameObject().AddComponent<Ship>();
        testShip.InventorySlot = new GameObject().AddComponent<Snappable>();

        testGun = new GameObject().AddComponent<Shotgun>();
        testShip.InventorySlot.Occupy(testGun);

        int counter = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int n = 0; n < 3; n++)
            {
                testShip.ModuleSnapPoints[n, i] = new GameObject().AddComponent<Snappable>();
                counter++;
            }
        }

        //validate default cursor positio
        Assert.AreEqual(testShip.getCursorXPos(), 0);
        Assert.AreEqual(testShip.getCursorYPos(), 0);

        //validate the inventory slot has been set to something
        Assert.AreNotEqual(testShip.InventorySlot, 0);

        //validate that the inventory slot has 
        Shotgun gun = (Shotgun)testShip.InventorySlot.GetEquipment();
        Assert.AreEqual(gun, testGun);
    }


    [Test]
    public void GremlinMoveRight()
    {
        setup(); //Setup the ship


        testShip.moveRight();
        Assert.AreEqual(testShip.getCursorXPos(), 1);
        Assert.AreEqual(testShip.getCursorYPos(), 0);

        testShip.moveRight();
        Assert.AreEqual(testShip.getCursorXPos(), 2);
        Assert.AreEqual(testShip.getCursorYPos(), 0);

        testShip.moveRight(); //Third move should stay in the same position as it is already as far as it can go
        Assert.AreEqual(testShip.getCursorXPos(), 2);
        Assert.AreEqual(testShip.getCursorYPos(), 0);
    }

    [Test]
    public void GremlinMoveLeft()
    {
        setup(); //Setup the ship
        GremlinMoveRight(); //Have to move right to move left


        testShip.moveLeft();
        Assert.AreEqual(testShip.getCursorXPos(), 1);
        Assert.AreEqual(testShip.getCursorYPos(), 0);

        testShip.moveLeft();
        Assert.AreEqual(testShip.getCursorXPos(), 0);
        Assert.AreEqual(testShip.getCursorYPos(), 0);

        testShip.moveLeft(); //Third move should stay in the same position as it is already as far as it can go
        Assert.AreEqual(testShip.getCursorXPos(), 0);
        Assert.AreEqual(testShip.getCursorYPos(), 0);
    }

    [Test]
    public void GremlinMoveDown()
    {
        setup(); //Setup the ship


        testShip.moveDown();
        Assert.AreEqual(testShip.getCursorXPos(), 0);
        Assert.AreEqual(testShip.getCursorYPos(), 1);

        testShip.moveDown();
        Assert.AreEqual(testShip.getCursorXPos(), 0);
        Assert.AreEqual(testShip.getCursorYPos(), 2);

        testShip.moveDown(); //Third move should stay in the same position as it is already as far as it can go
        Assert.AreEqual(testShip.getCursorXPos(), 0);
        Assert.AreEqual(testShip.getCursorYPos(), 2);
    }

    [Test]
    public void GremlinMoveUp()
    {
        setup(); //Setup the ship
        GremlinMoveDown(); //Have to move down to move up


        testShip.moveUp();
        Assert.AreEqual(testShip.getCursorXPos(), 0);
        Assert.AreEqual(testShip.getCursorYPos(), 1);

        testShip.moveUp();
        Assert.AreEqual(testShip.getCursorXPos(), 0);
        Assert.AreEqual(testShip.getCursorYPos(), 0);

        testShip.moveUp(); //Third move should stay in the same position as it is already as far as it can go
        Assert.AreEqual(testShip.getCursorXPos(), 0);
        Assert.AreEqual(testShip.getCursorYPos(), 0);
    }


    [Test]
    public void GremlinEquip()
    {
        setup(); //Setup the ship

        Shotgun shipEquipment = (Shotgun)testShip.getCursorSnapPoint().GetEquipment();
        Assert.AreNotEqual(shipEquipment, testGun); //Test that the slot doesn't have the gun
        testShip.equip();
        shipEquipment = (Shotgun)testShip.getCursorSnapPoint().GetEquipment();
        Assert.AreEqual(shipEquipment, testGun); //Test that the slot does have the gun

    }

    [Test]
    public void GremlinUnequip()
    {
        setup(); //Setup the ship
        GremlinEquip();

        Assert.AreEqual(testShip.getCursorSnapPoint().GetEquipment(), testGun); //Test that the slot does have the gun
        testShip.unequip();
        Assert.AreNotEqual(testShip.getCursorSnapPoint().GetEquipment(), testGun); //Test that the slot doesn't have the gun 

    }
}
