using System.Linq;
using UnityEngine;

public class ArrayExamples : MonoBehaviour
{
    //상수화 시킨 숫자를 쓴다
    private const int ARRAY_Size = 10;

    // 플레이어 점수를 저장하는 배열
    private int[] playerScores = new int[5];

    // 아이템 이름을 저장하는 배열
    private string[] itemNames = { "검", "방패", "포션", "활", "마법서" };

    // 적 프리팹을 저장하는 배열
    public GameObject[] enemyPrefabs;

    // 맵의 타일 타입을 저장하는 2D 배열
    private int[,] mapTiles = new int[10, 10];

    // 1차원 배열도 같은 메모리 공간을 가지게 된다
    private int[] mapTiles2 = new int[100];

    private void Start()
    {
        for (var i = 0; i < playerScores.Length; i++)
        {
            playerScores[i] = i;
        }

        for (int i = 0; i < playerScores.Length; i++)
        {
            Debug.Log(playerScores[i]);
        }

        for (int i = 0; i < mapTiles.Length; i++)
        {
            for (int j = 0; j < mapTiles.GetLength(1); j++)
            {
                mapTiles[i, j] = 0;
            }
        }
    }

    private void PlayerScoresExample()
    {
        // 플레이어 점수 할당
        for (int i = 0; i < playerScores.Length; i++)
        {
            playerScores[i] = Random.Range(100, 1000);
        }

        // 최고 점수 찾기
        int highestScore = playerScores.Max();
        Debug.Log($"최고 점수 : {highestScore}");

        // 평균 점수 계산
        double averageScore = playerScores.Average();
        Debug.Log($"평균 점수 : {averageScore}");
    }
}