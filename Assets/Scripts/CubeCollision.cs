using System;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePref;
    private Cube cube;



    private void Start()
    {
        cube = cubePref.GetComponent<Cube>();
        //levelPassed = new LevelPassed();
    }
    private void Update()
    {
        //if lvl ended
        if (PlayerPrefs.GetString("LevelPassed") == "Yes")
        {
            //levelPassed.Passed();
            Destroy(cube.gameObject);
            Destroy(cube.HpText.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (PlayerPrefs.GetString("DamageSkillActive") == "Yes")
            {
                cube.Health -= PlayerPrefs.GetInt("BallDamage") * PlayerPrefs.GetInt("DamageSkillValue");
            }
            else { cube.Health -= PlayerPrefs.GetInt("BallDamage"); }

            cube.HpText.GetComponent<TextMesh>().text = Convert.ToString(cube.Health);
            DestroyCube();
        }
    }

    private void DestroyCube()
    {
        if (cube.Health <= 0)
        {
            Destroy(cube.gameObject);
            Destroy(cube.HpText.gameObject);
            PlayerPrefs.SetInt("CubesDestroyed", PlayerPrefs.GetInt("CubesDestroyed") + 1);
        }
    }
}
