using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    private CanvasController canvas;
    [SerializeField]
    public AudioClip PointAudio;
    private int Point;
    

    private void Start()
    {
        Time.timeScale = 1;
        this.canvas = GameObject.FindWithTag("Canvas").GetComponent<CanvasController>();
    }
    public void GameOver()
    {
        this.canvas.setMedal();
        this.canvas.setRecordPainel();
        this.canvas.setActiveGameOverImage();
        Time.timeScale = 0;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void setPoint()
    {
        AudioController.currentAudioSource.PlayOneShot(this.PointAudio);
        this.Point++;
    }
    public int getPoint()
    {
        return this.Point;
    }
}
