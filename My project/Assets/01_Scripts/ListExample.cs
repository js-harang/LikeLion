using UnityEngine;

public class ListExample : MonoBehaviour
{
    private void Start()
    {
        //// c#���� �����ϴ� ��ũ�� ����Ʈ�� ü���� ���� ���� ����� �Ҵ��� ��
        //LinkedList<int> list = new();

        //// AddLast�� list�� tail(����) �ڿ��ٰ� 1�� �߰��Ѵ�.
        //list.AddLast(1);
        //list.AddLast(2);
        //list.AddLast(3);
        //list.AddLast(4);

        //// AddFirst�� list�� head(�Ӹ�) �տ��ٰ� 2�� �߰��Ѵ�.
        //list.AddFirst(0);



        //var enumerator = list.GetEnumerator();

        //int findIndex = 3;
        //int currentIndex = 0;

        //while (enumerator.MoveNext())
        //{
        //    if (currentIndex == findIndex)
        //    {
        //        Debug.Log(enumerator.Current);

        //        break;
        //    }

        //    currentIndex++;
        //}

        //LinkedListCustom<int> list = new();
        //list.AddLast(1);
        //list.AddLast(2);
        //list.AddLast(3);
        //list.AddLast(4);
        //list.AddFirst(0);

        //list.Traverse();

        DLinkedListCustom2<int> Dlist = new();
        Dlist.AddLast(1);
        Dlist.AddLast(2);
        Dlist.AddLast(3);
        Dlist.AddLast(4);
        Dlist.AddFirst(0);

        Dlist.Insert(-1, 5);

        Dlist.Traverse();
        //Dlist.RTraverse();
    }
}

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }
    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedListCustom<T>
{
    // ������ ���� �պκ��� Head��� ����
    public Node<T> Head { get; private set; }

    public void AddFirst(T data)
    {
        Node<T> newNode = new(data);

        if (Head == null)
            Head = newNode;
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }
    }

    // ��Ҹ� �ڿ� �߰�
    public void AddLast(T data)
    {
        // ���ο� ��带 ����
        Node<T> newNode = new(data);
        if (Head == null)
            Head = newNode;
        else
        {
            Node<T> current = Head;

            // current�� ��� �ֽ�ȭ
            while (current.Next != null)
                current = current.Next;

            // �� �������� ����� next�� ���ο� ��带 ����
            current.Next = newNode;
        }
    }

    public void Traverse()
    {
        Node<T> current = Head;

        while (current != null)
        {
            Debug.Log(current.Data);
            current = current.Next;
        }
    }
}

public class DNode<T>
{
    public T Data { get; set; }
    public DNode<T> Next { get; set; }
    public DNode<T> Prev { get; set; }

    public DNode(T data)
    {
        Data = data;
    }
}

public class DLinkedListCustom<T>
{
    public DNode<T> Head { get; private set; }
    public DNode<T> Tail { get; private set; }

    public void AddFirst(T data) // ���׸� Ÿ�� T�� ����ϴ� AddFirst �޼��� ����, data�� �Ű������� ����
    {
        DNode<T> node = new(data); // ���ο� DNode<T> ��ü�� �����ϰ�, data�� �ʱⰪ���� ����

        if (Head == null) // ����Ʈ�� ��� �ִ� ��� (Head�� null�� ���)
        {
            Head = node; // Head�� ���� ������ ���� ����
            Tail = node; // Tail�� ���� ������ ���� ���� (����Ʈ�� ��尡 �ϳ����̹Ƿ�)
        }
        else // ����Ʈ�� �̹� ��尡 �ִ� ���
        {
            node.Next = Head; // �� ����� Next�� ���� Head�� ���� (�� ��尡 Head�� ��)
            Head.Prev = node; // ���� Head�� Prev�� �� ���� ���� (���� ���� ����Ʈ�� Ư��)
            Head = node; // Head�� �� ���� ������Ʈ (�� ��尡 ����Ʈ�� ù ��° ��尡 ��)
        }
    }

    public void AddLast(T data) // �־��� �����͸� ����Ͽ� ����Ʈ�� ���� ��带 �߰��ϴ� AddLast �޼��� ����
    {
        DNode<T> node = new(data); // ���ο� ��带 �����ϰ� �־��� �����͸� �Ҵ�

        if (Head == null) // ����Ʈ�� ��� �ִ� ��� (Head�� null�� ���)
        {
            Head = node; // Head�� ���� ������ ���� ����
            Tail = node; // Tail�� ���� ������ ���� ����
        }
        else // ����Ʈ�� ��尡 �̹� �ִ� ���
        {
            node.Prev = Tail; // �� ����� Prev�� ���� Tail�� ����
            Tail.Next = node; // ���� Tail�� Next�� �� ���� ����
            Tail = node; // Tail�� �� ���� ������Ʈ
        }
    }

    public void Insert(int index, T data) // �־��� �ε����� �����͸� �����ϴ� Insert �޼��� ����
    {
        if (index < 0) return; // �ε����� ������ ���, �ƹ� �۾��� �������� �ʰ� ��ȯ

        DNode<T> newNode = new(data); // ���ο� ��带 �����ϰ� �־��� �����͸� �Ҵ�

        if (index == 0) // �ε����� 0�� ��� (����Ʈ�� �� �տ� ����)
        {
            AddFirst(data); // AddFirst �޼��带 ȣ���Ͽ� �����͸� ����Ʈ�� �� �տ� �߰�
            return; // �޼��� ����
        }

        DNode<T> current = Head; // ���� ��带 Head�� �ʱ�ȭ
        int currentIndex = 0; // ���� �ε����� 0���� �ʱ�ȭ

        // �ε����� ������ ������ ���� ��带 ���� ���� �̵�
        while (current != null && currentIndex < index - 1)
        {
            current = current.Next; // ���� ��带 ���� ���� �̵�
            currentIndex++; // ���� �ε��� ����
        }

        if (current == null) // ���� ��尡 null�� ��� (�ε����� ����Ʈ�� ���̺��� ū ���)
            AddLast(data); // AddLast �޼��带 ȣ���Ͽ� �����͸� ����Ʈ�� �� �ڿ� �߰�
        else // ���� ��尡 null�� �ƴ� ��� (��ȿ�� �ε���)
        {
            newNode.Next = current.Next; // �� ����� Next�� ���� ����� Next�� ����
            newNode.Prev = current; // �� ����� Prev�� ���� ���� ����

            if (current.Next != null) // ���� ����� Next�� null�� �ƴ� ���
                current.Next.Prev = newNode; // ���� ����� Next ����� Prev�� �� ���� ����

            current.Next = newNode; // ���� ����� Next�� �� ���� ����
        }
    }

    public void RemoveAt(int index) // �־��� �ε������� ��带 �����ϴ� RemoveAt �޼��� ����
    {
        if (index < 0) // �ε����� 0���� ���� ���
        {
            Debug.LogWarning("�ε����� 0 �̻��̿��� �մϴ�."); // ��� �޽��� ���
            return; // �޼��� ����
        }

        DNode<T> current = Head; // ���� ��带 Head�� �ʱ�ȭ

        for (int i = 0; i < index; i++) // �־��� �ε������� �ݺ�
        {
            if (current == null) // ���� ��尡 null�� ��� (�ε����� ������ �ʰ��� ���)
            {
                Debug.LogWarning("�ε����� ������ �ʰ��߽��ϴ�."); // ��� �޽��� ���
                return; // �޼��� ����
            }

            current = current.Next; // ���� ��带 ���� ���� �̵�
        }

        if (current != null) // ���� ��尡 null�� �ƴ� ��� (��ȿ�� �ε���)
        {
            if (current.Prev != null) // ���� ����� ���� ��尡 �ִ� ���
                current.Prev.Next = current.Next; // ���� ����� Next�� ���� ����� ���� ���� ����
            else
                Head = current.Next; // ���� ��尡 Head�� ���, Head�� ���� ���� ������Ʈ

            if (current.Next != null) // ���� ����� ���� ��尡 �ִ� ���
                current.Next.Prev = current.Prev; // ���� ����� Prev�� ���� ����� ���� ���� ����
            else
                Tail = current.Prev; // ���� ��尡 Tail�� ���, Tail�� ���� ���� ������Ʈ
        }
    }

    public void Traverse()
    {
        DNode<T> current = Head;
        while (current != null)
        {
            Debug.Log(current.Data);
            current = current.Next;
        }
    }

    public void RTraverse()
    {
        DNode<T> current = Tail;
        while (current != null)
        {
            Debug.Log(current.Data);
            current = current.Prev;
        }
    }
}

public class DLinkedListCustom2<T>
{
    public DNode<T> Head { get; private set; }
    public DNode<T> Tail { get; private set; }

    public void AddFirst(T data)
    {
        // �� ��带 ����
        DNode<T> node = new(data);

        // ����Ʈ�� ����ִٸ� Head�� Tail�� �� ���� ����
        if (Head == null)
            Head = Tail = node;
        else
        {
            // �� ����� Next�� ���� Head�� ����
            node.Next = Head;
            // ���� Head�� Prev�� �� ���� ����
            Head.Prev = node;
            // Head�� �� ���� ������Ʈ
            Head = node;
        }
    }

    public void AddLast(T data)
    {
        // �� ��带 ����
        DNode<T> node = new(data);

        // ����Ʈ�� ����ִٸ� Head�� Tail�� �� ���� ����
        if (Tail == null)
            Head = Tail = node;
        else
        {
            // �� ����� Prev�� ���� Tail�� ����
            node.Prev = Tail;
            // ���� Tail�� Next�� �� ���� ����
            Tail.Next = node;
            // Tail�� �� ���� ������Ʈ
            Tail = node;
        }
    }

    public void Insert(int index, T data)
    {
        // ��ȿ���� ���� �ε��� üũ
        if (index < 0) return;

        // �ε����� 0�� ��� ù ��°�� �߰�
        if (index == 0)
        {
            AddFirst(data);
            return;
        }

        // ���� ��带 Head�� �ʱ�ȭ
        DNode<T> current = Head;

        // �ε����� �ش��ϴ� ��带 ã�� ���� ����Ʈ�� ��ȸ
        for (int currentIndex = 0; currentIndex < index && current != null; currentIndex++)
            current = current.Next;

        // ���� ��尡 null�� ���, �ε����� ����Ʈ�� ���̺��� ū ��� �������� �߰�
        if (current == null)
        {
            AddLast(data);
            return;
        }

        // �� ��带 �����ϰ� ���� ����� ���� ���� ����
        DNode<T> newNode = new(data)
        {
            Next = current, // �� ����� Next�� ���� ���� ����
            Prev = current.Prev // �� ����� Prev�� ���� ����� ���� ���� ����
        };

        // ���� ����� ���� ��尡 null�� �ƴ� ���
        if (current.Prev != null)
            current.Prev.Next = newNode; // ���� ����� Next�� �� ���� ����
        else
            Head = newNode; // �� ��尡 Head�� �Ǵ� ���

        // ���� ����� Prev�� �� ���� ����
        current.Prev = newNode;
    }

    public void RemoveAt(int index)
    {
        // ��ȿ���� ���� �ε��� üũ
        if (index < 0) return;

        // ���� ��带 Head�� �ʱ�ȭ
        DNode<T> current = Head;
        // �ε����� �ش��ϴ� ��带 ã�� ���� ����Ʈ�� ��ȸ
        for (int i = 0; i < index && current != null; i++)
            current = current.Next;

        // ���� ��尡 null�� ���, �ε����� ����Ʈ�� ���̺��� ū ��� �ƹ��͵� ���� ����
        if (current == null) return;

        // ���� ����� ���� ��尡 null�� �ƴ� ���
        if (current.Prev != null)
            current.Prev.Next = current.Next; // ���� ����� Next�� ���� ����� ���� ���� ����
        else
            Head = current.Next; // ���� ��尡 Head�� ��� Head�� ������Ʈ

        // ���� ����� ���� ��尡 null�� �ƴ� ���
        if (current.Next != null)
            current.Next.Prev = current.Prev; // ���� ����� Prev�� ���� ����� ���� ���� ����
        else
            Tail = current.Prev; // ���� ��尡 Tail�� ��� Tail�� ������Ʈ
    }

    public void Traverse()
    {
        for (DNode<T> current = Head; current != null; current = current.Next)
            Debug.Log(current.Data);
    }

    public void RTraverse()
    {
        for (DNode<T> current = Tail; current != null; current = current.Prev)
            Debug.Log(current.Data);
    }
}
