using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLosed : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text gold;

    [SerializeField]
    private Shoot shootScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Losed()
    {
        score.text = "Счёт: " + PlayerPrefs.GetInt("Score");
        gold.text = Convert.ToString(PlayerPrefs.GetInt("Score") / 10);
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + PlayerPrefs.GetInt("Score") / 10);
        PlayerPrefs.SetString("LevelPassed", "Yes");
        if (PlayerPrefs.GetInt("MaxLevel") > 11)
        {
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("MaxLevel") - 10);
        }
        else PlayerPrefs.SetInt("CurrentLevel", 1);
        PlayerPrefs.SetInt("AllBallsShooted", 0);
        PlayerPrefs.SetInt("DamageSkillTimer", 0);
        PlayerPrefs.SetInt("CountSkillTimer", 0);
        PlayerPrefs.SetInt("SizeSkillTimer", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
