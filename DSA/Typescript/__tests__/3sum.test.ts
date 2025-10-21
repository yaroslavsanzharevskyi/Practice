import { threeSum } from '../3sum';

describe('threeSum', () => {
    test.each([
        [[],[]], 
        [[0],[]]
    ])('threeSum(%p) should return %p', (nums, expected) => {
        let result = threeSum(nums);
        expect(result).toEqual(expected)
    });
        
});