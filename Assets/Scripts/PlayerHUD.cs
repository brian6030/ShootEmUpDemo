using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace root
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] Image healthBar;
        [SerializeField] TextMeshProUGUI scoreText;

        void Update()
        {
            healthBar.fillAmount = GameManager.Instance.Player.GetHealthNormalized();
            scoreText.text = $"SCORE: {GameManager.Instance.GetScore()}";
        }
    }
}
