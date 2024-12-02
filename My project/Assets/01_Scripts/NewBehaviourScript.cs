using System.Linq;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // 최대값 찾기(Max())
        int maxNumber = numbers.Max();
        Debug.Log("최대값: " + maxNumber);

        // 최소값 찾기 (Min())
        int minNumber = numbers.Min();
        Debug.Log("최소값: " + minNumber);

        // 합계 계산 (Sum())
        int sum = numbers.Sum();
        Debug.Log("합계: " + sum);

        // 평균 계산 (Avg())
        double average = numbers.Average();
        Debug.Log("평균: " + average);
    }
}
