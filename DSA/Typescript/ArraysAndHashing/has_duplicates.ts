export function hasDuplicates(nums: number[]): boolean {
    if (nums.length <= 1)
        return false;

    let set = new Set<number>();

    for (const num of nums) {
        if (set.has(num))
            return true;

        set.add(num);
    }

    return false;
}

export function hasDuplicates2(nums: number[]): boolean {
    return new Set(nums).size !== nums.length;
}