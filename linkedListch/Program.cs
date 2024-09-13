using System.Collections;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks.Dataflow;
using System.Transactions;

namespace linkedLists {
    public class Program{
        static void Main(string[] args){

        }
    }

    public class Node{
        public int Value {get; set;}
        public Node? Prev {get; set;}
        public Node? Next {get; set;}

        public Node(int value){
            Value = value;
            Prev = null;
            Next = null;
        }

    }

    public enum SortDirection{
        Ascending,
        Descending
    }

    public class DoubleList {
        private Node? _last;
        private Node? _first;
        private Node? _center;
        private int _count;

        public DoubleList(){
            _last = null;
            _first = null;
            _center = null;
            _count = 0;
        }

        public int Count{
            get {return _count;}
        }

        public void InsertInOrder(int value){

            Node newNode = new Node(value);

            if (_first == null){
                _first = newNode;
                _last = newNode;
                _center = newNode;
                _count = 1;
            }
            else{
                _last!.Next = newNode;
                newNode.Prev = _last;
                _last = newNode;
                _count++;

                if (_count % 2 == 0){
                    _center = _center!.Next;
                }
            }
        }

        public int? DeleteFirst(){
            if (_first == null) return null;

            Node temp = _first;
            _first = _first.Next;

            if (_first == null) _last = null;
            else _first.Prev = null;

            _count--;

            if (_count % 2 == 0){
                _center = _center!.Next;
            }

            return temp.Value;
        }

        public int? DeleteLast(){
            if (_last == null) return null;

            Node temp = _last;
            _last = _last.Prev;

            if (_last == null) _first = null;
            else _last.Next = null;

            _count--;

            if (_count % 2 != 0){
                _center = _center!.Prev;
            }

            return temp.Value;
        }

        public bool DeleteValue(int value){
            Node? current = _first;
            Node? previous = null;

            while (current != null){

                if (current.Value == value){
                    //node found
                    if (previous == null){
                        //node is the first node
                        _first = current.Next;
                        if (_first == null) _last = null;
                        else _first.Prev = null;
                    }
                    else if (current.Next == null){
                        //node is the last node
                        _last = previous;
                        _last.Next = null;
                    }
                    else {
                        //node is somewhere in the middle
                        previous.Next = current.Next;
                        current.Next.Prev = previous;
                    }

                    _count--;

                    if (_count % 2 == 0){
                        if (current == _center){
                            _center = _center!.Next;
                        }
                        else if (current.Next == _center){
                            _center = _center!.Prev;
                        }
                    }
                    else {
                        if (current == _center){
                            _center = _center!.Prev;
                        }
                        else if (current.Next == _center){
                            _center = _center!.Next;
                        }
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public int? GetMiddle(){
            if (_center == null) throw new System.ArgumentNullException();
            return _center.Value;
        }

        public void InsertInOrderList(int[] values){
            if (values == null) return;

            foreach (int value in values){
                InsertInOrder(value);
            }
        }
        

        //merge listA into listB
        public static void MergeSorted(DoubleList listA, DoubleList listB, SortDirection direction)
        {
            if (listA == null || listB == null)
            {
                throw new System.ArgumentNullException();
            }
        
            Node? currentA = listA._first;
            Node? currentB = listB._first;
        
            while (currentA != null)
            {
                Node nextA = currentA.Next;
        
                while (currentB != null && currentB.Value < currentA.Value)
                {
                    currentB = currentB.Next;
                }
        
                if (currentB == null)
                {
                    if (listB._last != null)
                    {
                        listB._last.Next = currentA;
                        currentA.Prev = listB._last;
                    }
                    else
                    {
                        listB._first = currentA;
                    }
                    listB._last = currentA;
                    currentA.Next = null;
                }
                else
                {
                    Node prevB = currentB.Prev;
                    if (prevB != null)
                    {
                        prevB.Next = currentA;
                        currentA.Prev = prevB;
                    }
                    else
                    {
                        listB._first = currentA;
                    }
                    currentA.Next = currentB;
                    currentB.Prev = currentA;
                }
        
                listB._count++;
                if (listB._count % 2 == 0)
                {
                    listB._center = listB._center?.Next ?? listB._first;
                }
        
                currentA = nextA;
            }
        
            listA._first = null;
            listA._last = null;
            listA._center = null;
            listA._count = 0;
        
            if (direction == SortDirection.Descending)
            {
                Invert(listB);
            }
        }


        public static void Invert(DoubleList list){
            if (list == null){
                throw new System.ArgumentNullException();
            }

            Node? current = list._first;
            Node? temp = null;

            while (current != null){
                temp = current.Prev;
                current.Prev = current.Next;
                current.Next = temp;
                current = current.Prev;
            }

            if (temp != null){
                list._first = temp.Prev;
            }
        }
            
    }
}