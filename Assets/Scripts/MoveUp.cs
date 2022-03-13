using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    // 수정 가능한 float 형 변수 speed 값 40 으로 선언
    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 위치를 Vector3에 절대시간 * 속도만큼 전진 시킨다.
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}