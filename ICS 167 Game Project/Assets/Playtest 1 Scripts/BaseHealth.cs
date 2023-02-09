using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Joshua Tyan, Kevin Rogan

//holds all the character's base health
//
public class BaseHealth : MonoBehaviour
{
    //public static float baseHP = 20f;
    
    private float archerHP = 20f;
    private float knightHP = 24f;
    private float mageHP = 14f;
    private float priestHP = 18f;
    private float witchHP = 16f;

    //constructor for base hp
    public BaseHealth()
    {

    }

    //returns archer's base hp
    public float getArcherHP()
    {
        return archerHP;
    }

    //returns knight's base hp
    public float getKnightHP()
    {
        return knightHP;
    }

    //returns mage's base hp
    public float getMageHP()
    {
        return mageHP;
    }

    //returns priest's base hp
    public float getPriestHP()
    {
        return priestHP;
    }

    //returns witch's base hp
    public float getWitchHP()
    {
        return witchHP;
    }
}