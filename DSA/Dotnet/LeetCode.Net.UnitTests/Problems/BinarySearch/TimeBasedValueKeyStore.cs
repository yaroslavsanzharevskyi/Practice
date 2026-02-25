
using DSA.Problems.BinarySearch;
using Xunit;

public class TimeBasedValueKeyStoreTests
{
    [Fact]
    public void Get_Should_Return()
    {
        TimeMap timeMap = new TimeMap();
        var expectedResult = "sad";
        timeMap.Set("alice", "happy", 1);  // store the key "alice" and value "happy" along with timestamp = 1.
        // timeMap.Get("alice", 1);           // return "happy"
        // timeMap.Get("alice", 2);           // return "happy", there is no value stored for timestamp 2, thus we return the value at timestamp 1.
        timeMap.Set("alice", "sad", 3);    // store the key "alice" and value "sad" along with timestamp = 3.
        var result = timeMap.Get("alice", 3);

        Assert.Equal(expectedResult, result);      // return "sad"
    }

    [Fact]
    public void Get_ShouldReturn_WhenNoExactTimeStampIsPresent()
    {
        TimeMap timeMap = new TimeMap();
        var expectedResult = "sad";
        timeMap.Set("alice", "happy", 1);  // store the key "alice" and value "happy" along with timestamp = 1.
                                           // timeMap.Get("alice", 1);           // return "happy"
                                           // timeMap.Get("alice", 2);  
        timeMap.Set("alice", "sad", 2);

        timeMap.Set("alice", "sad", 4);
        timeMap.Set("alice", "sad", 5);          // return "happy", there is no value stored for timestamp 2, thus we return the value at timestamp 1.
        timeMap.Set("alice", "sad", 6);    // store the key "alice" and value "sad" along with timestamp = 3.
        var result = timeMap.Get("alice", 3);

        Assert.Equal(expectedResult, result);      // return "sad"
    }
}