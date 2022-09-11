using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSkin : MonoBehaviour
{
    [SerializeField]
    private GameObject BallCanvas;
    [SerializeField]
    private GameObject[] BallUpgrades;
    [SerializeField]
    private GameObject allUnlocked;

    [SerializeField]
    private Text currentStats1;
    [SerializeField]
    private Text currentStats2;
    [SerializeField]
    private Text goldCost;
    [SerializeField]
    private Text diamondCost;

    [SerializeField]
    private Text gold;
    [SerializeField]
    private Text diamonds;

    [SerializeField]
    private GameObject TutorialWindow;

    [SerializeField]
    private AudioSource clickSound;

    private int[] allBallsDamage;
    private int[] allBallsCount;
    private int[] goldPrice;
    private int[] diamondPrice;
    private int[] ballUpgradeLevels;

    public void CloseBallCanvas()
    {
        BallCanvas.SetActive(false);
        clickSound.Play();
    }

    public void OpenBallCanvas()
    {
        BallCanvas.SetActive(true);
        SetInitialValues();
        UpdateWindow();
        if (PlayerPrefs.GetString("BallTutorialPassed") != "Yes")
            TutorialWindow.SetActive(true);
        clickSound.Play();
        //DeleteUpgrades();
    }

    public void EndBallTutorial()
    {
        PlayerPrefs.SetString("BallTutorialPassed", "Yes");
        TutorialWindow.SetActive(false);
        clickSound.Play();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void DeleteUpgrades()
    {
        PlayerPrefs.SetInt("CurrentBallUpgrade", 0);
        PlayerPrefs.SetInt("BallDamage", 1);
        PlayerPrefs.SetInt("BallsCount", 30);
        PlayerPrefs.SetInt("Diamonds", 5000);
    }

    private void SetInitialValues()
    {
        allBallsDamage = new int[10];
        allBallsCount = new int[10];
        goldPrice = new int[10];
        diamondPrice = new int[10];
        ballUpgradeLevels = new int[10];

        allBallsDamage[0] = 2;
        allBallsDamage[1] = 2;
        allBallsDamage[2] = 3;
        allBallsDamage[3] = 3;
        allBallsDamage[4] = 5;
        allBallsDamage[5] = 5;
        allBallsDamage[6] = 7;
        allBallsDamage[7] = 7;
        allBallsDamage[8] = 9;
        allBallsDamage[9] = 9;

        allBallsCount[0] = 25;
        allBallsCount[1] = 35;
        allBallsCount[2] = 30;
        allBallsCount[3] = 40;
        allBallsCount[4] = 35;
        allBallsCount[5] = 45;
        allBallsCount[6] = 40;
        allBallsCount[7] = 50;
        allBallsCount[8] = 45;
        allBallsCount[9] = 55;

        goldPrice[0] = 200;
        goldPrice[1] = 450;
        goldPrice[2] = 850;
        goldPrice[3] = 1300;
        goldPrice[4] = 1900;
        goldPrice[5] = 2650;
        goldPrice[6] = 4000;
        goldPrice[7] = 5700;
        goldPrice[8] = 7550;
        goldPrice[9] = 10000;

        diamondPrice[0] = 20;
        diamondPrice[1] = 40;
        diamondPrice[2] = 80;
        diamondPrice[3] = 160;
        diamondPrice[4] = 320;
        diamondPrice[5] = 640;
        diamondPrice[6] = 1280;
        diamondPrice[7] = 2560;
        diamondPrice[8] = 5120;
        diamondPrice[9] = 10240;

        ballUpgradeLevels[0] = 5;
        ballUpgradeLevels[1] = 11;
        ballUpgradeLevels[2] = 18;
        ballUpgradeLevels[3] = 26;
        ballUpgradeLevels[4] = 35;
        ballUpgradeLevels[5] = 45;
        ballUpgradeLevels[6] = 56;
        ballUpgradeLevels[7] = 68;
        ballUpgradeLevels[8] = 81;
        ballUpgradeLevels[9] = 95;
    }

    public void ChangeBallGold()
    {
        clickSound.Play();
        if (PlayerPrefs.GetInt("BallDamage") == 1)
            PlayerPrefs.SetInt("CurrentBallUpgrade", 0);
        if (PlayerPrefs.GetInt("BallDamage") != 1)
            BallUpgrades[0].SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetInt("CurrentBallUpgrade") == i && Convert.ToInt32(goldCost.text) <= PlayerPrefs.GetInt("Gold"))
            {
                PlayerPrefs.SetInt("CurrentBallUpgrade", i + 1);
                PlayerPrefs.SetInt("BallDamage", allBallsDamage[i]);
                PlayerPrefs.SetInt("BallsCount", allBallsCount[i]);
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - Convert.ToInt32(goldCost.text));
                break;
            }
        }
        UpdateWindow();
    }

    public void ChangeBallDiamonds()
    {
        clickSound.Play();
        if (PlayerPrefs.GetInt("BallDamage") == 1)
            PlayerPrefs.SetInt("CurrentBallUpgrade", 0);
        if (PlayerPrefs.GetInt("BallDamage") != 1)
            BallUpgrades[0].SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetInt("CurrentBallUpgrade") == i && Convert.ToInt32(diamondCost.text) <= PlayerPrefs.GetInt("Diamonds"))
            {
                PlayerPrefs.SetInt("CurrentBallUpgrade", i + 1);
                PlayerPrefs.SetInt("BallDamage", allBallsDamage[i]);
                PlayerPrefs.SetInt("BallsCount", allBallsCount[i]);
                PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") - Convert.ToInt32(diamondCost.text));
                break;
            }
        }
        UpdateWindow();
    }

    public void BallUpgradeLevel()
    {
        SetInitialValues();
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetInt("MaxLevel") >= ballUpgradeLevels[i] && i == PlayerPrefs.GetInt("CurrentBallUpgrade"))
            {
                PlayerPrefs.SetInt("CurrentBallUpgrade", i + 1);
                PlayerPrefs.SetInt("BallDamage", allBallsDamage[i]);
                PlayerPrefs.SetInt("BallsCount", allBallsCount[i]);
                break;
            }
        }
    }

    public void UpdateWindow()
    {
        currentStats1.text = "Урон: " + PlayerPrefs.GetInt("BallDamage") + "  Шариков: " + PlayerPrefs.GetInt("BallsCount");
        currentStats2.text = "Урон: " + PlayerPrefs.GetInt("BallDamage") + "  Шариков: " + PlayerPrefs.GetInt("BallsCount");

        for (int i = 0; i < BallUpgrades.Length; i++)
        {
            BallUpgrades[i].SetActive(false);
            if (PlayerPrefs.GetInt("CurrentBallUpgrade") == 10)
            {
                BallUpgrades[9].SetActive(false);
                allUnlocked.SetActive(true);
                goldCost.text = Convert.ToString(0);
                diamondCost.text = Convert.ToString(0);
                break;
            }
            if (PlayerPrefs.GetInt("CurrentBallUpgrade") == i)
            {
                BallUpgrades[i].SetActive(true);
                Debug.Log(i);
                Debug.Log(goldCost.text);
                Debug.Log(goldPrice[i]);
                goldCost.text = Convert.ToString(goldPrice[i]);
                diamondCost.text = Convert.ToString(diamondPrice[i]);
                break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        gold.text = Convert.ToString(PlayerPrefs.GetInt("Gold"));
        diamonds.text = Convert.ToString(PlayerPrefs.GetInt("Diamonds"));
    }
}
