using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MathewHartley
{
    public class EndGame : MonoBehaviour
    {
        public GameObject scoreTable;
        public GameObject inputWindow;
        public TextMeshProUGUI finalTimeText;
        public SceneLoader endGame;
        public GameTimer gameTimer;
        private void OnTriggerEnter(Collider other)
        {
            inputWindow.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (gameTimer.hasFormat)
            {
                finalTimeText.text = gameTimer.currentTime.ToString(gameTimer.timeFormats[gameTimer.format]);
                Debug.Log("Run Time: " + gameTimer.currentTime.ToString(gameTimer.timeFormats[gameTimer.format]));
            }
            else
            {
                finalTimeText.text = gameTimer.currentTime.ToString();
                Debug.Log("Run Time: " + gameTimer.ToString());
            }
        }

        IEnumerator ShowScores()
        {
            scoreTable.SetActive(true);
            Debug.Log("Started Coroutine at timestamp : " + Time.time);
            yield return new WaitForSeconds(10);
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            endGame.LoadEnd();
        }
    }
}