using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // 콜리전 충돌 감지 함수 선언( 다른 콜라이더와 충돌시 )
    void OnTriggerEnter(Collider collision) {

        if(collision.gameObject.CompareTag("Poop"))
        {
        // 파괴
        Destroy(gameObject);
        // 다른 오브젝트도 파괴
        Destroy(collision.gameObject);
        }
    }

}