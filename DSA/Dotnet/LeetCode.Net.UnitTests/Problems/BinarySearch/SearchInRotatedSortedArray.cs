using DSA.Problems.BinarySearch;
using Xunit;

namespace DSA.Problems.Tests.BinarySearch;

public class SearchInRotatedSortedArrayTests
{
    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenTargetExists()
    {
        // Arrange
        var solution = new SearchInRotatedSortedArray();
        var nums = new int[] { 3, 4, 5, 6, 1, 2 };
        var target = 4;
        var expectedIndex = 1;

        // Act
        var actualIndex = solution.Search(nums, target);

        // Assert
        Assert.Equal(expectedIndex, actualIndex);
    }
    
    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenTargetExists2()
    {
        // Arrange
        var solution = new SearchInRotatedSortedArray();
        var nums = new int[] { 5,6,1,2,3,4 };
        var target = 6;
        var expectedIndex = 1;

        // Act
        var actualIndex = solution.Search(nums, target);

        // Assert
        Assert.Equal(expectedIndex, actualIndex);
    }

    
}