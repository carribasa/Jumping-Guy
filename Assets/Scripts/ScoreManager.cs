using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public Text pointsText, maxPointsText;
    [SerializeField] private int points = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateMaxPoints();
    }

    public void IncreasePoints()
    {
        points++;
        pointsText.text = points.ToString();
        UpdateMaxPoints();
    }

    // Llama al registro de puntuacion maxima y lo carga
    // Tambien guarda la puntuacion maxima si se supera la registrada
    public void UpdateMaxPoints()
    {
        //! Tiene que comprobar si existe el registo "Max" y si no, manda por defecto 0
        int maxPoints = PlayerPrefs.GetInt("Max", 0);

        if(points >= maxPoints )
        {
            maxPoints = points;
            PlayerPrefs.SetInt("Max", maxPoints);
        }

        maxPointsText.text = "BEST: " + maxPoints.ToString();
    }
}
