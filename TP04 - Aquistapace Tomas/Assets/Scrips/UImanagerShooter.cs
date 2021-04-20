using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanagerShooter : MonoBehaviour
{
    public PlayerShoot player;
    public GameObject finalPoints;
    public Text textPoints;
    public Text valuePinos;
    public float pointsPerPine = 10;
    public float maxPoints = 100;

    public List<PinoPoint> Pinos;
    public List<Image> ImagePinos;

    private float points;

    void Start()
    {
        finalPoints.SetActive(false);
        points = 0;

        valuePinos.text = pointsPerPine.ToString();
    }

    void Update()
    {
        PointsController();

        ShowPoints();
    }

    void PointsController()
    {
        for (int i = 0; i < Pinos.Count; i++)
        {
            if (Pinos[i].inTheFloor == true && ImagePinos[i].color != Color.red)
            {
                ImagePinos[i].color = Color.red;
                points += pointsPerPine;
            }
        }

        if (points >= maxPoints)
        {
            player.StopGame(true);
        }
    }

    void ShowPoints()
    {
        if (player.stop)
        {
            finalPoints.SetActive(true);
            textPoints.text = points.ToString();
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
