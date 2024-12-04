using UnityEngine;

public class ListExample : MonoBehaviour
{
    private void Start()
    {
        //// c#에서 제공하는 링크드 리스트를 체험해 보기 위해 선언과 할당을 함
        //LinkedList<int> list = new();

        //// AddLast는 list의 tail(꼬리) 뒤에다가 1을 추가한다.
        //list.AddLast(1);
        //list.AddLast(2);
        //list.AddLast(3);
        //list.AddLast(4);

        //// AddFirst는 list의 head(머리) 앞에다가 2를 추가한다.
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
    // 노드상의 제일 앞부분을 Head라고 선언
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

    // 요소를 뒤에 추가
    public void AddLast(T data)
    {
        // 새로운 노드를 생성
        Node<T> newNode = new(data);
        if (Head == null)
            Head = newNode;
        else
        {
            Node<T> current = Head;

            // current를 계속 최신화
            while (current.Next != null)
                current = current.Next;

            // 맨 마지막의 노드의 next에 새로운 노드를 연결
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

    public void AddFirst(T data) // 제네릭 타입 T를 사용하는 AddFirst 메서드 정의, data를 매개변수로 받음
    {
        DNode<T> node = new(data); // 새로운 DNode<T> 객체를 생성하고, data를 초기값으로 설정

        if (Head == null) // 리스트가 비어 있는 경우 (Head가 null인 경우)
        {
            Head = node; // Head를 새로 생성한 노드로 설정
            Tail = node; // Tail도 새로 생성한 노드로 설정 (리스트에 노드가 하나뿐이므로)
        }
        else // 리스트에 이미 노드가 있는 경우
        {
            node.Next = Head; // 새 노드의 Next를 현재 Head로 설정 (새 노드가 Head가 됨)
            Head.Prev = node; // 현재 Head의 Prev를 새 노드로 설정 (이중 연결 리스트의 특성)
            Head = node; // Head를 새 노드로 업데이트 (새 노드가 리스트의 첫 번째 노드가 됨)
        }
    }

    public void AddLast(T data) // 주어진 데이터를 사용하여 리스트의 끝에 노드를 추가하는 AddLast 메서드 정의
    {
        DNode<T> node = new(data); // 새로운 노드를 생성하고 주어진 데이터를 할당

        if (Head == null) // 리스트가 비어 있는 경우 (Head가 null인 경우)
        {
            Head = node; // Head를 새로 생성한 노드로 설정
            Tail = node; // Tail도 새로 생성한 노드로 설정
        }
        else // 리스트에 노드가 이미 있는 경우
        {
            node.Prev = Tail; // 새 노드의 Prev를 현재 Tail로 설정
            Tail.Next = node; // 현재 Tail의 Next를 새 노드로 설정
            Tail = node; // Tail을 새 노드로 업데이트
        }
    }

    public void Insert(int index, T data) // 주어진 인덱스에 데이터를 삽입하는 Insert 메서드 정의
    {
        if (index < 0) return; // 인덱스가 음수인 경우, 아무 작업도 수행하지 않고 반환

        DNode<T> newNode = new(data); // 새로운 노드를 생성하고 주어진 데이터를 할당

        if (index == 0) // 인덱스가 0인 경우 (리스트의 맨 앞에 삽입)
        {
            AddFirst(data); // AddFirst 메서드를 호출하여 데이터를 리스트의 맨 앞에 추가
            return; // 메서드 종료
        }

        DNode<T> current = Head; // 현재 노드를 Head로 초기화
        int currentIndex = 0; // 현재 인덱스를 0으로 초기화

        // 인덱스에 도달할 때까지 현재 노드를 다음 노드로 이동
        while (current != null && currentIndex < index - 1)
        {
            current = current.Next; // 현재 노드를 다음 노드로 이동
            currentIndex++; // 현재 인덱스 증가
        }

        if (current == null) // 현재 노드가 null인 경우 (인덱스가 리스트의 길이보다 큰 경우)
            AddLast(data); // AddLast 메서드를 호출하여 데이터를 리스트의 맨 뒤에 추가
        else // 현재 노드가 null이 아닌 경우 (유효한 인덱스)
        {
            newNode.Next = current.Next; // 새 노드의 Next를 현재 노드의 Next로 설정
            newNode.Prev = current; // 새 노드의 Prev를 현재 노드로 설정

            if (current.Next != null) // 현재 노드의 Next가 null이 아닌 경우
                current.Next.Prev = newNode; // 현재 노드의 Next 노드의 Prev를 새 노드로 설정

            current.Next = newNode; // 현재 노드의 Next를 새 노드로 설정
        }
    }

    public void RemoveAt(int index) // 주어진 인덱스에서 노드를 제거하는 RemoveAt 메서드 정의
    {
        if (index < 0) // 인덱스가 0보다 작은 경우
        {
            Debug.LogWarning("인덱스는 0 이상이여야 합니다."); // 경고 메시지 출력
            return; // 메서드 종료
        }

        DNode<T> current = Head; // 현재 노드를 Head로 초기화

        for (int i = 0; i < index; i++) // 주어진 인덱스까지 반복
        {
            if (current == null) // 현재 노드가 null인 경우 (인덱스가 범위를 초과한 경우)
            {
                Debug.LogWarning("인덱스가 범위를 초과했습니다."); // 경고 메시지 출력
                return; // 메서드 종료
            }

            current = current.Next; // 현재 노드를 다음 노드로 이동
        }

        if (current != null) // 현재 노드가 null이 아닌 경우 (유효한 인덱스)
        {
            if (current.Prev != null) // 현재 노드의 이전 노드가 있는 경우
                current.Prev.Next = current.Next; // 이전 노드의 Next를 현재 노드의 다음 노드로 설정
            else
                Head = current.Next; // 현재 노드가 Head인 경우, Head를 다음 노드로 업데이트

            if (current.Next != null) // 현재 노드의 다음 노드가 있는 경우
                current.Next.Prev = current.Prev; // 다음 노드의 Prev를 현재 노드의 이전 노드로 설정
            else
                Tail = current.Prev; // 현재 노드가 Tail인 경우, Tail을 이전 노드로 업데이트
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
        // 새 노드를 생성
        DNode<T> node = new(data);

        // 리스트가 비어있다면 Head와 Tail을 새 노드로 설정
        if (Head == null)
            Head = Tail = node;
        else
        {
            // 새 노드의 Next를 현재 Head로 설정
            node.Next = Head;
            // 현재 Head의 Prev를 새 노드로 설정
            Head.Prev = node;
            // Head를 새 노드로 업데이트
            Head = node;
        }
    }

    public void AddLast(T data)
    {
        // 새 노드를 생성
        DNode<T> node = new(data);

        // 리스트가 비어있다면 Head와 Tail을 새 노드로 설정
        if (Tail == null)
            Head = Tail = node;
        else
        {
            // 새 노드의 Prev를 현재 Tail로 설정
            node.Prev = Tail;
            // 현재 Tail의 Next를 새 노드로 설정
            Tail.Next = node;
            // Tail을 새 노드로 업데이트
            Tail = node;
        }
    }

    public void Insert(int index, T data)
    {
        // 유효하지 않은 인덱스 체크
        if (index < 0) return;

        // 인덱스가 0일 경우 첫 번째에 추가
        if (index == 0)
        {
            AddFirst(data);
            return;
        }

        // 현재 노드를 Head로 초기화
        DNode<T> current = Head;

        // 인덱스에 해당하는 노드를 찾기 위해 리스트를 순회
        for (int currentIndex = 0; currentIndex < index && current != null; currentIndex++)
            current = current.Next;

        // 현재 노드가 null인 경우, 인덱스가 리스트의 길이보다 큰 경우 마지막에 추가
        if (current == null)
        {
            AddLast(data);
            return;
        }

        // 새 노드를 생성하고 현재 노드의 이전 노드와 연결
        DNode<T> newNode = new(data)
        {
            Next = current, // 새 노드의 Next를 현재 노드로 설정
            Prev = current.Prev // 새 노드의 Prev를 현재 노드의 이전 노드로 설정
        };

        // 현재 노드의 이전 노드가 null이 아닌 경우
        if (current.Prev != null)
            current.Prev.Next = newNode; // 이전 노드의 Next를 새 노드로 설정
        else
            Head = newNode; // 새 노드가 Head가 되는 경우

        // 현재 노드의 Prev를 새 노드로 설정
        current.Prev = newNode;
    }

    public void RemoveAt(int index)
    {
        // 유효하지 않은 인덱스 체크
        if (index < 0) return;

        // 현재 노드를 Head로 초기화
        DNode<T> current = Head;
        // 인덱스에 해당하는 노드를 찾기 위해 리스트를 순회
        for (int i = 0; i < index && current != null; i++)
            current = current.Next;

        // 현재 노드가 null인 경우, 인덱스가 리스트의 길이보다 큰 경우 아무것도 하지 않음
        if (current == null) return;

        // 현재 노드의 이전 노드가 null이 아닌 경우
        if (current.Prev != null)
            current.Prev.Next = current.Next; // 이전 노드의 Next를 현재 노드의 다음 노드로 설정
        else
            Head = current.Next; // 현재 노드가 Head인 경우 Head를 업데이트

        // 현재 노드의 다음 노드가 null이 아닌 경우
        if (current.Next != null)
            current.Next.Prev = current.Prev; // 다음 노드의 Prev를 현재 노드의 이전 노드로 설정
        else
            Tail = current.Prev; // 현재 노드가 Tail인 경우 Tail을 업데이트
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
