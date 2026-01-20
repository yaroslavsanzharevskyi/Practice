import heapq

def k_closest(points, k):
    heap = []

    for x, y in points:
        dist = x*x + y*y
        heapq.heappush(heap, (-dist, x, y))

        if len(heap) > k:
            heapq.heappop(heap)

    return [(x, y) for (_, x, y) in heap]
