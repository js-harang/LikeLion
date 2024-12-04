using UnityEngine;

public class LayoutComp : MonoBehaviour
{
    [Header("Life"), Tooltip("인생에 관한 변수입니다.")]
    public string data1;
    [Tooltip("인생에 관한 변수2입니다.")]
    public string data2;
    [Tooltip("인생에 관한 변수3입니다.")]
    public string data3;

    [Header("Love"), Tooltip("사랑에 관한 변수입니다")]
    public string data4;
    public string data5;
    public string data6;

    [Header("Power"), Range(0.1f, 5f)]
    public float data7;
}
