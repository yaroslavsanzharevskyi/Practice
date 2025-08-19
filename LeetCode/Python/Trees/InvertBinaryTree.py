from typing import Optional
from Structures.TreeNode import BinaryTreeNode


class Solution:

    def invertTree(self, root: Optional[BinaryTreeNode]) -> Optional[BinaryTreeNode]:

        if root is None:
            return None
        
        #swap
        temp = root.left
        root.left = root.right
        root.right = temp 
        
        # invert children
        self.invertTree(root.left)
        self.invertTree(root.right)
        
        return root