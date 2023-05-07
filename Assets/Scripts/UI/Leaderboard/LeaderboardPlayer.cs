using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardPlayer : MonoBehaviour
{
    public LeaderboardPlayer(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public string Name { get; private set; }
    public int Score { get; private set; }
}
