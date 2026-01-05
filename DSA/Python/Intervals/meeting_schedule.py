
#Definition of Interval:
from typing import List


class Interval(object):
    def __init__(self, start, end):
        self.start = start
        self.end = end


class Solution:
    def canAttendMeetings(self, intervals: List[Interval]) -> bool:
        if len(intervals) <= 1:
            return True
        sorted_intervals = sorted(intervals, key=lambda x: x.start)
        
        previous = sorted_intervals[0]
        for i in range(1,len(intervals)):
            
            current = sorted_intervals[i]
            
            if current.start < previous.end:
                return False
            
            previous = current
        
        return True
            
