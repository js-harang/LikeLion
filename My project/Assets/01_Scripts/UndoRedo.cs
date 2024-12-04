using System.Collections.Generic;
using UnityEngine;

public class UndoRedo : MonoBehaviour
{
    // 이전 위치를 저장할 스택 생성
    private Stack<Vector3> undoStack = new();
    // 되돌리기(redo) 위치를 저장할 스택 생성
    private Stack<Vector3> redoStack = new();

    public float moveSpeed = 5f;
    public GameObject targetObject;

    void Start()
    {
        // 시작 위치를 스택에 저장
        undoStack.Push(targetObject.transform.position);
    }

    void Update()
    {
        // 이동 방향을 저장할 변수 초기화
        Vector3 movePos = Vector3.zero;

        // W 키가 눌리면 앞으로 이동
        if (Input.GetKey(KeyCode.W))
            movePos += transform.forward;
        // S 키가 눌리면 뒤로 이동
        if (Input.GetKey(KeyCode.S))
            movePos -= transform.forward;
        // A 키가 눌리면 왼쪽으로 이동
        if (Input.GetKey(KeyCode.A))
            movePos -= transform.right;
        // D 키가 눌리면 오른쪽으로 이동
        if (Input.GetKey(KeyCode.D))
            movePos += transform.right;

        // 이동 방향이 0이 아닐 경우, 대상 객체를 이동
        if (movePos != Vector3.zero)
            targetObject.transform.position += moveSpeed * Time.deltaTime * movePos.normalized;

        // 이동 방향이 0이고, 스택에 위치가 있으며, 현재 위치가 스택의 가장 위 위치와 다를 경우
        if (movePos == Vector3.zero && undoStack.Count > 0 && targetObject.transform.position != undoStack.Peek())
        {
            // 현재 위치를 스택에 저장
            undoStack.Push(targetObject.transform.position);
            // redo 스택을 비움 (새로운 이동이 발생했으므로)
            redoStack.Clear();
        }

        // Z 키가 눌리면 undo 기능 수행
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // undo 스택에 두 개 이상의 위치가 있을 경우
            if (undoStack.Count > 1)
            {
                // 현재 위치를 redo 스택에 저장
                redoStack.Push(undoStack.Pop());
                // 이전 위치로 이동
                targetObject.transform.position = undoStack.Peek();
            }
        }

        // Y 키가 눌리면 redo 기능 수행
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // redo 스택에 위치가 있을 경우
            if (redoStack.Count > 0)
            {
                // redo 스택의 위치로 이동
                targetObject.transform.position = redoStack.Peek();
                // redo 스택에서 위치를 꺼내서 positionStack에 저장
                undoStack.Push(redoStack.Pop());
            }
        }
    }
}
