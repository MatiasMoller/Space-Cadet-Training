using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;

namespace MathewHartley
{
    public class EndGame : MonoBehaviour
    {
        [Header("Highscore Objects")]
        public GameObject scoreTable;

        [Header("Timer Objects")]
        public TextMeshProUGUI finalTimeText;
        public GameTimer gameTimer;
        private float playerTime;
        private int scoreToSubmit;

        [Header("Player Input")]
        public GameObject inputWindow;
        public TMP_InputField playerInput;

        [Header("Managers")]
        public SceneLoader endGame;
        public Leaderboard leaderboard;

        private void OnTriggerEnter(Collider other)
        {
            //Round the timer to 2 decimal places
            playerTime = Mathf.Round(gameTimer.currentTime * 100f) /100f;
            scoreToSubmit = (int)playerTime;

            inputWindow.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (gameTimer.hasFormat)
            {
                finalTimeText.text = playerTime.ToString(gameTimer.timeFormats[gameTimer.format]);
                Debug.Log("Run Time: " + playerTime.ToString(gameTimer.timeFormats[gameTimer.format]));
            }
            else
            {
                finalTimeText.text = playerTime.ToString();
                Debug.Log("Run Time: " + playerTime.ToString());
            }
            GameObject playerCharacter = GameObject.Find("Player");
            playerCharacter.GetComponent<InputManager>().enabled = false;
            GameObject playerGun = GameObject.Find("SciFiGunLightBlue");
            playerGun.GetComponent<GunSystem>().enabled = false;
        }

        public void SubmitScore()
        {
            leaderboard.SubmitScoreRoutine(scoreToSubmit);
            Debug.Log("Score Submitted");
            inputWindow.SetActive(false);
            StartCoroutine(ShowScores());
        }

        IEnumerator ShowScores()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            leaderboard.FetchTopHighscoresRoutine();
            scoreTable.SetActive(true);
            yield return new WaitForSeconds(10);
            endGame.LoadEnd();
        }
    }
}