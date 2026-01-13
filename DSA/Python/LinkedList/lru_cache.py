class DoubleLinkedNode:
    def __init__(self, key: int, val: int):
        self.val = val
        self.key = key
        self.prev = None
        self.next = None
        
class LRUCache:
    def __init__(self, capacity: int):
        self.cache = {} # key is key, and value is index in array
         # Or for a fixed-size array: [0] * capacity
        self.capacity = capacity
        self.head = DoubleLinkedNode(-1,-1)
        self.tail = DoubleLinkedNode(-1,-1)
        self.head.next = self.tail
        self.tail.prev = self.head
        
    def _remove(self, node: DoubleLinkedNode):
        node.next.prev = node.prev
        node.prev.next = node.next
            
    def _add_to_head(self, node: DoubleLinkedNode):
        # now next neighbor of node is a previously next neighbor of head
        node.next = self.head.next
        
        # and now previous neighbor of next node is head
        node.prev = self.head
        
        # previous neighbor of head next  now reference node as previous
        self.head.next.prev = node
        
        # now head next is node
        self.head.next = node
     
    def get(self, key: int) -> int:
        if key not in self.cache:
            return -1
        
        node = self.cache[key]
        
        # relinking from where it is to head
        self._remove(node)
        self._add_to_head(node)
        
        return node.val    
   
    def put(self, key: int, value: int) -> None:
        if key in self.cache:
            self._remove(self.cache[key])
        
        node = DoubleLinkedNode(key,value)
        self._add_to_head(node)
        self.cache[key] = node
        
        if len(self.cache) > self.capacity:
            lru = self.tail.prev
            self._remove(lru)
            
            del self.cache[lru.key]