using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardButton : MonoBehaviour
{
    private bool isShowing;
    public GameObject leaderboard;
    public LeaderboardController lbController;

    public void showLeaderboard()
    {
        if(isShowing)
        {
            leaderboard.SetActive(false);
            isShowing = false;
        }
        else
        {
            leaderboard.SetActive(true);
            lbController.ShowScores();
            isShowing = true;

        }
    }
}
