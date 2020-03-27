using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// This class generates and assigns names to the 2 dance teams in our dance off battle.
/// It also controls the number of dancers on each team via the inspector
/// It also uses the name generator to pass character names to the teams so they can initialise
/// 
/// TODO:
///     Generate unique team names for both teams and assign them via team_.SetTroupeName(str);
///     Use the nameGenerator to get enough names for the number of dancers on both teams and pass the required names via array to each team for init (InitaliseTeamFromNames)
/// </summary>
public class DanceTeamInit : MonoBehaviour
{
    public DanceTeam teamA, teamB;

    public GameObject dancerPrefab;
    public int dancersPerSide = 3;
    public CharacterNameGenerator nameGenerator;

    // Function of initialising teams(InitTeams) was subscirbed to GameEvent "OnBattleInitialise" using +=
    private void OnEnable()
    {
        GameEvents.OnBattleInitialise += InitTeams;
    }
    // 'InitTeams' function unsubscribes from GameEvent "OnBattleInitialise" on disable, using -=
    private void OnDisable()
    {
        GameEvents.OnBattleInitialise -= InitTeams;
    }

    void InitTeams()
    {
        //Here, we accessed the function that allows us to name each of teams. The function takes an input of string, so that is what was given.
        teamA.SetTroupeName("Monkies");
        teamB.SetTroupeName("Donkies");
        
        //Here we decided which side of the screen each team is on. we have done this by inputing the floats options of 1 and -1 (brought to our knowlwdge by lecturer) in the function that we have accessed from the team names.
        teamA.InitaliseTeamFromNames(dancerPrefab, -1, nameGenerator.GenerateNames(dancersPerSide));
        teamB.InitaliseTeamFromNames(dancerPrefab, 1, nameGenerator.GenerateNames(dancersPerSide));

            //This(below) can be deleted (but I am choosing to keep it xD).
        Debug.LogWarning("InitTeams called, needs to generate names for the teams and set them with teamA.SetTroupeName");

        Debug.LogWarning("InitTeams called, needs to create character names via CharacterNameGenerator and get them into the team.InitaliseTeamFromNames");
    }
}
