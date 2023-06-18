using Eflatun.SceneReference;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] GameObject gameOverUI;

        public static GameManager Instance { get; private set; }
        public Player Player => player;

        Player player;
        int score;

        [SerializeField] float restartTimer = 3f;

        public bool IsGameOver()
        {
            return player.GetHealthNormalized() <= 0;
        }

        private void Awake()
        {
            Instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        public void AddScore(int amount) 
        {
            score += amount;
        }
        public int GetScore()
        {
            return score;
        }

        void Update()
        {
            if (IsGameOver())
            {
                restartTimer -= Time.deltaTime;

                if (gameOverUI.activeSelf == false)
                {
                    gameOverUI.SetActive(true);
                    Time.timeScale = 0;
                }

                if (restartTimer <= 0)
                {
                    Loader.Load(mainMenuScene);
                }
            }
        }
    }
}
