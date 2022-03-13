using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // 수정 불가능한 float형 천장 높이 30으로 지정
    private float topBound = 30;
    // 바닥 위치는 -10 지정
    private float lowerBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 위치가 Z축 topBound 도달시 파괴
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        // z축 lowerBound 도달해도 파괴 
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}