from typing import List


class Twitter:
    def __init__(self):
        self.subscriptions = {} # key: userId, value: set of followeeIds
        self.user_tweets = {} # key: userId, value: list of (timestamp, tweetId)
        self.timestamp = 0


    def postTweet(self, userId: int, tweetId: int) -> None:
        if userId not in self.user_tweets:
            self.user_tweets[userId] = []
        self.user_tweets[userId].append((self.timestamp, tweetId))
        self.timestamp += 1

    def getNewsFeed(self, userId: int) -> List[int]:
        import heapq

        min_heap = []

        if userId in self.user_tweets:
            for timestamp, tweetId in self.user_tweets[userId][-10:]:
                heapq.heappush(min_heap, (-timestamp, tweetId))

        if userId in self.subscriptions:
            for followeeId in self.subscriptions[userId]:
                if followeeId in self.user_tweets:
                    
                    for timestamp, tweetId in self.user_tweets[followeeId][-10:]:
                        heapq.heappush(min_heap, (-timestamp, tweetId))

        result = []
        for i in range(min(10, len(min_heap))):
            result.append(heapq.heappop(min_heap)[1])
        return result
            
        

    def follow(self, followerId: int, followeeId: int) -> None:
        if followerId == followeeId:
            return
        if followerId not in self.subscriptions:
            self.subscriptions[followerId] = set()
        self.subscriptions[followerId].add(followeeId)

    def unfollow(self, followerId: int, followeeId: int) -> None:
        if followerId in self.subscriptions:
            self.subscriptions[followerId].discard(followeeId)