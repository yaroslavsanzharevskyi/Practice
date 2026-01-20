class Solution:
    def findKthLargest(self, nums: List[int], k: int) -> int:
        """
        Returns the element that would be at index k
        if nums were sorted (0-based).
        """

        def partition(left, right, pivot_index):
            pivot = nums[pivot_index]

            # Move pivot to end
            nums[pivot_index], nums[right] = nums[right], nums[pivot_index]

            store = left
            for i in range(left, right):
                if nums[i] < pivot:
                    nums[store], nums[i] = nums[i], nums[store]
                    store += 1

            # Move pivot to its final place
            nums[store], nums[right] = nums[right], nums[store]
            return store

        left, right = 0, len(nums) - 1

        while True:
            pivot_index = random.randint(left, right)
            p = partition(left, right, pivot_index)

            if p == k:
                return nums[p]
            elif p < k:
                left = p + 1
            else:
                right = p - 1
