using System;

namespace LeetCode.IntPriorityQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pqd = new PriorityQueue(Comparer<int>.);
            var pq = new PriorityQueue(new IntComparerDesc());
            pq.Enqueue(15);
            pq.Enqueue(12);
            pq.Enqueue(50);
            pq.Enqueue(7);
            pq.Enqueue(40);
            pq.Enqueue(22);

            while (pq.Any())
            {
                Console.WriteLine(pq.Dequeue());
            }
        }
    }
}

public class IntComparerAsc : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return x.CompareTo(y);
    }
}

public class IntComparerDesc : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y.CompareTo(x);
    }
}

public class PriorityQueue
{
    private readonly List<int> _heap = new List<int>();
    private readonly IComparer<int> _comparer;

    public PriorityQueue(IComparer<int> comparer)
    {
        _comparer = comparer;
    }

    public int Count => _heap.Count;

    public bool Any()
    {
        return _heap.Any();
    }

    public int Peek()
    {
        return _heap[0];
    }

    public void Enqueue(int element)
    {
        _heap.Add(element);
        SiftUp();
    }

    public int Dequeue()
    {
        var result = _heap[0];
        _heap.RemoveAt(0);
        SiftDown();
        return result;
    }

    private void SiftUp()
    {
        var nodeIdx = _heap.Count - 1;

        while (nodeIdx > 0 && Compare(nodeIdx, Parent(nodeIdx)))
        {
            Swap(nodeIdx, Parent(nodeIdx));
            nodeIdx = Parent(nodeIdx);
        }
    }

    private void SiftDown()
    {
        var nodeIdx = 0;

        while ((LeftChild(nodeIdx) < Count && Compare(LeftChild(nodeIdx), nodeIdx)) ||
            (RightChild(nodeIdx) < Count && Compare(RightChild(nodeIdx), nodeIdx)))
        {
            var greaterChildIdx = RightChild(nodeIdx) < Count && Compare(RightChild(nodeIdx), LeftChild(nodeIdx))
                ? RightChild(nodeIdx)
                : LeftChild(nodeIdx);

            Swap(greaterChildIdx, nodeIdx);
            nodeIdx = greaterChildIdx;
        }
    }

    private static int Parent(int idx)
    {
        return (idx - 1) / 2;
    }

    private static int LeftChild(int idx)
    {
        return idx * 2 + 1;
    }

    private static int RightChild(int idx)
    {
        return idx * 2 + 2;
    }

    private bool Compare(int i, int j)
    {
        return _comparer.Compare(_heap[i], _heap[j]) > 0;
    }

    private void Swap(int i, int j)
    {
        (_heap[i], _heap[j]) = (_heap[j], _heap[i]);
    }
}

/*
class PriorityQueue {
  constructor(comparator = (a, b) => a > b) {
    this._heap = [];
    this._comparator = comparator;
  }

  size() {
    return this._heap.length;
  }

  peek() {
    return this._heap[0];
  }

  isEmpty() {
    return this._heap.length === 0;
  }

  _parent(idx) {
    return Math.floor((idx - 1) / 2);
  }

  _leftChild(idx) {
    return idx * 2 + 1;
  }

  _rightChild(idx) {
    return idx * 2 + 2;
  }

  _swap(i, j) {
    [this._heap[i], this._heap[j]] = [this._heap[j], this._heap[i]];
  }

  _compare(i, j) {
    return this._comparator(this._heap[i], this._heap[j]);
  }

  push(value) {
    this._heap.push(value);
    this._siftUp();

    return this.size();
  }

  _siftUp() {
    let nodeIdx = this.size() - 1;

    while (0 < nodeIdx && this._compare(nodeIdx, this._parent(nodeIdx))) {
      this._swap(nodeIdx, this._parent(nodeIdx));
      nodeIdx = this._parent(nodeIdx);
    }
  }

  pop() {
    if (this.size() > 1) {
      this._swap(0, this.size() - 1);
    }

    const poppedValue = this._heap.pop();
    this._siftDown();
    return poppedValue;
  }

  _siftDown() {
    let nodeIdx = 0;

    while (
      (this._leftChild(nodeIdx) < this.size() &&
        this._compare(this._leftChild(nodeIdx), nodeIdx)) ||
      (this._rightChild(nodeIdx) < this.size() &&
        this._compare(this._rightChild(nodeIdx), nodeIdx))
    ) {
      const greaterChildIdx =
        this._rightChild(nodeIdx) < this.size() &&
        this._compare(this._rightChild(nodeIdx), this._leftChild(nodeIdx))
          ? this._rightChild(nodeIdx)
          : this._leftChild(nodeIdx);

      this._swap(greaterChildIdx, nodeIdx);
      nodeIdx = greaterChildIdx;
    }
  }
}

const pq = new PriorityQueue();
pq.push(15);
pq.push(12);
pq.push(50);
pq.push(7);
pq.push(40);
pq.push(22);

while(!pq.isEmpty()) {
  console.log(pq.pop());
}
 */ 