using System.Linq;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // �ִ밪 ã��(Max())
        int maxNumber = numbers.Max();
        Debug.Log("�ִ밪: " + maxNumber);

        // �ּҰ� ã�� (Min())
        int minNumber = numbers.Min();
        Debug.Log("�ּҰ�: " + minNumber);

        // �հ� ��� (Sum())
        int sum = numbers.Sum();
        Debug.Log("�հ�: " + sum);

        // ��� ��� (Avg())
        double average = numbers.Average();
        Debug.Log("���: " + average);
    }
}
