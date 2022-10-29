using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject GameOverImage;
    private GameController controller;
    public Text ActualRecordText;
    public Text MaxRecordText;
    public Text PointText;
    private float record;
    private int prefersScore;

    [Header("Medal Attributs Cofigurations :")]
    public Image MedalObject;
    public Sprite GoldMedal, SilverMedal, CobreMedal;

    public int point;

    public void Start()
    {
        this.record = PlayerPrefs.GetFloat("record");
        this.prefersScore = PlayerPrefs.GetInt("score");
        this.controller = GameObject.FindObjectOfType<GameController>();
    }

    private void Update()
    {
        this.SetPointText();
    }

    public void setActiveGameOverImage()
    {
        this.GameOverImage.SetActive(true);
    }

    public void setRecordPainel()
    {
        int min = (int)Time.timeSinceLevelLoad / 60;
        int sec = (int)Time.timeSinceLevelLoad % 60;
        int score = this.controller.getPoint();
        if(score > this.prefersScore)
        {
            PlayerPrefs.SetInt("score", score);
        }
        ActualRecordText.text = string.Format("you survived {0} min and {1} sec - SCORE: {2} .", min, sec, score);
        if (Time.timeSinceLevelLoad > this.record)
        {
            MaxRecordText.text = string.Format("Longest record is {0} minute and {1} seconds - MAX SCORE: {2} .", min, sec, (score > this.prefersScore)? score : this.prefersScore);
            PlayerPrefs.SetFloat("record", Time.timeSinceLevelLoad);
        }
        else
        {
            int minute = (int)this.record / 60;
            int seconde = (int)this.record % 60;
            MaxRecordText.text = string.Format("Longest record is {0} minute and {1} seconds - MAX SCORE: {2} .", minute, seconde, (score > this.prefersScore) ? score : this.prefersScore);
        }
    }
    public void SetPointText()
    {
        this.point = controller.getPoint();
        this.PointText.text = string.Format("{0}", this.point);
     }

    public void setMedal()
    {
        if(this.point >= this.prefersScore - 2)
        {
            this.MedalObject.sprite = this.GoldMedal;
        }
        else if(this.point >= this.prefersScore / 2)
        {
            this.MedalObject.sprite = this.SilverMedal;
        }
        else
        {
            this.MedalObject.sprite = this.CobreMedal;
        }

    }

}
