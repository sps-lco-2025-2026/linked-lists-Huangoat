namespace LinkedListIntroduction.Lib;

public class IntegerLinkedList
{
    IntegerNode _head;

    public IntegerLinkedList()
    {
        _head = null;
    }

    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }

    public int Count => _head == null ? 0 : _head.Count;
    public int Sum => _head == null ? 0 : _head.Sum;

    public void Append(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Append(v);
    }

    public void Prepend(int v)
    {
        IntegerNode n = new IntegerNode(v);
        n.SetNext(_head);
        _head = n;
    }

    public bool Delete(int v)
    {
        if (_head == null) return false;
        if (_head.Value == v)
        {
            _head = _head.Next;
            return true;
        }
        return _head.Delete(v);
    }

    public void Insert(int v, int index)
    {
        if (index <= 0 || _head == null)
        {
            Prepend(v);
            return;
        }
        _head.Insert(v, index, 1);
    }

    public void Join(IntegerLinkedList other)
    {
        if (other._head == null) return;
        if (_head == null)
            _head = other._head;
        else
            _head.Join(other._head);
    }

    public bool Contains(int v)
    {
        if (_head == null) return false;
        return _head.Contains(v);
    }

    public void RemoveDuplicates()
    {
        IntegerNode cur = _head;
        while (cur != null)
        {
            IntegerNode runner = cur;
            while (runner.Next != null)
            {
                if (runner.Next.Value == cur.Value)
                    runner.SetNext(runner.Next.Next);
                else
                    runner = runner.Next;
            }
            cur = cur.Next;
        }
    }

    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }
}

public class IntegerNode
{
    int _value;
    IntegerNode _next;

    internal int Value => _value;
    internal IntegerNode Next => _next;

    internal int Count => _next == null ? 1 : 1 + _next.Count;
    internal int Sum => _next == null ? _value : _value + _next.Sum;

    internal IntegerNode(int v)
    {
        _value = v;
        _next = null;
    }

    internal void SetNext(IntegerNode n)
    {
        _next = n;
    }

    internal void Append(int v)
    {
        if (_next == null)
            _next = new IntegerNode(v);
        else
            _next.Append(v);
    }

    internal bool Delete(int v)
    {
        if (_next == null) return false;
        if (_next._value == v)
        {
            _next = _next._next;
            return true;
        }
        return _next.Delete(v);
    }

    internal void Insert(int v, int index, int pos)
    {
        if (pos == index || _next == null)
        {
            IntegerNode n = new IntegerNode(v);
            n._next = _next;
            _next = n;
        }
        else
            _next.Insert(v, index, pos + 1);
    }

    internal void Join(IntegerNode other)
    {
        if (_next == null)
            _next = other;
        else
            _next.Join(other);
    }

    internal bool Contains(int v)
    {
        if (_value == v) return true;
        if (_next == null) return false;
        return _next.Contains(v);
    }

    public override string ToString()
    {
        return _next == null ? _value.ToString() : $"{_value}, {_next}";
    }
}