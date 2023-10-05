using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MathewHartley
{
    public class HighScoreTable : MonoBehaviour
    {
        private Transform entryContainer;
        private Transform entryTemplate;
        float templateHeight = 35f;
        private void Awake()
        {
            entryContainer = transform.Find("HighscoreEntryContainer");
            entryTemplate = transform.Find("HighscoreEntryTemplate");

            entryTemplate.gameObject.SetActive(false);

            for (int i = 0; i < 10; i++)
            {
                Transform entryTransform = Instantiate(entryTemplate, entryContainer);
                RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
                entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                entryTransform.transform.SetParent(GameObject.Find("HighscoreTable").transform, false);
                entryTransform.gameObject.SetActive(true);

                //int playerRank = i + 1;
                //entryTransform.Find("PositionText").GetComponent<TextMeshPro>().text = playerRank.ToString();

                //int playerScore = Random.Range(0, 120);
                //entryTransform.Find("ScoreText").GetComponent<TextMeshPro>().text = playerScore.ToString();

                //string playerName = "AAA";
                //entryTransform.Find("NameText").GetComponent<TextMeshPro>().text = playerName;
            }
        }
    }
}