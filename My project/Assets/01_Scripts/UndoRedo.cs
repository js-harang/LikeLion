using System.Collections.Generic;
using UnityEngine;

public class UndoRedo : MonoBehaviour
{
    // ���� ��ġ�� ������ ���� ����
    private Stack<Vector3> undoStack = new();
    // �ǵ�����(redo) ��ġ�� ������ ���� ����
    private Stack<Vector3> redoStack = new();

    public float moveSpeed = 5f;
    public GameObject targetObject;

    void Start()
    {
        // ���� ��ġ�� ���ÿ� ����
        undoStack.Push(targetObject.transform.position);
    }

    void Update()
    {
        // �̵� ������ ������ ���� �ʱ�ȭ
        Vector3 movePos = Vector3.zero;

        // W Ű�� ������ ������ �̵�
        if (Input.GetKey(KeyCode.W))
            movePos += transform.forward;
        // S Ű�� ������ �ڷ� �̵�
        if (Input.GetKey(KeyCode.S))
            movePos -= transform.forward;
        // A Ű�� ������ �������� �̵�
        if (Input.GetKey(KeyCode.A))
            movePos -= transform.right;
        // D Ű�� ������ ���������� �̵�
        if (Input.GetKey(KeyCode.D))
            movePos += transform.right;

        // �̵� ������ 0�� �ƴ� ���, ��� ��ü�� �̵�
        if (movePos != Vector3.zero)
            targetObject.transform.position += moveSpeed * Time.deltaTime * movePos.normalized;

        // �̵� ������ 0�̰�, ���ÿ� ��ġ�� ������, ���� ��ġ�� ������ ���� �� ��ġ�� �ٸ� ���
        if (movePos == Vector3.zero && undoStack.Count > 0 && targetObject.transform.position != undoStack.Peek())
        {
            // ���� ��ġ�� ���ÿ� ����
            undoStack.Push(targetObject.transform.position);
            // redo ������ ��� (���ο� �̵��� �߻������Ƿ�)
            redoStack.Clear();
        }

        // Z Ű�� ������ undo ��� ����
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // undo ���ÿ� �� �� �̻��� ��ġ�� ���� ���
            if (undoStack.Count > 1)
            {
                // ���� ��ġ�� redo ���ÿ� ����
                redoStack.Push(undoStack.Pop());
                // ���� ��ġ�� �̵�
                targetObject.transform.position = undoStack.Peek();
            }
        }

        // Y Ű�� ������ redo ��� ����
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // redo ���ÿ� ��ġ�� ���� ���
            if (redoStack.Count > 0)
            {
                // redo ������ ��ġ�� �̵�
                targetObject.transform.position = redoStack.Peek();
                // redo ���ÿ��� ��ġ�� ������ positionStack�� ����
                undoStack.Push(redoStack.Pop());
            }
        }
    }
}
