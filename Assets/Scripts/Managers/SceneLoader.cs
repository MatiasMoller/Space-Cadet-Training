using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MathewHartley
{
    /// <summary>
    /// This class holds functionality for scene transitions on level completion or death.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        public void LoadMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void LoadCredits()
        {
            SceneManager.LoadScene("CreditsMenu");
        }

        public void LoadControls()
        {
            SceneManager.LoadScene("ControlMenu");
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void LoadEnd()
        {
            SceneManager.LoadScene("GameOver");
        }
        //temporary game end without scoring system implemented
        private void OnTriggerEnter(Collider other)
        {
            LoadEnd();
        }
    }
}
