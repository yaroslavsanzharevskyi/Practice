class DoublyLinkedNode:
    def __init__(self, key: int = -1, val: "ValueNode" = None):  # Add defaults
        self.value = val
        self.key = key
        self.prev = None
        self.next = None
        
class DoublyLinkedList:
    def __init__(self):
        self.head = DoublyLinkedNode()
        self.tail = DoublyLinkedNode()
        self.head.next = self.tail
        self.tail.prev = self.head
        self.cache: dict[int, DoublyLinkedNode] = {}  # key: key, value: DoublyLinkedNode
        
    def _remove(self, node:DoublyLinkedNode):
        node.prev.next = node.next
        node.next.prev = node.prev
        
    def __len__(self) -> int:
        return len(self.cache)
    
    def evict(self) -> int:
        lru = self.tail.prev
        key = lru.key
        self._remove(lru)
        del self.cache[lru.key]
        return key 
        
    def _add_to_head(self, node:DoublyLinkedNode):
        node.next = self.head.next
        node.prev = self.head
        
        self.head.next.prev = node # order is critical
        self.head.next = node
        
    def put(self, key: int, val: "ValueNode"):
        node = DoublyLinkedNode(key,val)
        self._add_to_head(node)
        self.cache[key] = node
        
    def remove(self, node: "ValueNode"):
        dll_node = self.cache[node.key]
        self._remove(dll_node)
        del self.cache[node.key]       
        
class ValueNode:
    def __init__(self, key:int, val:int, frequency: int):
        self.key = key
        self.value = val
        self.frequency = frequency
        
class LFUCache:
    def __init__(self, capacity: int):
        self.capacity = capacity
        self.cache: dict[int, ValueNode] = {}  # key: key, value: node(key, value,frequency):
        self.freq_map : dict[int, DoublyLinkedList] = {}  # key: frequency, value: doubly linked list of nodes with this frequency
        self.min_freq = 0       
        
    def _update(self, node: ValueNode):
        old_frequency = node.frequency
        freq_list = self.freq_map[node.frequency]

        # clean old frequency list
        freq_list.remove(node) 
        if len(freq_list) == 0:
            del self.freq_map[old_frequency]
            if old_frequency == self.min_freq:
                self.min_freq += 1
        
        node.frequency += 1
        
        if node.frequency in self.freq_map:
            dest_freq_list = self.freq_map[node.frequency]
        else:
            dest_freq_list = DoublyLinkedList()
            self.freq_map[node.frequency] = dest_freq_list

        dest_freq_list.put(node.key, node)
        
    def _add_new_node(self, key:int, value: int):
        self.min_freq = 1
        new_node = ValueNode(key, value, 1)
        self.cache[key] = new_node
        
        if self.min_freq in self.freq_map:
            freq_list = self.freq_map[self.min_freq]
        else:
           freq_list = DoublyLinkedList()
           self.freq_map[self.min_freq] = freq_list
            
        freq_list.put(new_node.key, new_node) 
        
    def get(self, key: int) -> int:
        if key not in self.cache:
            return -1
        node = self.cache[key]
        
        # update val location and evict old value
        self._update(node)
        
        
        return node.value
        
    def put(self, key: int, value: int) -> None:  
        if self.capacity == 0:  
            return
        
        if key in self.cache:
            existing_node = self.cache[key]
            # set new value of key
            existing_node.value = value
            # update its frequency and bucket location
            self._update(existing_node)
            return
        
        if len(self.cache) >= self.capacity:
            low_freq_list = self.freq_map[self.min_freq]
            lru_key = low_freq_list.evict()
            del self.cache[lru_key]
            
            if len(low_freq_list) == 0:
                del self.freq_map[self.min_freq]
                
        self._add_new_node(key, value)



