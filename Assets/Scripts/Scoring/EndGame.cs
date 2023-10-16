using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MathewHartley
{
    public class EndGame : MonoBehaviour
    {
        [Header("Highscore Objects")]
        public GameObject scoreTable;
        public HighScoreTable highscoreTable;

        [Header("Timer Objects")]
        public TextMeshProUGUI finalTimeText;
        public GameTimer gameTimer;
        private float playerTime;

        [Header("Player Input")]
        private string playerName;
        public GameObject inputWindow;
        public TMP_InputField playerInput;

        [Header("Managers")]
        public SceneLoader endGame;

        [Header("Audio")]
        public AudioSource victoryFanfare;

        private void OnTriggerEnter(Collider other)
        {
            //Round the timer to 2 decimal places
            playerTime = Mathf.Round(gameTimer.currentTime * 100f) /100f;

            inputWindow.SetActive(true);
            victoryFanfare.Play();
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
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

            StartCoroutine(ShowScores());
        }

        //public void SubmitScore()
        //{
        //    playerName = playerInput.text;
        //    highscoreTable.AddHighscoreEntry(playerTime, playerName);
        //    StartCoroutine(ShowScores());
        //}


        IEnumerator ShowScores()
        {
            ////inputWindow.SetActive(false);
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
            //scoreTable.SetActive(true);
            Debug.Log("Started Coroutine at timestamp : " + Time.time);
            yield return new WaitForSeconds(10);
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            endGame.LoadEnd();
        }
    }
}