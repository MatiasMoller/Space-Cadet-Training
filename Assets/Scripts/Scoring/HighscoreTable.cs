using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MathewHartley
{
       /// <summary>
       /// This class instantiates the highscore table with 10 entries
       /// Currently using dummy data
       /// </summary>
    public class HighScoreTable : MonoBehaviour
    {
        private Transform entryContainer;
        private Transform entryTemplate;
        private List<Transform> highscoreEntryTransformList;

        private void Awake()
        {
            entryContainer = transform.Find("HighscoreEntryContainer");
            entryTemplate = transform.Find("HighscoreEntryTemplate");

            entryTemplate.gameObject.SetActive(false);

            //AddHighscoreEntry(10.1f, "MAT");

            string jsonString = PlayerPrefs.GetString("highscoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            //Sorting entries by time
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].playerTime < highscores.highscoreEntryList[i].playerTime)
                    {
                        //Swap entries
                        HighscoreEntry temp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = temp;
                    }
                }
            }

            highscoreEntryTransformList = new List<Transform>();
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
            {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        }

        /// <summary>
        /// Creates a single entry and adds it to the highscore entry list
        /// </summary>
        private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
        {
            float templateHeight = 35f;

            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.transform.SetParent(GameObject.Find("HighscoreTable").transform, false);
            entryTransform.gameObject.SetActive(true);

            int playerRank = transformList.Count + 1;
            entryTransform.Find("PositionText").GetComponent<TextMeshProUGUI>().text = playerRank.ToString();

            float playerScore = highscoreEntry.playerTime;
            entryTransform.Find("TimeText").GetComponent<TextMeshProUGUI>().text = playerScore.ToString();

            string playerName = highscoreEntry.playerName;
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = playerName;

            transformList.Add(entryTransform);
        }
        
        /// <summary>
        /// Adds a highscore entry to the list by loading the existing list, adding to it, then saving the list
        /// </summary>
        public void AddHighscoreEntry(float playerTime, string playerName)
        {
            //Create highscore entry
            HighscoreEntry highscoreEntry = new HighscoreEntry { playerTime = playerTime, playerName = playerName };

            //Load existing highscore list
            string jsonString = PlayerPrefs.GetString("highscoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            //Add new entry
            highscores.highscoreEntryList.Add(highscoreEntry);

            //Save highscore list
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// This class is for use with the json utility to save and load the highscore list
        /// </summary>
        private class Highscores
        {
            public List<HighscoreEntry> highscoreEntryList;
        }


        /// <summary>
        /// This class represents a single highscore entry
        /// </summary>
        [System.Serializable]
        private class HighscoreEntry
        {
            public float playerTime;
            public string playerName;
        }
    }
}