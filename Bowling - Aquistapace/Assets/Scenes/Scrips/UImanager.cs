using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public BolaMov bola;
    public GameObject finalPoints;
    public Text textPoints;

    public float pointsPerPine = 10;

    public List<PinoPoint> Pinos;
    public List<Image> ImagePinos;
    public List<Image> NumberOfShots;

    private float points;
    private float timeCount;

    void Start()
    {
        finalPoints.SetActive(false);
        points = 0;
    }

    void Update()
    {
        for (int i = 0; i < Pinos.Count; i++)
        {
            if (Pinos[i].inTheFloor == true && ImagePinos[i].color != Color.red)
            {
                ImagePinos[i].color = Color.red;
                points += pointsPerPine;
            }
        }

        ShowPoints();

        ShotsController();
    }

    void ShowPoints()
    {
        if (bola.stop == true && timeCount >= 2)
        {
            finalPoints.SetActive(true);
            textPoints.text = points.ToString();
        }
        else if (bola.stop == true)
        {
            timeCount += Time.deltaTime;
        }
    }

    void ShotsController()
    {
        if (bola.actualShot == 1)
        {
            NumberOfShots[0].color = Color.black;
        }
        else if (bola.actualShot == 2)
        {
            NumberOfShots[1].color = Color.black;
        }
        else if (bola.actualShot == 3)
        {
            NumberOfShots[2].color = Color.black;
        }
    }
}
