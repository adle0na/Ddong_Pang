using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 수정가능한 float형 가로축입력값 변수 선언
    public float horizontalInput;

    // 수정가능한 float형 속도 변수 10으로 선언
    public float speed = 10.0f;

    // 수정가능한 float형 이동가능한 범위 변수 값 10으로 선언
    private float xRange = 16;

    // 수정가능한 게임오브젝트형 변수 projectilePrefab선언
    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        
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
            // 피자 생성
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        
        // 좌우 버튼이 눌릴시에 값 삽입
        horizontalInput = Input.GetAxis("Horizontal");
        // 위치를 Vector3에 좌우 * 입력받은 값 * 절대시간 * 속도 만큼 변경
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        
    }
}