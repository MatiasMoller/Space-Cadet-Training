using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighscoreTableV2 : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    //private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = transform.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //AddHighscoreEntry(1000.0f, "DEV");

        //highscoreEntryList = new List<HighscoreEntry>()
        //{
        //    new HighscoreEntry{ playerScore = 1546.1f, playerName = "DVA"},
        //    new HighscoreEntry{ playerScore = 6854.2f, playerName = "DVB"},
        //    new HighscoreEntry{ playerScore = 1894.3f, playerName = "DVC"},
        //    new HighscoreEntry{ playerScore = 1894.4f, playerName = "DVD"},
        //    new HighscoreEntry{ playerScore = 9871.5f, playerName = "DVE"},
        //    new HighscoreEntry{ playerScore = 9183.6f, playerName = "DVF"},
        //    new HighscoreEntry{ playerScore = 3114.7f, playerName = "DVG"},
        //    new HighscoreEntry{ playerScore = 9185.8f, playerName = "DVH"},
        //    new HighscoreEntry{ playerScore = 9177.9f, playerName = "DVI"},
        //    new HighscoreEntry{ playerScore = 6157.0f, playerName = "DVJ"},
        //};

        string jsonString = PlayerPrefs.GetString("HighscoreTable");
        //string jsonString = File.ReadAllText(Application.dataPath + "/highscores.txt");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Bubble sort entry list by time, with lowest at the top
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].playerScore < highscores.highscoreEntryList[i].playerScore)
                {
                    //swap
                    HighscoreEntry tempSwap = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tempSwap;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        //Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        //string json = JsonUtility.ToJson(highscores);

        //PlayerPrefs.SetString("HighscoreTable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("HighscoreTable"));
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform entryContainer, List<Transform> transformList)
    {
        float templateHeight = 40f;

        //Only create the transform if the list contains fewer than 10 entries
        if (transformList.Count >= 10)
        {
            return;
        }

        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.transform.SetParent(GameObject.Find("HighscoreTable").transform, false);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        entryTransform.Find("PositionText").GetComponent<TextMeshProUGUI>().text = rank.ToString();

        float playerScore = highscoreEntry.playerScore;
        entryTransform.Find("TimeText").GetComponent<TextMeshProUGUI>().text = playerScore.ToString();

        string playerName = highscoreEntry.playerName;
        entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = playerName;

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(float playerScore, string playerName)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { playerScore = playerScore, playerName = playerName };

        string jsonString = PlayerPrefs.GetString("HighscoreTable");
        //string jsonString = File.ReadAllText(Application.dataPath + "/highscores.txt");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("HighscoreTable", json);
        PlayerPrefs.Save();
    }

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
        public float playerScore;
        public string playerName;
    }
}