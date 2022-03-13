using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // 스폰 범위 x축 20
    private float spawnRangeX = 16;

    // 스폰 범위 z축 20
    private float spawnPosZ = 20;

    // 스폰 시작 딜레이 2초
    private float startDelay = 2;

    // 스폰 간격 1.5초
    private float spawnInterval = 0.5f;
    public GameObject[] poopPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPoop", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    // 똥 스폰 함수
    void SpawnPoop(){
        // 똥 인덱스 값 랜덤으로 0 ~ 배열길이만큼
        int poopIndex = Random.Range(0, poopPrefabs.Length);
        // Vector3의 spawnPos에 랜덤으로 -x ~ x , Y값 0 고정, z값 spawnPosZ값으로 고정하여
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        // 소환 
        Instantiate(poopPrefabs[poopIndex], spawnPos, poopPrefabs[poopIndex].transform.rotation);
    }
}