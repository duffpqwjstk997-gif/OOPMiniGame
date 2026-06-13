using UnityEngine;

public class GameManager : MonoBehaviour
{
    Generator generator;
    public GameObject enemyPrefab;
    public GameObject[] creation = new GameObject[40];
    private float nextSpawnTime = 0f;
    public int spawnNum = 0;
    void Start()
    {
        generator = new Generator();
        for(int i = 0; i < creation.Length; i++)
        {
            creation[i] = generator.Generate(enemyPrefab, Vector3.zero);
            creation[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime)
        {
            // 1. 배열의 0번째 칸부터 끝까지 차례대로 검사합니다.
            for (int i = 0; i < creation.Length; i++)
            {
                // 2. 만약 i번째 적이 현재 꺼져있는(비활성화) 상태라면?
                if (!creation[i].activeSelf)
                {
                    Vector3 playerPos = Player.instance.transform.position;
                    Vector3 spawnPosition = new Vector3(playerPos.x + 20 + Random.Range(-10f, 10f), 0f, 0f);

                    // 3. 적의 위치를 스폰 위치로 옮겨줍니다.
                    creation[i].transform.position = spawnPosition;

                    // 4. 꺼져있던 적을 다시 켜줍니다. (소환!)
                    creation[i].SetActive(true);

                    // 5. 한 번에 한 마리만 소환해야 하므로, 찾아서 켰다면 반복문을 즉시 탈출합니다.

                    if (spawnNum == 2)
                    {
                        spawnNum = 0;
                        break;
                    }
                    spawnNum++;
                }
            }


            nextSpawnTime = Time.time + 4f; // 3초마다 적 생성 시간 갱신
        }
    }
}
