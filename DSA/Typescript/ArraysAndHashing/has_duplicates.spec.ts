import { hasDuplicates } from "./has_duplicates";

describe('hasDuplicates', () => {
    test('1,2,3,1 contains duplicates', () => {
        // Arrange
        const nums = [1, 2, 3, 1];
        // Act
        const result = hasDuplicates(nums);

        // Assert
        expect(result).toBe(true);
    })
})