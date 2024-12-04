using System;
using System.Collections.Generic;
using UnityEngine;

public class StackExample : MonoBehaviour
{
    //private void Start()
    //{
    //    StackCustom<int> stack = new();
    //    stack.Push(1);
    //    stack.Push(2);
    //    stack.Push(3);

    //    stack.Pop();

    //    Debug.Log(stack.Pop());
    //    Debug.Log(stack.Peek());
    //}

    [NonSerialized] public float speed = 3.0f;
    [SerializeField] private float speed2 = 3.0f;

    private Stack<Vector3> position_stack = new();

    private void Update()
    {
        Vector3 movePos = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            movePos += transform.forward;

        if (Input.GetKey(KeyCode.S))
            movePos -= transform.forward;

        if (Input.GetKey(KeyCode.A))
            movePos -= transform.right;

        if (Input.GetKey(KeyCode.D))
            movePos += transform.right;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            movePos = Vector3.zero;
            position_stack.Push(transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (position_stack.Count > 0)
                transform.position = position_stack.Pop();
        }

        transform.position += speed2 * Time.deltaTime * movePos.normalized;
    }
}

public class StackNode<T>
{
    public T data;
    public StackNode<T> prev;
}

public class StackCustom<T> where T : new()
{
    public StackNode<T> top;

    public void Push(T data)
    {
        var stackNode = new StackNode<T>
        {
            data = data,
            prev = top
        };
        top = stackNode;
    }

    public T Pop()
    {
        if (top == null) return new T();

        var result = top.data;
        top = top.prev;

        return result;
    }

    public T Peek()
    {
        if (top == null) return new T();

        return top.data;
    }
}