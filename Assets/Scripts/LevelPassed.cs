using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassed : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text gold;
    [SerializeField]
    private Text diamonds;
    
    [SerializeField]
    private Shoot shootScript;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Passed()
    {
        Debug.Log("Passed");
        score.text = "Счёт: " + PlayerPrefs.GetInt("Score");
        gold.text = Convert.ToString(PlayerPrefs.GetInt("Score") / 5);
        diamonds.text = Convert.ToString(PlayerPrefs.GetInt("CurrentLevel"));
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + PlayerPrefs.GetInt("Score") / 5);
        PlayerPrefs.SetString("LevelPassed", "Yes");
        if (PlayerPrefs.GetInt("CurrentLevel") > PlayerPrefs.GetInt("MaxLevel"))
            PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("CurrentLevel"));
        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + PlayerPrefs.GetInt("CurrentLevel"));
        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
        PlayerPrefs.SetInt("AllBallsShooted", 0);
    }


    // Update is called once per frame
    void Update()
    {
    }
}
