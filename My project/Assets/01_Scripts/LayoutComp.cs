using UnityEngine;

public class LayoutComp : MonoBehaviour
{
    [Header("Life"), Tooltip("�λ��� ���� �����Դϴ�.")]
    public string data1;
    [Tooltip("�λ��� ���� ����2�Դϴ�.")]
    public string data2;
    [Tooltip("�λ��� ���� ����3�Դϴ�.")]
    public string data3;

    [Header("Love"), Tooltip("����� ���� �����Դϴ�")]
    public string data4;
    public string data5;
    public string data6;

    [Header("Power"), Range(0.1f, 5f)]
    public float data7;
}
