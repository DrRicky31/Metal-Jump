using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LootLocker.Requests;

public class PlayerController : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(LoginRoutine());
    }


    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if(response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start the session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
