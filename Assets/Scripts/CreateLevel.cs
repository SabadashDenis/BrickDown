using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private Vector3[] positions;
    [SerializeField]
    private float[] hp;
    [SerializeField]
    private GameObject textPrefab;
    [SerializeField]
    public GameObject lvlWinCanvas;
    [SerializeField]
    private GameObject lvlLoseCanvas;
    [SerializeField]
    private GameObject menuCanvas;
    [SerializeField]
    private Shoot shoot;
    [SerializeField]
    private LevelPassed lvlPassedScript;
    [SerializeField]
    private LevelLosed lvlLosedScript;

    [SerializeField]
    private Image EndTimer;
    [SerializeField]
    private Image EndTimerBar;
    [SerializeField]
    private Text EndTimerText;

    [SerializeField]
    private AudioSource ClickSound;


    private int cubeArrLength = -1;

    List<Cube> Cubes = new List<Cube>();

    public Vector3[] currentLevelPositions()
    {
        //X[0,8],Y[0,8]
        Vector3[] positions;
        int currLvl = PlayerPrefs.GetInt("CurrentLevel");
        switch (currLvl % 5)
        {
            case 1:
                positions = new Vector3[]{ new Vector3(0, 0, 0), new Vector3(2, 0, 0), new Vector3(4, 0, 0), new Vector3(6, 0, 0), new Vector3(8, 0, 0),
                new Vector3(0, 0, 1), new Vector3(8, 0, 1),
                new Vector3(1, 0, 2), new Vector3(3, 0, 2), new Vector3(5, 0, 2), new Vector3(7, 0, 2),
                new Vector3(1, 0, 3), new Vector3(7, 0, 3),
                new Vector3(2, 0, 4), new Vector3(4, 0, 4), new Vector3(6, 0, 4),
                new Vector3(2, 0, 5), new Vector3(6, 0, 5),
                new Vector3(3, 0, 6), new Vector3(5, 0, 6),
                new Vector3(3, 0, 7), new Vector3(5, 0, 7),
                new Vector3(4, 0, 8)
        };
                break;
            case 2:
                positions = new Vector3[]{ new Vector3(0, 0, 0), new Vector3(8, 0, 0),
                new Vector3(1, 0, 1),new Vector3(7, 0, 1),
                new Vector3(2, 0, 2),new Vector3(6, 0, 2),
                new Vector3(3, 0, 3), new Vector3(4, 0, 3), new Vector3(5, 0, 3),
                new Vector3(3, 0, 4), new Vector3(4, 0, 4), new Vector3(5, 0, 4),
                new Vector3(3, 0, 5), new Vector3(4, 0, 5), new Vector3(5, 0, 5),
                new Vector3(2, 0, 6),new Vector3(6, 0, 6),
                new Vector3(1, 0, 7),new Vector3(7, 0, 7),
                new Vector3(0, 0, 8),new Vector3(8, 0, 8),
                };
                break;
            case 3:
                positions = new Vector3[]{ new Vector3(0, 0, 0), new Vector3(2, 0, 0), new Vector3(4, 0, 0), new Vector3(6, 0, 0), new Vector3(8, 0, 0),
                new Vector3(0, 0, 2), new Vector3(8, 0, 2),
                new Vector3(3, 0, 3), new Vector3(5, 0, 3),
                new Vector3(0, 0, 4), new Vector3(8, 0, 4),
                new Vector3(3, 0, 5), new Vector3(5, 0, 5),
                new Vector3(0, 0, 6), new Vector3(8, 0, 6),
                new Vector3(0, 0, 8), new Vector3(2, 0, 8), new Vector3(4, 0, 8), new Vector3(6, 0, 8), new Vector3(8, 0, 8)
                };
                break;
            case 4:
                positions = new Vector3[]{new Vector3(4, 0, 0),
                new Vector3(3, 0, 1), new Vector3(5, 0, 1),
                new Vector3(2, 0, 2), new Vector3(4, 0, 2), new Vector3(6, 0, 2),
                new Vector3(1, 0, 3), new Vector3(3, 0, 3), new Vector3(5, 0, 3), new Vector3(7, 0, 3),
                new Vector3(2, 0, 4), new Vector3(4, 0, 4), new Vector3(6, 0, 4),
                new Vector3(3, 0, 5), new Vector3(5, 0, 5),
                new Vector3(4, 0, 6),
                new Vector3(3, 0, 7), new Vector3(5, 0, 7),
                new Vector3(2, 0, 8), new Vector3(6, 0, 8),
                };
                break;
            default:
                positions = new Vector3[]{ new Vector3(0, 0, 0), new Vector3(2, 0, 0), new Vector3(4, 0, 0), new Vector3(6, 0, 0), new Vector3(8, 0, 0),
                new Vector3(1, 0, 1), new Vector3(3, 0, 1), new Vector3(5, 0, 1), new Vector3(7, 0, 1),
                new Vector3(0, 0, 2), new Vector3(2, 0, 2), new Vector3(4, 0, 2), new Vector3(6, 0, 2), new Vector3(8, 0, 2),
                new Vector3(1, 0, 3), new Vector3(3, 0, 3), new Vector3(5, 0, 3), new Vector3(7, 0, 3),
                new Vector3(0, 0, 4), new Vector3(2, 0, 4), new Vector3(4, 0, 4), new Vector3(6, 0, 4), new Vector3(8, 0, 4),
                new Vector3(1, 0, 5), new Vector3(3, 0, 5), new Vector3(5, 0, 5), new Vector3(7, 0, 5),
                new Vector3(0, 0, 6), new Vector3(4, 0, 6), new Vector3(8, 0, 6)
        };
                break;
        }

        //LIKE CHESS
        //positions = new Vector3[]{ new Vector3(0, 0, 0), new Vector3(2, 0, 0), new Vector3(4, 0, 0), new Vector3(6, 0, 0), new Vector3(8, 0, 0),
        //new Vector3(1, 0, 1), new Vector3(3, 0, 1), new Vector3(5, 0, 1), new Vector3(7, 0, 1),
        //new Vector3(0, 0, 2), new Vector3(2, 0, 2), new Vector3(4, 0, 2), new Vector3(6, 0, 2), new Vector3(8, 0, 2),
        //new Vector3(1, 0, 3), new Vector3(3, 0, 3), new Vector3(5, 0, 3), new Vector3(7, 0, 3),
        //new Vector3(0, 0, 4), new Vector3(2, 0, 4), new Vector3(4, 0, 4), new Vector3(6, 0, 4), new Vector3(8, 0, 4),
        //new Vector3(1, 0, 5), new Vector3(3, 0, 5), new Vector3(5, 0, 5), new Vector3(7, 0, 5),
        //new Vector3(0, 0, 6), new Vector3(4, 0, 6), new Vector3(8, 0, 6)
        //};


        //SPIDER
        //positions = new Vector3[]{ new Vector3(0, 0, 0), new Vector3(8, 0, 0),
        //new Vector3(1, 0, 1),new Vector3(7, 0, 1),
        //new Vector3(2, 0, 2),new Vector3(6, 0, 2),
        //new Vector3(3, 0, 3), new Vector3(4, 0, 3), new Vector3(5, 0, 3),
        //new Vector3(3, 0, 4), new Vector3(4, 0, 4), new Vector3(5, 0, 4),
        //new Vector3(3, 0, 5), new Vector3(4, 0, 5), new Vector3(5, 0, 5),
        //new Vector3(2, 0, 6),new Vector3(6, 0, 6),
        //new Vector3(1, 0, 7),new Vector3(7, 0, 7),
        //new Vector3(0, 0, 8),new Vector3(8, 0, 8),
        //};


        //SQUARE IN SQUARE
        //positions = new Vector3[]{ new Vector3(0, 0, 0), new Vector3(2, 0, 0), new Vector3(4, 0, 0), new Vector3(6, 0, 0), new Vector3(8, 0, 0),
        //new Vector3(0, 0, 2), new Vector3(8, 0, 2),
        //new Vector3(3, 0, 3), new Vector3(5, 0, 3),
        //new Vector3(0, 0, 4), new Vector3(8, 0, 4),
        //new Vector3(3, 0, 5), new Vector3(5, 0, 5),
        //new Vector3(0, 0, 6), new Vector3(8, 0, 6),
        //new Vector3(0, 0, 8), new Vector3(2, 0, 8), new Vector3(4, 0, 8), new Vector3(6, 0, 8), new Vector3(8, 0, 8)
        //};


        //FISH
        //positions = new Vector3[]{new Vector3(4, 0, 0),
        //new Vector3(3, 0, 1), new Vector3(5, 0, 1),
        //new Vector3(2, 0, 2), new Vector3(4, 0, 2), new Vector3(6, 0, 2),
        //new Vector3(1, 0, 3), new Vector3(3, 0, 3), new Vector3(5, 0, 3), new Vector3(7, 0, 3),
        //new Vector3(2, 0, 4), new Vector3(4, 0, 4), new Vector3(6, 0, 4),
        //new Vector3(3, 0, 5), new Vector3(5, 0, 5),
        //new Vector3(4, 0, 6),
        //new Vector3(3, 0, 7), new Vector3(5, 0, 7),
        //new Vector3(2, 0, 8), new Vector3(6, 0, 8),
        //};


        //PIRAMIDE
        //positions = new Vector3[]{ new Vector3(0, 0, 0), new Vector3(2, 0, 0), new Vector3(4, 0, 0), new Vector3(6, 0, 0), new Vector3(8, 0, 0),
        //new Vector3(0, 0, 1), new Vector3(8, 0, 1),
        //new Vector3(1, 0, 2), new Vector3(3, 0, 2), new Vector3(5, 0, 2), new Vector3(7, 0, 2),
        //new Vector3(1, 0, 3), new Vector3(7, 0, 3),
        //new Vector3(2, 0, 4), new Vector3(4, 0, 4), new Vector3(6, 0, 4),
        //new Vector3(2, 0, 5), new Vector3(6, 0, 5),
        //new Vector3(3, 0, 6), new Vector3(5, 0, 6),
        //new Vector3(3, 0, 7), new Vector3(5, 0, 7),
        //new Vector3(4, 0, 8)
        //};


        return positions;
    }

    public void CreateLvl()
    {
        for (int i = 0; i < currentLevelPositions().Length; i++)
        {
            Cubes.Add(new Cube(cubePrefab, ConvertCoordinates(currentLevelPositions()[i]), hp[i] * (PlayerPrefs.GetInt("CurrentLevel") / 5 + 1), textPrefab));
        }
        PlayerPrefs.SetInt("CubesDestroyed", 0);
        PlayerPrefs.SetInt("Score", 0);
        cubeArrLength = Cubes.Count;

        shoot.transform.rotation = Quaternion.Euler(Vector3.forward);
    }

    public void Shoot()
    {
        shoot.ShootBall();
        PlayerPrefs.SetString("IsInGame", "No");
        ClickSound.Play();
    }

    //public void DamageSkillActive()
    //{
    //    if (PlayerPrefs.GetString("DamageSkillActive") == "Yes")
    //    {
    //        PlayerPrefs.SetString("DamageSkillActive", "No");
    //    }
    //    else PlayerPrefs.SetString("DamageSkillActive", "Yes");

    //    ClickSound.Play();
    //}

    //public void CountSkillActive()
    //{
    //    if (PlayerPrefs.GetString("CountSkillActive") == "Yes")
    //    {
    //        PlayerPrefs.SetString("CountSkillActive", "No");
    //    }
    //    else PlayerPrefs.SetString("CountSkillActive", "Yes");

    //    ClickSound.Play();
    //}

    //public void SizeSkillActive()
    //{
    //    if (PlayerPrefs.GetString("SizeSkillActive") == "Yes")
    //    {
    //        PlayerPrefs.SetString("SizeSkillActive", "No");
    //    }
    //    else PlayerPrefs.SetString("SizeSkillActive", "Yes");

    //    ClickSound.Play();
    //}


    private void DeleteCubesAndBalls()
    {
        if (PlayerPrefs.GetInt("CubesDestroyed") >= cubeArrLength * 0.9f && cubeArrLength > 0)
        {
            lvlWinCanvas.SetActive(true);
            Debug.Log(PlayerPrefs.GetInt("CubesDestroyed"));
            Debug.Log(cubeArrLength);
            lvlPassedScript.Passed();


            //delete cubes
            for (int i = 0; i < Cubes.Count; i++)
                if (Cubes[i].isCubeExist())
                    Cubes[i].DeleteCube();
            PlayerPrefs.SetInt("CubesDestroyed", 0);
            Cubes.RemoveRange(0, Cubes.Count);

            //delete balls
            for (int i = 0; i < shoot.balls.Count; i++)
            {
                Destroy(shoot.balls[i]);
                //Debug.Log("Balls destroyed:" + i);
            }
            shoot.balls.RemoveRange(0, shoot.balls.Count);
        }

        if (PlayerPrefs.GetInt("AllBallsShooted") == 1)
        {
            StartCoroutine(LoseLevel());
            PlayerPrefs.SetInt("AllBallsShooted", 0);
        }
    }

    IEnumerator LoseLevel()
    {
        EndTimer.gameObject.SetActive(true);

        for (int i = 5; i > 0; i--)
        {
            EndTimerBar.fillAmount = i / 5.0f;
            EndTimerText.text = Convert.ToString(i);
            yield return new WaitForSeconds(1);
            if (PlayerPrefs.GetInt("CubesDestroyed") == 0)
            {
                EndTimer.gameObject.SetActive(false);
                yield break;
            }
        }
        EndTimer.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("CubesDestroyed") != 0)
        {
            lvlLoseCanvas.SetActive(true);
            lvlLosedScript.Losed();

            //delete cubes
            for (int i = 0; i < Cubes.Count; i++)
                if (Cubes[i].isCubeExist())
                    Cubes[i].DeleteCube();
            PlayerPrefs.SetInt("CubesDestroyed", 0);
            Cubes.RemoveRange(0, Cubes.Count);

            //delete balls
            for (int i = 0; i < shoot.balls.Count; i++)
            {
                Destroy(shoot.balls[i]);
                //Debug.Log("Balls destroyed:" + i);
            }
            shoot.balls.RemoveRange(0, shoot.balls.Count);
        }

        yield break;
    }

    //convert from user coordinates to real
    private Vector3 ConvertCoordinates(Vector3 initialCoords)
    {
        return Vector3.Scale((initialCoords + new Vector3(-4, 0, -7)), new Vector3(1, 1, -1));
    }

    void Update()
    {
        //level passed
        DeleteCubesAndBalls();
    }

    public void CloseWinCanvas()
    {
        lvlWinCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        ClickSound.Play();
    }
    public void CloseLoseCanvas()
    {
        lvlLoseCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        ClickSound.Play();
    }
}
