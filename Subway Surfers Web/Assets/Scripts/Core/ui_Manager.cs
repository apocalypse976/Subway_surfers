using TMPro;
using UnityEngine;

public class ui_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _winingsText;
    [SerializeField] private GameObject _gameOverPanel;

    private static ui_Manager instance;
    public static ui_Manager Instance
    {
        get
        {
            return instance;
        }
    }
    void Start()
    {
        instance = this;
        _gameOverPanel.SetActive(false);
    }

    public void Update_coin(float coin)
    {
        _coinText.text = coin.ToString();
    }
    public void Game_over(float winnings)
    {
        _gameOverPanel.SetActive(true);
        _winingsText.text = winnings.ToString() +" Ruppes";
    }
}
