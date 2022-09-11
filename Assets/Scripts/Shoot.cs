using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private GameObject shootButtonPressed;
    [SerializeField]
    private Text score;

    public List<GameObject> balls;

    [SerializeField]
    public GameObject DamageSkillUsed;
    [SerializeField]
    public GameObject CountSkillUsed;
    [SerializeField]
    public GameObject SizeSkillUsed;

    [SerializeField]
    public Text DamageSkillUsedText;
    [SerializeField]
    public Text CountSkillUsedText;
    [SerializeField]
    public Text SizeSkillUsedText;

    [SerializeField]
    public GameObject damageLock;
    [SerializeField]
    public GameObject countLock;
    [SerializeField]
    public GameObject sizeLock;

    private Vector3 lastAddForce;

    [SerializeField]
    private GameObject exitButton;

    [SerializeField]
    private AudioSource kickSound;




    Ray ray;

    public GameObject ShootButtonPressed
    {
        get { return shootButtonPressed; }
    }

    public GameObject Ball
    {
        get { return ball; }
    }

    public int Damage
    {
        get { return PlayerPrefs.GetInt("BallDamage"); }
        set { damage = value; }
    }

    void Start()
    {
         ray = new Ray(transform.position, transform.forward);
    }

    void Update()
    {
        score.text = "Счёт: " + PlayerPrefs.GetInt("Score");
        ActiveSizeSkill();
    }

    private void ActiveSizeSkill()
    {
        if (PlayerPrefs.GetString("SizeSkillActive") == "Yes" && Ball.gameObject.GetComponent<Transform>().localScale == new Vector3(0.7f, 0.7f, 0.7f))
        {
            Ball.gameObject.GetComponent<Transform>().localScale = Ball.gameObject.GetComponent<Transform>().localScale * PlayerPrefs.GetFloat("SizeSkillValue");
        }
        if (PlayerPrefs.GetString("SizeSkillActive") != "Yes")
            Ball.gameObject.GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }


    public void ShootBall()
    {
        if(PlayerPrefs.GetString("DamageSkillActive") == "Yes")
        {
            Damage = PlayerPrefs.GetInt("BallDamage") * PlayerPrefs.GetInt("DamageSkillValue");
        } else { Damage = PlayerPrefs.GetInt("BallDamage"); }

        LockUsedSkills();
        StartCoroutine(ShootBallsWithDelay());
        shootButtonPressed.SetActive(true);
        exitButton.SetActive(false);
    }

    IEnumerator ShootBallsWithDelay()
    {
        if (PlayerPrefs.GetString("CountSkillActive") == "Yes")
        {
            for (int i = 0; i < (PlayerPrefs.GetInt("BallsCount") * PlayerPrefs.GetFloat("CountSkillValue")); i++)
            {
                balls.Add(Instantiate(ball, ball.transform.position, ball.transform.rotation));
                yield return new WaitForSeconds(0.1f);
                if (balls[i] != null)
                    balls[i].GetComponent<Rigidbody>().AddForce(ball.transform.forward * 400f, ForceMode.Acceleration);

                if (i == (PlayerPrefs.GetInt("BallsCount") * PlayerPrefs.GetFloat("CountSkillValue") - 1))
                    PlayerPrefs.SetInt("AllBallsShooted", 1);
            }
        } else
        {
            for (int i = 0; i < PlayerPrefs.GetInt("BallsCount"); i++)
            {
                balls.Add(Instantiate(ball, ball.transform.position, ball.transform.rotation));
                yield return new WaitForSeconds(0.1f);
                if (balls[i] != null)
                    balls[i].GetComponent<Rigidbody>().AddForce(ball.transform.forward * 400f, ForceMode.Acceleration);

                if (i == (PlayerPrefs.GetInt("BallsCount") - 1))
                    PlayerPrefs.SetInt("AllBallsShooted", 1);
            }
        }
        yield break;
    }

    private void LockUsedSkills()
    {
        if (PlayerPrefs.GetString("DamageSkillActive") == "Yes")
        {
            DamageSkillUsed.SetActive(true);
            PlayerPrefs.SetInt("DamageSkillTimer", 5);
            DamageSkillUsedText.text = Convert.ToString(PlayerPrefs.GetInt("DamageSkillTimer") - 1);
        }
        else if(PlayerPrefs.GetInt("DamageSkillTimer") == 0) damageLock.SetActive(true);

        if (PlayerPrefs.GetString("CountSkillActive") == "Yes")
        {
            CountSkillUsed.SetActive(true);
            PlayerPrefs.SetInt("CountSkillTimer", 4);
            CountSkillUsedText.text = Convert.ToString(PlayerPrefs.GetInt("CountSkillTimer") - 1);
        }
        else if (PlayerPrefs.GetInt("CountSkillTimer") == 0) countLock.SetActive(true);

        if (PlayerPrefs.GetString("SizeSkillActive") == "Yes")
        {
            SizeSkillUsed.SetActive(true);
            PlayerPrefs.SetInt("SizeSkillTimer", 3);
            SizeSkillUsedText.text = Convert.ToString(PlayerPrefs.GetInt("SizeSkillTimer") - 1);
        }
        else if (PlayerPrefs.GetInt("SizeSkillTimer") == 0) sizeLock.SetActive(true);
    }

    public void UnlockSkills()
    {
        DamageSkillUsed.SetActive(false);
        CountSkillUsed.SetActive(false);
        SizeSkillUsed.SetActive(false);
    }

    //check bug when ball lost speed
    IEnumerator CheckBallCurrentSpeed() {
        Vector3 compareVector = new Vector3(5, 5, 5);
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.1f);
            if (Math.Abs(GetComponent<Rigidbody>().velocity.x) < compareVector.x && Math.Abs(GetComponent<Rigidbody>().velocity.z) < compareVector.z)
                GetComponent<Rigidbody>().AddForce(lastAddForce * 300, ForceMode.Acceleration);
        }
        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            kickSound.Play();
            if (PlayerPrefs.GetString("DamageSkillActive") == "Yes")
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + PlayerPrefs.GetInt("BallDamage") * PlayerPrefs.GetInt("DamageSkillValue"));
            }
            else { PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + PlayerPrefs.GetInt("BallDamage")); }
            score.text = "Счёт: " + PlayerPrefs.GetInt("Score");
        }

        GetComponent<Rigidbody>().AddForce(Vector3.Reflect(ray.direction, collision.contacts[0].normal) * 400f, ForceMode.Acceleration);
        lastAddForce= Vector3.Reflect(ray.direction, collision.contacts[0].normal);

         ray = new Ray(transform.position, Vector3.Reflect(ray.direction, collision.contacts[0].normal));
        StartCoroutine(CheckBallCurrentSpeed());
    }

}
