﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a single character, their stats, name and current mojo (or hp) in the dance battle.
/// 
/// TODO:
///     Initialise stats for the character that will be used to determine their victory in dance offs.
///     You may wish or need to add additional stats here for use in the fight (FightManager)
///     May need to handle the loss of mojo when loosing a fight
/// </summary>
public class Character : MonoBehaviour
{
    public CharacterName charName;

    [Range(0.0f,1.0f)]
    public float mojoRemaining = 1;

    [Header("Stats")]
    public int availablePoints = 10;

    public int level;
    public int xp;
    public int style, luck, rhythm;


    [Header("Related objects")]
    public DanceTeam myTeam;

    public bool isSelected;

    [SerializeField]
    protected TMPro.TextMeshPro nickText;

    //Here (below) we have set level and xp of players, and programmed a way to distribute attribute points (10 availablePoints) to the stats style, luck, and rhythm. 
    //We have done this using the Random class- accessing Range, and then specifying the minimun and maximum integers to select from. 
    //Before moving to the next stat, the number assigned to the previous stat is subtracted from 'availablePoints', this allows the point limit of 10 points to work in limiting the player's abilities.
    //Notice that style and luck have been furthur limited by subtracting 2, and 1 point(s) respectively, this is so that all 3 stats are ensured to be assigned at least 1 point.
    void Awake()
    {
        InitialStats();
        level = 1;

        xp = 0;

        style = Random.Range(1, availablePoints-2);
        availablePoints -= style;

        luck = Random.Range(1, availablePoints-1);
        availablePoints -= luck;

        rhythm = availablePoints;
    }

    public void InitialStats()
    {
        // TODO - First, you can
        Debug.LogWarning("InitialStats called, needs to distribute points into stats. This should be able to be ported from previous brief work");
    }

    public void AssignName(CharacterName characterName)
    {
        charName = characterName;
        if(nickText != null)
        {
            nickText.text = charName.nickname;
            nickText.transform.LookAt(Camera.main.transform.position);
            //text faces the wrong way so
            nickText.transform.Rotate(0, 180, 0);
        }
    }
}
