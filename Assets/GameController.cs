using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject[] asteroid;
    public GameObject exitBtn, replayBtn, homeBtn, endPanel, joystick;
    public Text scoreText, lifeText, gameOverText, levelText;
    float left, right, up;
    float prevTime, delta;
    int score, life, aux, level;

    // Use this for initialization
    void Start()
    {
        left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x;
        right = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).x;
        up = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).y + 50;
        prevTime = Time.realtimeSinceStartup;
        delta = 1.0f;
        StartCoroutine(LaunchAsteroids());
        resetResult();
    }

    // Update is called once per frame
    void Update()
    {
        float nowTime = Time.realtimeSinceStartup;
    }

    void resetResult(){
        score = 0;
        life = 3;
        level = 1;
        lifeText.text = life.ToString();
        scoreText.text = score.ToString("000");
        levelText.text = level.ToString("000");
        gameOverText.text = "";
        ControlObjects();
    }

    void ControlObjects(){
        exitBtn.SetActive(false);
        replayBtn.SetActive(false);
        endPanel.SetActive(false);
        homeBtn.SetActive(true);
        joystick.SetActive(true);
        MoveForward.speed = 30;
    }

    IEnumerator LaunchAsteroids()
    {
        while (true)
        {
            for (int i = 0; i < 6; i++)
            {
                int prueba = asteroid.Length;
                Instantiate(asteroid[Random.Range(0, asteroid.Length - 1)]).transform.position = new Vector3(
                                Random.Range(left, right),
                                up,
                                0);
                yield return new WaitForSeconds(delta);
            }

            yield return new WaitForSeconds(delta * 5.0f);
        }
    }

    public void UpdateScore(int inc)
    {
        this.aux += inc;
        score += inc;
        scoreText.text = score.ToString("000");
        changeLevel(aux);
    }

    public void changeLevel(int aux){
        if(aux >= 100){
            level += 1;
            levelText.text = level.ToString("000");
            this.aux = 0;
            MoveForward.speed += 10;
        } 
    }

    public int UpdateLifes()
    {
        life = life-1;

        if (life <= 0) {
            lifeText.text = life.ToString();
            endGame(); 
        }else{
            lifeText.text = life.ToString();
        }
        return life;

    }

    public void endGame(){
        gameOverText.text = "GAME OVER";
        exitBtn.SetActive(true);
        replayBtn.SetActive(true);
        endPanel.SetActive(true);
        homeBtn.SetActive(false);
        joystick.SetActive(false);

    }

}
