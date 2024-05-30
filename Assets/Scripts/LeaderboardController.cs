using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    public InputField MemberID;
    public int ID;
    int MaxScore = 6;
    public Text[] entries;

    // Start is called before the first frame update
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("success");
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, (int)(Punti.punti), ID, (response) =>
        {
            if(response.success)
            {
                Debug.Log("success");
            }
            else
            {
                Debug.Log("failed");
            }               
        });
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScore, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for(int i=0; i<scores.Length; i++)
                {
                    entries[i].text = (scores[i].rank + ". " + scores[i].member_id + ": " + scores[i].score);
                }

                if(scores.Length<MaxScore)
                {
                    for(int i=scores.Length; i<MaxScore; i++)
                    {
                        entries[i].text = (i + 1).ToString() + ".    0";
                    }
                }
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }
}
