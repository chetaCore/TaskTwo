using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private ActiveWall wall;
    private int score = 0;
    


    private void Awake()
    {
        wall = GetComponent<ActiveWall>();

        EventSet.objectDestroed.AddListener(AddScore);
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    private void AddScore(TypesSet.Type type)
    {
        if (type.Equals(wall.type))
            scoreText.text = (score += 1).ToString();
    }
}
