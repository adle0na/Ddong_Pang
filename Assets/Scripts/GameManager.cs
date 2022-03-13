using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 게임오버 텍스트 지정 사용 선언
    public TextMeshProUGUI gameOverText;
    // 리스트 배열값의 targets 지정 사용 선언
    public List<GameObject> targets;
    // 점수 텍스트 지정 사용 선언
    public TMP_Text scoreText;
    // 게임 동작 불변수 선언
    public bool isGameActive;
    // 버튼 지정 사용 선언
    public Button restartButton;

    public GameObject gameOverScreen;

    private int score;
    // BGM
    [SerializeField]
    private AudioSource playerAudio;

    void Start()
    {
        isGameActive = true;
        playerAudio = GetComponent<AudioSource>();
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive == false)
        {
            playerAudio.Stop();
        }

        UpdateScore(0);

    }
        public void GameOver()
    {
        // 재시작 버튼, 게임오버 텍스트 켜주고 게임 동작상태 Off
        //restartButton.gameObject.SetActive(true);
        //gameOverText.gameObject.SetActive(true);
        gameOverScreen.SetActive(true);
        isGameActive = false;
    }

        public void UpdateScore(int scoreToAdd)
    {
        // 스코어에 더할점수를 더한다
        score += scoreToAdd;
        // 스코어 글자 표시
        scoreText.text = "Score: " + Time.fixedTime;
    }

        public void RestartGame()
    {
        // 현재 실행되고 있는 Scene재시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

        public void StartGame(int difficulty)
    {
        // 스코어 0으로 시작
        score = 0;
        // UpdateScore함수 0값으로 실행
        UpdateScore(0);
        // 게임 동작상태 On
        isGameActive = true;
        gameOverScreen.SetActive(false);
    }
}
