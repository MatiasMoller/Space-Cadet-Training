using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathewHartley
{
    public class EndGame : MonoBehaviour
    {
        public GameObject scoreTable;
        public SceneLoader endGame;
        private void OnTriggerEnter(Collider other)
        {
            scoreTable.SetActive(true);
            StartCoroutine(ReadScore());
        }

        IEnumerator ReadScore()
        {
            Debug.Log("Started Coroutine at timestamp : " + Time.time);
            yield return new WaitForSeconds(10);
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            endGame.LoadEnd();
        }
    }
}