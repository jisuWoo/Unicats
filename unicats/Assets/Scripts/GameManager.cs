using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int bestscore = 0;
    public string GameState;

    LevelManager theLM;
    PlayerControl thePC;
    
    //ui part
    public GameObject GamePause;
    public GameObject GameRule;
    public GameObject GameEnd;
    //결과창
    public TextMeshProUGUI score_txt;
    public TextMeshProUGUI bestscore_txt;
    
    public TextMeshProUGUI scoreText;

    public float game_timer = 0.0f;

    private void Awake() {
        bestscore = PlayerPrefs.GetInt("bestscore");
        theLM = FindObjectOfType<LevelManager>();
        thePC = FindObjectOfType<PlayerControl>();
    }
    
    //타임및 세팅
    void Start()
    {   
        Time.timeScale = 1;
        GameState = "Play";   
        score = 0;
        //theLM.MakeEnmey();
    }

    //오브젝트 생성
    //levelmanager로 분리
    //playerprefs를 이용한 점수 저장
    void Update()
    {
        this.game_timer += Time.deltaTime;
        scoreText.text = "점수 : " + score.ToString();

        if(thePC.PlayerHp < 0 || thePC.Player.transform.position.y < -7.0f ){
            if(score > bestscore){
                bestscore = score;
                PlayerPrefs.SetInt("bestscore",score);
                PlayerPrefs.Save();
            }
            GameState = "End";
            bestscore = PlayerPrefs.GetInt("bestscore");
            GameEnd.SetActive(true);
            score_txt.text = "점수 : " + score.ToString();
            bestscore_txt.text = "최고 점수: " + bestscore.ToString();
            Time.timeScale = 0;
        }
        if(GameState == "Play")
        {
            GameEnd.SetActive(false);
            //JumpBtn.SetActive(true);
        }
        else
        {
            //JumpBtn.SetActive(false);
        }
    }

    public float getPlayTime()
    {
        float time;
        time = this.game_timer;
        return(time);
    }

    //스타트 버튼
    public void Startbutton(){
        GameState = "Play";
        SceneManager.LoadScene(1);
    }
    //멈춤버튼
    public void Pausebutton(){

        if (GameState == "Play") {
            GamePause.SetActive(true);
            Time.timeScale = 0;
            GameState = "Pause";
        } else if (GameState == "Rule") 
        {
            Time.timeScale = 0;

        } else {
            GamePause.SetActive(false);
            Time.timeScale = 1;
            GameState = "Play";
        }
    }
    //버튼 메소드 설명 버튼
    public void Rulebutton()
    {

        if (GameState == "Play")
        {
            GameRule.SetActive(true);
            Time.timeScale = 0;
            GameState = "Rule";
        }
        else if(GameState == "Pause")
        {
            Time.timeScale = 0;
        }
        else
        {
            GameRule.SetActive(false);
            Time.timeScale = 1;
            GameState = "Play";
        }

    }
}
