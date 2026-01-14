import time
from typing import Optional


class DoublyLinkedNode:
    def __init__(self, key: int = 0, value: int = 0, expiry_time: int = 0):
        self.key = key
        self.value = value
        self.expiry_time = expiry_time
        self.prev: 'DoublyLinkedNode' = None
        self.next: 'DoublyLinkedNode' = None


class DoublyLinkedList:
    def __init__(self, ):
        self.head = DoublyLinkedNode(-1, 0)
        self.tail = DoublyLinkedNode(-1, 0)
        self.head.next = self.tail
        self.tail.prev = self.head

    def add_to_head(self, node: DoublyLinkedNode):
        node.prev = self.head
        node.next = self.head.next

        self.head.next.prev = node
        self.head.next = node

    def remove_node(self, node: DoublyLinkedNode):
        node.prev.next = node.next
        node.next.prev = node.prev


class TLRUCache:
    def __init__(self, capacity: int, ttl: int):

        if capacity <= 0:
            raise ValueError("Capacity must be greater than 0")

        self.capacity = capacity
        self.cache: dict[int, DoublyLinkedNode] = {}
        self.dll = DoublyLinkedList()
        self.default_ttl = ttl

    def _update(self, node: DoublyLinkedNode):
        self.dll.remove_node(node)
        self.dll.add_to_head(node)

    def get(self, key: int) -> Optional[int]:
        if key not in self.cache:
            return None
        node = self.cache[key]
        if time.time() >= node.expiry_time:
            self.dll.remove_node(node)
            del self.cache[key]
            return None

        self._update(node)

        return node.value

    def put(self, key: int, value: int):

        if key in self.cache:
            node = self.cache[key]
            node.value = value
            node.expiry_time = self.default_ttl + time.time()
            self._update(node)
            return
        
        if len(self.cache) > self.capacity:
            lru = self.dll.tail.prev
            self.dll.remove_node(lru)
            del self.cache[lru.key]

        new_node = DoublyLinkedNode(key, value)
        new_node.expiry_time = self.default_ttl + time.time()
        self.cache[key] = new_node
        self.dll.add_to_head(new_node)

      
