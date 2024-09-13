namespace LinkedListTests;

[TestClass]
public class DoubleListTests
{
    [TestMethod] //MergeSorted
    public void TestMergeSortedNull()
    {
        //test null list returns exception
        DoubleList list = new DoubleList();
        Assert.ThrowsException<ArgumentNullException>(() => DoubleList.MergeSorted(list, null, SortDirection.Ascending));
        Assert.ThrowsException<ArgumentNullException>(() => DoubleList.MergeSorted(null, list, SortDirection.Ascending));
    }

    public void TestMergeSorteAscending()
    {
        //test lisaA = [0,2,6,10,25], listB = [3,7,11,40,50], ascending
        DoubleList listA = new DoubleList();
        listA.InsertInOrderList(new int[]{0,2,6,10,25});
        DoubleList listB = new DoubleList();
        listB.InsertInOrderList(new int[]{3,7,11,40,50});
        DoubleList.MergeSorted(listA, listB, SortDirection.Ascending);

        Assert.AreEqual(0, listB.DeleteFirst());
        Assert.AreEqual(2, listB.DeleteFirst());
        Assert.AreEqual(3, listB.DeleteFirst());
        Assert.AreEqual(6, listB.DeleteFirst());
        Assert.AreEqual(7, listB.DeleteFirst());
        Assert.AreEqual(10, listB.DeleteFirst());
        Assert.AreEqual(11, listB.DeleteFirst());
        Assert.AreEqual(25, listB.DeleteFirst());
        Assert.AreEqual(40, listB.DeleteFirst());
        Assert.AreEqual(50, listB.DeleteFirst());
    }

    public void TestMergeSorteDescending()
    {
        //test listA = [10,15], listB = [9,40,50], descending
        DoubleList listA = new DoubleList();
        listA.InsertInOrderList(new int[]{10,15});
        DoubleList listB = new DoubleList();
        listB.InsertInOrderList(new int[]{9,40,50});
        DoubleList.MergeSorted(listA, listB, SortDirection.Descending);

        Assert.AreEqual(50, listB.DeleteFirst());
        Assert.AreEqual(40, listB.DeleteFirst());
        Assert.AreEqual(15, listB.DeleteFirst());
        Assert.AreEqual(10, listB.DeleteFirst());
        Assert.AreEqual(9, listB.DeleteFirst());
    }

    public void TestMergeSorteInvert()
    {
        //test listA empty list, listB = [9,40,50], descending
        DoubleList listA = new DoubleList();
        DoubleList listB = new DoubleList();
        listB.InsertInOrderList(new int[]{9,40,50});
        DoubleList.MergeSorted(listA, listB, SortDirection.Descending);

        Assert.AreEqual(50, listB.DeleteFirst());
        Assert.AreEqual(40, listB.DeleteFirst());
        Assert.AreEqual(9, listB.DeleteFirst());
    }

    public void TestMergeSorteCopy()
        {
            //test listA = [10,15], listB empty list, ascending
            DoubleList listA = new DoubleList();
            listA.InsertInOrderList(new int[]{10,15});
            DoubleList listB = new DoubleList();
            DoubleList.MergeSorted(listA, listB, SortDirection.Ascending);

            Assert.AreEqual(10, listB.DeleteFirst());
            Assert.AreEqual(15, listB.DeleteFirst());
        }
    [TestMethod] //Invert
    public void TestInvertNull()
    {
        //test null list returns exception
        DoubleList list = new DoubleList();
        Assert.ThrowsException<ArgumentNullException>(() => DoubleList.Invert(null));
    }

    public void TestInvertEmpty()
    {
        //test empty list
        DoubleList list = new DoubleList();
        DoubleList.Invert(list);
        Assert.AreEqual(0, list.Count);
    }

    public void TestInvert()
    {
        //test list = [1,0,30,50,2]
        DoubleList list = new DoubleList();
        list.InsertInOrderList(new int[]{1,0,30,50,2});
        DoubleList.Invert(list);

        Assert.AreEqual(2, list.DeleteFirst());
        Assert.AreEqual(50, list.DeleteFirst());
        Assert.AreEqual(30, list.DeleteFirst());
        Assert.AreEqual(0, list.DeleteFirst());
        Assert.AreEqual(1, list.DeleteFirst());

    }

    public void TestInvertSingle()
    {
        //test list = [2]
        DoubleList list = new DoubleList();
        list.InsertInOrderList(new int[]{2});
        DoubleList.Invert(list);

        Assert.AreEqual(2, list.DeleteFirst());
    }

    [TestMethod] //GetMiddle

    public void TestGetMiddleEmpty() //Same as TestGetMiddleNull
    {
        //test empty list
        DoubleList list = new DoubleList();
        Assert.ThrowsException<ArgumentNullException>(() => list.GetMiddle());
    }

    public void TestGetMiddleSingle()
    {
        //test list = [1]
        DoubleList list = new DoubleList();
        list.InsertInOrderList(new int[]{1});
        Assert.AreEqual(1, list.GetMiddle());
    }

    public void TestGetMiddlePair()
    {
        //test list = [1,2]
        DoubleList list = new DoubleList();
        list.InsertInOrderList(new int[]{1,2});
        Assert.AreEqual(1, list.GetMiddle());
    }

    public void TestGetMiddle()
    {
        //test list = [1,2,3,4,5]
        DoubleList list = new DoubleList();
        list.InsertInOrderList(new int[]{1,2,3,4,5});
        Assert.AreEqual(3, list.GetMiddle());
    }

}