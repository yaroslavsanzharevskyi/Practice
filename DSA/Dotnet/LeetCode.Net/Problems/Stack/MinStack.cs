using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems.Stack;

public class MinStack
{
    private List<int> _values = new List<int>();

    private List<int> _minStack = new List<int>();

    public MinStack()
    {

    }

    public void Push(int val)
    {
        _values.Add(val);
        if (_minStack.Count == 0 || val <= _minStack.Last())
        {
            _minStack.Add(val);
        }
    }

    public void Pop()
    {
        var val = _values[_values.Count - 1];
        _values.RemoveAt(_values.Count - 1);
        if (_minStack.Count > 0 && val == _minStack.Last())
        {
            _minStack.RemoveAt(_minStack.Count - 1);
        }
    }

    public int Top()
    {
        return _values.Last();
    }

    public int GetMin()
    {
        return _minStack.Last();
    }
}
