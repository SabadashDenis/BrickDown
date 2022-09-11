using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private GameObject cubePrefab;

    private Vector3 position;

    private float health;

    private GameObject hpText;

    private GameObject cubeObj;

    public GameObject CubePrefab
    {
        get { return cubePrefab; }
        set { cubePrefab = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public GameObject HpText
    {
        get { return hpText; }
        set { hpText = value; }
    }

    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }


    public Cube(GameObject cubeObj, Vector3 pos, float hp, GameObject txt)
    {
        cubePrefab = cubeObj;
        position = pos;
        health = hp;
        hpText = txt;
        hpText = Instantiate(hpText, position + Vector3.up * 0.5f, hpText.transform.rotation);
        hpText.GetComponent<TextMesh>().text = Convert.ToString(health);
        CreateCube();
    }

    public bool isCubeExist()
    {
        if (health > 0)
            return true;
        else return false;
    }

    public void CreateCube()
    {
        hpText.GetComponent<TextMesh>().text = Convert.ToString(health);

        cubeObj = Instantiate(cubePrefab, position, Quaternion.identity);
        cubeObj.AddComponent<Cube>();
        Cube c = cubeObj.GetComponent<Cube>();
        c.health = health;
        c.hpText = hpText;
        c.position = position;
    }

    public void DeleteCube()
    {
        Destroy(hpText);
        Destroy(cubeObj);
        Destroy(this);
    }

}
