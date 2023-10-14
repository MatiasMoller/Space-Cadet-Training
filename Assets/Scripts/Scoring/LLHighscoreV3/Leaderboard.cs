using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

namespace MathewHartley
{
    public class Leaderboard : MonoBehaviour
    {
        string leaderboardKey = "globalHighscore";
        public TextMeshProUGUI playerNames;
        public TextMeshProUGUI playerScores;

        public IEnumerator SubmitScoreRoutine(int scoreToUpload)
        {
            bool done = false;
            string playerID = PlayerPrefs.GetString("PlayerID");
            LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardKey, (response) =>
            {
                if(response.success)
                {
                    Debug.Log("Successfully uploaded score");
                    done = true;
                }
                else
                {
                    Debug.Log("Failed" + response.errorData.message);
                    done = true;
                }
            });
            yield return new WaitWhile(() => done == false);
        }

        public IEnumerator FetchTopHighscoresRoutine()
        {
            bool done = false;
            LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) =>
            {
                if (response.success)
                {
                    string tempPlayerNames = "Names\n";
                    string tempPlayerScores = "Scores\n";

                    LootLockerLeaderboardMember[] members = response.items;

                    for (int i = 0; i < members.Length; i++)
                    {
                        tempPlayerNames += members[i].rank + ". ";
                        if (members[i].player.name != "")
                        {
                            tempPlayerNames += members[i].player.name;
                        }
                        else
                        {
                            tempPlayerNames += members[i].player.id;
                        }
                        tempPlayerScores += members[i].score + "\n";
                        tempPlayerNames += "\n";
                    }
                    done = true;
                    playerNames.text = tempPlayerNames;
                    playerScores.text = tempPlayerScores;
                }
                else
                {
                    Debug.Log("Failed" + response.errorData.message);
                    done = true;
                }
            });
            yield return new WaitWhile(() => done == false);
        }
    }
}
