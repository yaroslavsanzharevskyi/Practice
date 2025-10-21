class ListNode {
    val: number
    next: ListNode | null
    constructor(val?: number, next?: ListNode | null) {
        this.val = (val === undefined ? 0 : val)
        this.next = (next === undefined ? null : next)
    }
}
function CalcDepth(node: ListNode | null, n: number): number {
    let currentDepth = 0;
    if (node == null) {
        return currentDepth;
    }
    if( node.next == null){
        currentDepth = 1;
    }
    else {
        currentDepth = 1 + CalcDepth(node.next, n);
    }
    
    if(currentDepth === n){
        node = node.next;
    }

    return currentDepth;
}

function removeNthFromEnd(head: ListNode, n: number): ListNode | null {
    

    CalcDepth(head, n);

    return head;

};

