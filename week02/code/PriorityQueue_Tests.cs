using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue
    // Expected Result: Highest priority item should be dequeued first
    // Defect(s) Found: Loop condition misses last element, comparison uses >= instead of >, items not removed from queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority
    // Expected Result: First item with highest priority should be dequeued first (FIFO order)
    // Defect(s) Found: Comparison uses >= which selects last item instead of first
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 5);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("SecondHigh", 5);
        priorityQueue.Enqueue("ThirdHigh", 5);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("ThirdHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - exception handling was correct
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue items with negative priorities
    // Expected Result: Higher numbers have higher priority (negative numbers work correctly)
    // Defect(s) Found: Comparison logic should work with negative numbers
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("VeryLow", -5);
        priorityQueue.Enqueue("Low", -2);
        priorityQueue.Enqueue("Medium", 0);

        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
        Assert.AreEqual("VeryLow", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Check queue count after operations
    // Expected Result: Count should accurately reflect number of items in queue
    // Defect(s) Found: Count property was missing from original implementation
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        Assert.AreEqual(0, priorityQueue.Count);

        priorityQueue.Enqueue("Item1", 1);
        Assert.AreEqual(1, priorityQueue.Count);

        priorityQueue.Enqueue("Item2", 2);
        Assert.AreEqual(2, priorityQueue.Count);

        priorityQueue.Dequeue();
        Assert.AreEqual(1, priorityQueue.Count);

        priorityQueue.Dequeue();
        Assert.AreEqual(0, priorityQueue.Count);
    }

    [TestMethod]
    // Scenario: Mixed priorities with duplicate high priorities
    // Expected Result: Highest priority first, FIFO for same priority
    // Defect(s) Found: Multiple defects in selection and removal logic
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);
        priorityQueue.Enqueue("E", 3);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Single item in queue
    // Expected Result: Should dequeue correctly and queue becomes empty
    // Defect(s) Found: Removal logic was missing from original implementation
    public void TestPriorityQueue_7()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyItem", 5);
        
        Assert.AreEqual(1, priorityQueue.Count);
        Assert.AreEqual("OnlyItem", priorityQueue.Dequeue());
        Assert.AreEqual(0, priorityQueue.Count);
    }

    [TestMethod]
    // Scenario: All items have same priority
    // Expected Result: Should dequeue in FIFO order (first in, first out)
    // Defect(s) Found: Comparison logic selected wrong item with >= operator
    public void TestPriorityQueue_8()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }
}