using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    [SerializeField]
    private GameObject SkillsCanvas;

    [SerializeField]
    private Text DamageSkillText;
    [SerializeField]
    private Text CountSkillText;
    [SerializeField]
    private Text SizeSkillText;

    [SerializeField]
    private GameObject GameCanvas;

    [SerializeField]
    private GameObject DamageSkillBackground;
    [SerializeField]
    private GameObject CountSkillBackground;
    [SerializeField]
    private GameObject SizeSkillBackground;

    [SerializeField]
    private Text goldText;

    [SerializeField]
    private GameObject TutorialWindow;

    [SerializeField]
    private AudioSource clickSound;

    [SerializeField]
    private Text[] SkillStatusText = new Text[12];
    private int[] SkillCost = new int[12];
    //[SerializeField]
    //private GameObject[] SkillShopButton = new GameObject[12];

    public void CloseSkillCanvas()
    {
        SkillsCanvas.SetActive(false);
        clickSound.Play();
    }

    public void OpenSkillCanvas()
    {
        SkillsCanvas.SetActive(true);
        UpdSkillValues();
        InitialValues();
        SetButtonStatus(-1);
        clickSound.Play();

        if (PlayerPrefs.GetString("SkillsTutorialPassed") != "Yes")
            TutorialWindow.SetActive(true);
    }

    public void EndSkillsToturial()
    {
        PlayerPrefs.SetString("SkillsTutorialPassed", "Yes");
        TutorialWindow.SetActive(false);
        clickSound.Play();
    }

    private void InitialValues()
    {
        for (int i = 0; i < SkillStatusText.Length; i++)
        {
            if (i < 3)
                SkillCost[i] = 300;
            else if (i < 6)
                SkillCost[i] = 700;
            else if (i < 9)
                SkillCost[i] = 1500;
            else SkillCost[i] = 3000;

            SkillStatusText[i].text = Convert.ToString(SkillCost[i]);
        }

        ////обнуление купленных умений
        //for (int i = 1; i < 5; i++)
        //{
        //    PlayerPrefs.SetInt($"Damage{i}", 0);
        //    PlayerPrefs.SetInt($"Count{i}", 0);
        //    PlayerPrefs.SetInt($"Size{i}", 0);

        //    PlayerPrefs.SetInt("DamageSkillValue", 1);
        //    PlayerPrefs.SetFloat("CountSkillValue", 1);
        //    PlayerPrefs.SetFloat("SizeSkillValue", 1);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    public void DamageSkillActive()
    {
        if (PlayerPrefs.GetString("DamageSkillActive") == "Yes")
            PlayerPrefs.SetString("DamageSkillActive", "No");
        else PlayerPrefs.SetString("DamageSkillActive", "Yes");

        clickSound.Play();
        ChangeSkillBackGroundColor();
    }

    public void CountSkillActive()
    {
        if (PlayerPrefs.GetString("CountSkillActive") == "Yes")
            PlayerPrefs.SetString("CountSkillActive", "No");
        else PlayerPrefs.SetString("CountSkillActive", "Yes");

        clickSound.Play();
        ChangeSkillBackGroundColor();
    }
    public void SizeSkillActive()
    {
        if (PlayerPrefs.GetString("SizeSkillActive") == "Yes")
            PlayerPrefs.SetString("SizeSkillActive", "No");
        else PlayerPrefs.SetString("SizeSkillActive", "Yes");

        clickSound.Play();
        ChangeSkillBackGroundColor();
    }


    public void Damage1()
    {
        if (PlayerPrefs.GetInt("Damage1") == 1)
        {
            PlayerPrefs.SetInt("DamageSkillValue", 2);
            SetButtonStatus(0);
            UpdSkillValues();
            return;
        }
        clickSound.Play();

        if (PlayerPrefs.GetInt("Damage1") != 1 && PlayerPrefs.GetInt("Damage1") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[0])
        {
            PlayerPrefs.SetInt("Damage1", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[0]);
            Damage1();
        }
    }
    public void Damage2()
    {
        if (PlayerPrefs.GetInt("Damage2") == 1)
        {
            PlayerPrefs.SetInt("DamageSkillValue", 3);
            SetButtonStatus(3);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Damage2") != 1 && PlayerPrefs.GetInt("Damage2") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[3])
        {
            PlayerPrefs.SetInt("Damage2", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[3]);
            Damage2();
        }

    }
    public void Damage3()
    {
        if (PlayerPrefs.GetInt("Damage3") == 1)
        {
            PlayerPrefs.SetInt("DamageSkillValue", 4);
            SetButtonStatus(6);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Damage3") != 1 && PlayerPrefs.GetInt("Damage3") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[6])
        {
            PlayerPrefs.SetInt("Damage3", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[6]);
            Damage3();
        }

    }
    public void Damage4()
    {
        if (PlayerPrefs.GetInt("Damage4") == 1)
        {
            PlayerPrefs.SetInt("DamageSkillValue", 5);
            SetButtonStatus(9);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Damage4") != 1 && PlayerPrefs.GetInt("Damage4") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[9])
        {
            PlayerPrefs.SetInt("Damage4", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[9]);
            Damage4();
        }

    }


    public void Count1()
    {
        if (PlayerPrefs.GetInt("Count1") == 1)
        {
            PlayerPrefs.SetFloat("CountSkillValue", 1.5f);
            SetButtonStatus(1);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Count1") != 1 && PlayerPrefs.GetInt("Count1") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[1])
        {
            PlayerPrefs.SetInt("Count1", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[1]);
            Count1();
        }

    }
    public void Count2()
    {
        if (PlayerPrefs.GetInt("Count2") == 1)
        {
            PlayerPrefs.SetFloat("CountSkillValue", 2);
            SetButtonStatus(4);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Count2") != 1 && PlayerPrefs.GetInt("Count2") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[4])
        {
            PlayerPrefs.SetInt("Count2", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[4]);
            Count2();
        }

    }
    public void Count3()
    {
        if (PlayerPrefs.GetInt("Count3") == 1)
        {
            PlayerPrefs.SetFloat("CountSkillValue", 2.5f);
            SetButtonStatus(7);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Count3") != 1 && PlayerPrefs.GetInt("Count3") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[7])
        {
            PlayerPrefs.SetInt("Count3", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[7]);
            Count3();
        }
    }
    public void Count4()
    {
        if (PlayerPrefs.GetInt("Count4") == 1)
        {
            PlayerPrefs.SetFloat("CountSkillValue", 3);
            SetButtonStatus(10);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Count4") != 1 && PlayerPrefs.GetInt("Count4") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[10])
        {
            PlayerPrefs.SetInt("Count4", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[10]);
            Count4();
        }
    }


    public void Size1()
    {
        if (PlayerPrefs.GetInt("Size1") == 1)
        {
            PlayerPrefs.SetFloat("SizeSkillValue", 1.1f);
            PlayerPrefs.SetInt("Size1", -1);
            SetButtonStatus(2);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Size1") != 1 && PlayerPrefs.GetInt("Size1") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[2])
        {
            PlayerPrefs.SetInt("Size1", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[2]);
            Size1();
        }
    }
    public void Size2()
    {
        if (PlayerPrefs.GetInt("Size2") == 1)
        {
            PlayerPrefs.SetFloat("SizeSkillValue", 1.2f);
            PlayerPrefs.SetInt("Size2", -1);
            SetButtonStatus(5);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Size2") != 1 && PlayerPrefs.GetInt("Size2") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[5])
        {
            PlayerPrefs.SetInt("Size2", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[5]);
            Size2();
        }
    }
    public void Size3()
    {
        if (PlayerPrefs.GetInt("Size3") == 1)
        {
            PlayerPrefs.SetFloat("SizeSkillValue", 1.35f);
            PlayerPrefs.SetInt("Size3", -1);
            SetButtonStatus(8);
            UpdSkillValues();
            return;
        }
        clickSound.Play();

        if (PlayerPrefs.GetInt("Size3") != 1 && PlayerPrefs.GetInt("Size3") != -1 && PlayerPrefs.GetInt("Gold") >= SkillCost[8])
        {
            PlayerPrefs.SetInt("Size3", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[8]);
            Size3();
        }

    }
    public void Size4()
    {
        if (PlayerPrefs.GetInt("Size4") == 1)
        {
            PlayerPrefs.SetFloat("SizeSkillValue", 1.5f);
            PlayerPrefs.SetInt("Size4", -1);
            SetButtonStatus(11);
            UpdSkillValues();
            return;
        }
        clickSound.Play();
        if (PlayerPrefs.GetInt("Size4") != 1 && PlayerPrefs.GetInt("Size4") != -1 && PlayerPrefs.GetInt("Gold") > SkillCost[11])
        {
            PlayerPrefs.SetInt("Size4", 1);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - SkillCost[11]);
            Size4();
        }
    }

    public void ChangeSkillBackGroundColor()
    {
        if (PlayerPrefs.GetString("DamageSkillActive") == "Yes")
            DamageSkillBackground.GetComponent<Image>().color = Color.green;
        else DamageSkillBackground.GetComponent<Image>().color = Color.white;

        if (PlayerPrefs.GetString("CountSkillActive") == "Yes")
            CountSkillBackground.GetComponent<Image>().color = Color.green;
        else CountSkillBackground.GetComponent<Image>().color = Color.white;

        if (PlayerPrefs.GetString("SizeSkillActive") == "Yes")
            SizeSkillBackground.GetComponent<Image>().color = Color.green;
        else SizeSkillBackground.GetComponent<Image>().color = Color.white;
    }

    private void SetButtonStatus(int currentChange)
    {
        clickSound.Play();
        //for (int i = 1; i < 5; i++)
        //{
        //    Debug.Log($"Damage{i} = " + PlayerPrefs.GetInt($"Damage{i}"));
        //    Debug.Log($"Count{i} = " + PlayerPrefs.GetInt($"Count{i}"));
        //    Debug.Log($"Size{i} = " + PlayerPrefs.GetInt($"Size{i}"));
        //}

        //обновление значений при запуске окна
        if (currentChange == -1)
        {
            //size
            for (int i = 1; i < 5; i++)
            {
                if (PlayerPrefs.GetInt($"Size{i}") == 1)
                {
                    SkillStatusText[i * 3 - 1].text = "Установить";
                }
                else if (PlayerPrefs.GetInt($"Size{i}") == -1)
                {
                    SkillStatusText[i * 3 - 1].text = "Установлен";
                }
                else SkillStatusText[i * 3 - 1].text = Convert.ToString(SkillCost[i * 3 - 1]);
            }
            //count
            for (int i = 1; i < 5; i++)
            {
                if (PlayerPrefs.GetInt($"Count{i}") == 1)
                {
                    SkillStatusText[i * 3 - 2].text = "Установить";
                }
                else if (PlayerPrefs.GetInt($"Count{i}") == -1)
                {
                    SkillStatusText[i * 3 - 2].text = "Установлен";
                }
                else SkillStatusText[i * 3 - 2].text = Convert.ToString(SkillCost[i * 3 - 2]);
            }
            //damage
            for (int i = 1; i < 5; i++)
            {
                if (PlayerPrefs.GetInt($"Damage{i}") == 1)
                {
                    SkillStatusText[i * 3 - 3].text = "Установить";
                }
                else if (PlayerPrefs.GetInt($"Damage{i}") == -1)
                {
                    SkillStatusText[i * 3 - 3].text = "Установлен";
                }
                else SkillStatusText[i * 3 - 3].text = Convert.ToString(SkillCost[i * 3 - 3]);
            }
            return;
        }

        //size
        if (currentChange % 3 == 2)
        {
            //устанавливаем все size на их цену
            for (int i = 1; i < 5; i++)
            {
                SkillStatusText[i * 3 - 1].text = Convert.ToString(SkillCost[i * 3 - 1]);
            }

            //если size 1 или -1 (куплен или установлен) ставим 1 (куплен)
            for (int i = 1; i < 5; i++)
            {
                if (PlayerPrefs.GetInt($"Size{i}") == 1 || PlayerPrefs.GetInt($"Size{i}") == -1)
                {
                    PlayerPrefs.SetInt($"Size{i}", 1);
                    SkillStatusText[i * 3 - 1].text = "Установить";
                }
            }

            //выбранный size становится Установлено
            PlayerPrefs.SetInt($"Size{(currentChange + 1) / 3}", -1);
            SkillStatusText[currentChange].text = "Установлено";

            return;
        }

        //count
        if (currentChange % 3 == 1)
        {
            //устанавливаем все count на их цену
            for (int i = 1; i < 5; i++)
            {
                SkillStatusText[i * 3 - 2].text = Convert.ToString(SkillCost[i * 3 - 2]);
            }

            //если count 1 или -1 (куплен или установлен) ставим 1 (куплен)
            for (int i = 1; i < 5; i++)
            {
                if (PlayerPrefs.GetInt($"Count{i}") == 1 || PlayerPrefs.GetInt($"Count{i}") == -1)
                {
                    PlayerPrefs.SetInt($"Count{i}", 1);
                    SkillStatusText[i * 3 - 2].text = "Установить";
                }
            }

            //выбранный count становится Установлено
            PlayerPrefs.SetInt($"Count{(currentChange + 2) / 3}", -1);
            SkillStatusText[currentChange].text = "Установлено";

            return;
        }

        //damage
        if (currentChange % 3 == 0)
        {
            //устанавливаем все damage на их цену
            for (int i = 1; i < 5; i++)
            {
                SkillStatusText[i * 3 - 3].text = Convert.ToString(SkillCost[i * 3 - 3]);
            }

            //если damage 1 или -1 (куплен или установлен) ставим 1 (куплен)
            for (int i = 1; i < 5; i++)
            {
                if (PlayerPrefs.GetInt($"Damage{i}") == 1 || PlayerPrefs.GetInt($"Damage{i}") == -1)
                {
                    PlayerPrefs.SetInt($"Damage{i}", 1);
                    SkillStatusText[i * 3 - 3].text = "Установить";
                }
            }

            //выбранный damage становится Установлено
            PlayerPrefs.SetInt($"Damage{(currentChange + 3) / 3}", -1);
            SkillStatusText[currentChange].text = "Установлено";

            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = Convert.ToString(PlayerPrefs.GetInt("Gold"));
    }

    private void UpdSkillValues()
    {
        DamageSkillText.text = "x" + PlayerPrefs.GetInt("DamageSkillValue");
        CountSkillText.text = "x" + PlayerPrefs.GetFloat("CountSkillValue");
        SizeSkillText.text = "x" + PlayerPrefs.GetFloat("SizeSkillValue");
    }
}
