using Eflatun.SceneReference;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public class GameOverLoader : MonoBehaviour
    {
        [SerializeField] SceneReference startingLevel;
        [SerializeField] SceneReference mainMenu;

        public void LoadRestart() 
        {
            Time.timeScale = 1;
            Loader.Load(startingLevel);
        }

        public void LoadMainMenu() 
        {
            Time.timeScale = 1;
            Loader.Load(mainMenu);
        }
    }
}
