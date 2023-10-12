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
        public HighscoreTableV2 highscoreTable;

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

        private void OnTriggerEnter(Collider other)
        {
            //Round the timer to 2 decimal places
            playerTime = Mathf.Round(gameTimer.currentTime * 100f) /100f;

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
        }

        public void SubmitScore()
        {
            playerName = playerInput.text;
            highscoreTable.AddHighscoreEntry(playerTime, playerName);
            Debug.Log("Score Submitted");
            inputWindow.SetActive(false);
            StartCoroutine(ShowScores());
        }

        IEnumerator ShowScores()
        {
            Debug.Log("Started Coroutine at timestamp : " + Time.time);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            scoreTable.SetActive(true);
            yield return new WaitForSeconds(10);
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            endGame.LoadEnd();
        }
    }
}