using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // 애니메이터 사용
    private Animator playerAnim;
    // 소리와 파티클
    public AudioClip PoopSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;
    // 수정가능한 float형 가로축입력값 변수 선언
    public float horizontalInput;

    // 수정가능한 float형 속도 변수 10으로 선언
    public float speed = 10.0f;

    // 수정가능한 float형 이동가능한 범위 변수 값 10으로 선언
    private float xRange = 16;

    // 수정가능한 게임오브젝트형 변수 projectilePrefab선언
    public GameObject projectilePrefab;

    private bool isGameOver;

    private bool isGround;

    private Rigidbody playerRb;

    [SerializeField]
    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 화면 밖으로 못나가게 조정 범위는 xRange값 만큼
        if(transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // 스페이스 키가 눌리면
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 똥발사
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(PoopSound, 1.0f);
        }

        
        // 좌우 버튼이 눌릴시에 값 삽입
        horizontalInput = Input.GetAxis("Horizontal");
        // 위치를 Vector3에 좌우 * 입력받은 값 * 절대시간 * 속도 만큼 변경
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        

    }

    // 충돌 함수
    private void OnCollisionStay(Collision collision)
    {
        // 플레이어가 땅과 닿아있을경우
        if(collision.gameObject.CompareTag("Ground"))
        {
            
            // 땅인지? 조건을 참으로
            isGround = true;
            // 모래 이펙트 실행
            dirtParticle.Play();
        }   
        // 플레이어가 똥과 닿을경우
        else if (collision.gameObject.CompareTag("Poop"))
        {
            // 게임오버 조건 참으로
            isGameOver = true;
            Debug.Log("Game Over!");
            gameManager.GameOver();
            // 폭발 이펙트 실행
            explosionParticle.Play();
            // 모래 이펙트 종료
            dirtParticle.Stop();
            // 충돌 소리 실행
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }

    }

}