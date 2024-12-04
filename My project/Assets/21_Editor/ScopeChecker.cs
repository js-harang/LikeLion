using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// EditorWindow를 상속받아 ScopeChecker 클래스를 정의
public class ScopeChecker : EditorWindow
{
    // 사용자 입력을 저장할 문자열 변수
    private string text;

    // 메뉴에 "Tools" 아래 "Scope Checker" 항목 추가
    [MenuItem("Tools/Scope Checker")]
    // 에디터 창을 표시하는 정적 메서드
    public static void ShowWindow()
    {
        // ScopeChecker 창을 생성하고 표시
        GetWindow<ScopeChecker>("Scope Checker");
    }

    // GUI를 그리기 위한 메서드
    private void OnGUI()
    {
        // 수평 레이아웃 시작
        EditorGUILayout.BeginHorizontal();

        // 텍스트 영역을 생성하고 사용자 입력을 text 변수에 저장
        text = EditorGUILayout.TextArea(text, GUILayout.Height(300));

        // "Check Scope" 버튼 생성
        if (GUILayout.Button("Check Scope"))
        {
            // 괄호의 균형을 체크하고 결과에 따라 다이얼로그 표시
            if (AreBracketsBalanced(text))
                EditorUtility.DisplayDialog("Scope Checker", "Scope Check Success", "OK");
            else
                EditorUtility.DisplayDialog("Scope Checker", "Scope Check Fail", "OK");
        }

        // 수평 레이아웃 종료
        EditorGUILayout.EndHorizontal();
    }

    // 주어진 문자열의 괄호가 균형을 이루는지 확인하는 메서드
    public bool AreBracketsBalanced(string expression)
    {
        Stack<char> stack = new(); // 괄호를 저장할 스택 생성

        // 문자열의 각 문자에 대해 반복
        foreach (char c in expression)
        {
            // 여는 괄호일 경우 스택에 추가
            if (c == '(' || c == '[' || c == '{')
                stack.Push(c);
            // 닫는 괄호일 경우
            else if (c == ')' || c == ']' || c == '}')
            {
                // 스택이 비어있으면 균형이 맞지 않음
                if (stack.Count == 0)
                    return false;

                char top = stack.Pop(); // 스택의 가장 위 문자를 꺼냄

                // 닫는 괄호와 여는 괄호가 일치하지 않으면 균형이 맞지 않음
                if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                    return false;
            }
        }

        // 모든 괄호가 균형을 이루면 true 반환
        return stack.Count == 0;
    }
}
