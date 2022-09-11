using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuCanvas;
    [SerializeField]
    private GameObject GameCanvas;
    [SerializeField]
    private CreateLevel currentLevel;
    [SerializeField]
    private Text goldCount;
    [SerializeField]
    private Text diamondsCount;
    [SerializeField]
    private Shoot shootScript;

    [SerializeField]
    private Text DamageSkillTextGame;
    [SerializeField]
    private Text CountSkillTextGame;
    [SerializeField]
    private Text SizeSkillTextGame;

    [SerializeField]
    private Text DamageSkillUsedText;
    [SerializeField]
    private Text CountSkillUsedText;
    [SerializeField]
    private Text SizeSkillUsedText;

    [SerializeField]
    private GameObject soundOffImage;
    [SerializeField]
    private GameObject soundOnImage;

    [SerializeField]
    private Skills skills;
    [SerializeField]
    private Text currentLevelText;
    [SerializeField]
    private CreateLevel createLevel;
    [SerializeField]
    private GameObject exitButton;
    [SerializeField]
    private BallSkin ballUpgrade;
    [SerializeField]
    private GameObject TutorialWindow;

    [SerializeField]
    private AudioSource KickSound;
    [SerializeField]
    private AudioSource ClickSound;
    [SerializeField]
    private AudioSource PlaySound;
    [SerializeField]
    private AudioSource Music;


    private void Start()
    {
        if (PlayerPrefs.GetInt("CurrentLevel") == 0)
            FirstOpen();
        Music.Play();
        CheckSound();
    }

    public void Mute()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
            PlayerPrefs.SetInt("Sound", 1);
        else
            PlayerPrefs.SetInt("Sound", 0);

        CheckSound();
    }

    public void Money()
    {
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 10000);
        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 10000);
    }

    public void StartEndless()
    {
        PlaySound.Play();
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        UpdSkillValuesGame();

        currentLevel.CreateLvl();
        //shootScript.Ball.SetActive(true);
        shootScript.ShootButtonPressed.SetActive(false);
        shootScript.damageLock.SetActive(false);
        shootScript.countLock.SetActive(false);
        shootScript.sizeLock.SetActive(false);
        PlayerPrefs.SetString("LevelPassed", "No");
        PlayerPrefs.SetString("IsInGame", "Yes");
        PlayerPrefs.SetInt("AllBallsShooted", 0);
        PlayerPrefs.SetString("DamageSkillActive", "No");
        PlayerPrefs.SetString("CountSkillActive", "No");
        PlayerPrefs.SetString("SizeSkillActive", "No");
        skills.ChangeSkillBackGroundColor();
        //shootScript.UnlockSkills();
        SkillTimerRegulator();
        currentLevelText.text = Convert.ToString(PlayerPrefs.GetInt("CurrentLevel")) + " уровень";
        exitButton.SetActive(true);

        if (PlayerPrefs.GetString("GameTutorialPassed") != "Yes")
            TutorialWindow.SetActive(true);

        ballUpgrade.BallUpgradeLevel();
    }

    private void FirstOpen()
    {
        PlayerPrefs.SetInt("CurrentLevel", 1);
        PlayerPrefs.SetInt("MaxLevel", 1);
        PlayerPrefs.SetInt("BallsCount", 30);
        PlayerPrefs.SetInt("BallDamage", 1);
        PlayerPrefs.SetFloat("SizeSkillValue", 1);
        PlayerPrefs.SetFloat("CountSkillValue", 1);
        PlayerPrefs.SetInt("DamageSkillValue", 1);
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void EndGameToturial()
    {
        TutorialWindow.SetActive(false);
        PlayerPrefs.SetString("GameTutorialPassed", "Yes");
        ClickSound.Play();
    }

    public void Nextlevel()
    {
        StartEndless();
        createLevel.lvlWinCanvas.SetActive(false);
    }

    private void SkillTimerRegulator()
    {
        if (PlayerPrefs.GetInt("DamageSkillTimer") > 1)
        {
            PlayerPrefs.SetInt("DamageSkillTimer", PlayerPrefs.GetInt("DamageSkillTimer") - 1);
            DamageSkillUsedText.text = Convert.ToString(PlayerPrefs.GetInt("DamageSkillTimer") - 1);
        }
        else
        {
            shootScript.DamageSkillUsed.SetActive(false);
            PlayerPrefs.SetInt("DamageSkillTimer", 0);
        }

        if (PlayerPrefs.GetInt("CountSkillTimer") > 1)
        {
            PlayerPrefs.SetInt("CountSkillTimer", PlayerPrefs.GetInt("CountSkillTimer") - 1);
            CountSkillUsedText.text = Convert.ToString(PlayerPrefs.GetInt("CountSkillTimer") - 1);
        }
        else
        {
            shootScript.CountSkillUsed.SetActive(false);
            PlayerPrefs.SetInt("CountSkillTimer", 0);
        }

        if (PlayerPrefs.GetInt("SizeSkillTimer") > 1)
        {
            PlayerPrefs.SetInt("SizeSkillTimer", PlayerPrefs.GetInt("SizeSkillTimer") - 1);
            SizeSkillUsedText.text = Convert.ToString(PlayerPrefs.GetInt("SizeSkillTimer") - 1);
        }
        else
        {
            shootScript.SizeSkillUsed.SetActive(false);
            PlayerPrefs.SetInt("SizeSkillTimer", 0);
        }
    }

    public void ExitToMenu()
    {
        GameCanvas.SetActive(false);
        MenuCanvas.SetActive(true);

        ClickSound.Play();
    }

    private void UpdSkillValuesGame()
    {
        DamageSkillTextGame.text = "x" + PlayerPrefs.GetInt("DamageSkillValue");
        CountSkillTextGame.text = "x" + PlayerPrefs.GetFloat("CountSkillValue");
        SizeSkillTextGame.text = "x" + PlayerPrefs.GetFloat("SizeSkillValue");
    }

    private void Update()
    {
        goldCount.text = Convert.ToString(PlayerPrefs.GetInt("Gold"));
        diamondsCount.text = Convert.ToString(PlayerPrefs.GetInt("Diamonds"));
    }

    private void CheckSound()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            soundOffImage.SetActive(true);
            soundOnImage.SetActive(false);
            PlaySound.volume = 0;
            Music.volume = 0;
            KickSound.volume = 0;
            ClickSound.volume = 0;
        }
        else
        {
            soundOffImage.SetActive(false);
            soundOnImage.SetActive(true);
            PlaySound.volume = 1;
            Music.volume = 0.15f;
            KickSound.volume = 0.15f;
            ClickSound.volume = 0.5f;
        }
    }
}
