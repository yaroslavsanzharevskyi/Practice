class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
        
# Logic in solution is simple we simply turn away nodes, and store previous node that we turned away
# on next iteration we link this prev node as next for new current
# in between iteration there is broken connection but we keep reference for an processeced one
def reverseList(head:Optional[ListNode]) -> Optional[ListNode]:
    
    prev = None
    current = head
    
    while current != None:
        # next is 2 | ... | next is 6 | next is None
        next = current.next
        # 1 next none | 5 next is prev(4) | 6 next is prev(5)
        current.next = prev
        # 1 is processed and become prev(with next == None)| prev = 5 | prev = 6
        prev = current
        # now we looking at 2 which is new current| current = 6 | current = None
        current = next
    
    return prev
        