using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// EditorWindow�� ��ӹ޾� ScopeChecker Ŭ������ ����
public class ScopeChecker : EditorWindow
{
    // ����� �Է��� ������ ���ڿ� ����
    private string text;

    // �޴��� "Tools" �Ʒ� "Scope Checker" �׸� �߰�
    [MenuItem("Tools/Scope Checker")]
    // ������ â�� ǥ���ϴ� ���� �޼���
    public static void ShowWindow()
    {
        // ScopeChecker â�� �����ϰ� ǥ��
        GetWindow<ScopeChecker>("Scope Checker");
    }

    // GUI�� �׸��� ���� �޼���
    private void OnGUI()
    {
        // ���� ���̾ƿ� ����
        EditorGUILayout.BeginHorizontal();

        // �ؽ�Ʈ ������ �����ϰ� ����� �Է��� text ������ ����
        text = EditorGUILayout.TextArea(text, GUILayout.Height(300));

        // "Check Scope" ��ư ����
        if (GUILayout.Button("Check Scope"))
        {
            // ��ȣ�� ������ üũ�ϰ� ����� ���� ���̾�α� ǥ��
            if (AreBracketsBalanced(text))
                EditorUtility.DisplayDialog("Scope Checker", "Scope Check Success", "OK");
            else
                EditorUtility.DisplayDialog("Scope Checker", "Scope Check Fail", "OK");
        }

        // ���� ���̾ƿ� ����
        EditorGUILayout.EndHorizontal();
    }

    // �־��� ���ڿ��� ��ȣ�� ������ �̷���� Ȯ���ϴ� �޼���
    public bool AreBracketsBalanced(string expression)
    {
        Stack<char> stack = new(); // ��ȣ�� ������ ���� ����

        // ���ڿ��� �� ���ڿ� ���� �ݺ�
        foreach (char c in expression)
        {
            // ���� ��ȣ�� ��� ���ÿ� �߰�
            if (c == '(' || c == '[' || c == '{')
                stack.Push(c);
            // �ݴ� ��ȣ�� ���
            else if (c == ')' || c == ']' || c == '}')
            {
                // ������ ��������� ������ ���� ����
                if (stack.Count == 0)
                    return false;

                char top = stack.Pop(); // ������ ���� �� ���ڸ� ����

                // �ݴ� ��ȣ�� ���� ��ȣ�� ��ġ���� ������ ������ ���� ����
                if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                    return false;
            }
        }

        // ��� ��ȣ�� ������ �̷�� true ��ȯ
        return stack.Count == 0;
    }
}
