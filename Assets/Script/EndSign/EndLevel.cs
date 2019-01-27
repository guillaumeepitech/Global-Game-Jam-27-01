﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    GameObject Player;
    public GameObject canvas;
    public Text textScore;
    public Text textScoreDeath;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > transform.position.x)
        {
            score += GameObject.FindGameObjectWithTag("Player").GetComponent<LootBox>().GetScore();
            Debug.Log(score);
            textScore.text = "score : " + GameObject.FindGameObjectWithTag("Player").GetComponent<LootBox>().GetScore();
            canvas.SetActive(true);
        }
        if (textScoreDeath.IsActive())
        {
            textScoreDeath.text = "score : " + GameObject.FindGameObjectWithTag("Player").GetComponent<LootBox>().GetScore();
        }
    }

    public void BackToMenu()
    {
        canvas.SetActive(false);
        GetComponent<SelecLevel>().LaunchScene(1, true, score);
    }

    public void BackToMenudeLose()
    {
        canvas.SetActive(false);
        GetComponent<SelecLevel>().LaunchScene(1, false, score);
    }

    public void NextLevel()
    {
        canvas.SetActive(false);
        GetComponent<SelecLevel>().LaunchScene(SceneManager.GetActiveScene().buildIndex + 1, score);
    }

    public void Retry()
    {
        canvas.SetActive(false);
        GetComponent<SelecLevel>().LaunchScene(SceneManager.GetActiveScene().buildIndex, score);
    }

}
