namespace KReverseSingleLinkedList_5cf92c3092613c00130b987e;

public class Kata
{
    public static LinkedListNode<T> KReverse<T>(LinkedListNode<T> n, int k)
    {
        LinkedListNode<T> resultStart = null;
        LinkedListNode<T> resultEnd = null;

        while (n != null)
        {
            var blockEnd = n;
            var blockStart = n;
            n = n.Next;

            for (var i = 1; i < k && n != null; i++)
            {
                var oldNext = n.Next;
                n.Next = blockStart;
                blockStart = n;
                n = oldNext;
            }

            if (resultEnd != null)
            {
                resultEnd.Next = blockStart;
            }
            
            if (resultStart == null)
            {
                resultStart = blockStart;
            }

            resultEnd = blockEnd;
            resultEnd.Next = null;
        }

        return resultStart;
    }
}
