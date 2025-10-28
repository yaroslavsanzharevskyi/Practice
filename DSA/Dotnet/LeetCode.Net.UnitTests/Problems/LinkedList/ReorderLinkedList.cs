using System.Collections.Generic;
using NUnit.Framework;

namespace DSA.Problems.LinkedList.Tests;


[TestFixture]
public class ReoderLinkedListTests
{
    [Test]
    public void ReorderList_ShouldReorderLinkedListCorrectly()
    {
        // Arrange
        var solution = new ReorderLinkedList();
        var head = new ListNode(0)
        {
            next = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                            
                        }
                    }
                }
            }
        };

        var expected = new ListNode(0)
        {
            next = new ListNode(6)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(5)
                    {
                        next = new ListNode(2)
                        {
                            next = new ListNode(4)
                            {
                                next = new ListNode(3)
                            }
                        }
                    }
                }
            }
        };


        // Act
        solution.ReorderList(head);

        // Assert
        var currentExpected = expected;
        var currentActual = head;

        while (currentExpected != null && currentActual != null)
        {
            Assert.That(currentActual.val, Is.EqualTo(currentExpected.val));
            currentExpected = currentExpected.next;
            currentActual = currentActual.next;
        }

        Assert.That(currentExpected, Is.Null);
        Assert.That(currentActual, Is.Null);
    }
}