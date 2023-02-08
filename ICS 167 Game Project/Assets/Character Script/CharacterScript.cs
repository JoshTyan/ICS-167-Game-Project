using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterScript : MonoBehaviour
{
    private int maxHealth = 20;
    private int damage = 2;
    private int currentHealth;
    private int movement = 5;
    private int action = 2;
    [SerializeField]
    private Sprite characterArt;

    protected CharacterScript()
    {
        currentHealth = maxHealth;
    }
}
