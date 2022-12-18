using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TypesSet;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private ActiveWall _wall;
    private int _score = 0;

    private void Awake()
    {
        _wall = GetComponent<ActiveWall>();
    }

    private void OnEnable()
    {
        EventSet.objectDestroed += AddScore;
    }

    private void Start()
    {
        _scoreText.text = _score.ToString();
    }

    private void AddScore(ElementColor elemColor)
    {
        if (elemColor.Equals(_wall.type))
            _scoreText.text = (_score += 1).ToString();
    }

    private void OnDisable()
    {
        EventSet.objectDestroed -= AddScore;
    }
}
