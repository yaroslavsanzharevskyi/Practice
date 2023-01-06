const lettersmap = ['', '', 'abc', 'def', 'ghi', 'jkl', 'mno', 'pqrs', 'tuv', 'wxyz']

function letterCombinations(digits: string): string[] {
    let result: string[] = [];
    if (digits.length === 0) {
        return [];
    }

    let left = [''];
    for (let i = 0; i < digits.length; i++) {
        left = combineArrays(left, lettersmap[digits[i]]);
    }

    return left;
};

function combineArrays(left: string[], right: string[]): string[] {
    const resultArray: string[] = [];

    for (let i = 0; i < left.length; i++) {
        resultArray.push(left[i] + right[0]);
        resultArray.push(left[i] + right[1]);
        resultArray.push(left[i] + right[2]);
        right.length == 4 ? resultArray.push(left[i] + right[2]) : '';
    }

    return resultArray;
}