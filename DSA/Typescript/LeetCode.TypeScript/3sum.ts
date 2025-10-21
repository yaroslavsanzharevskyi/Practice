export function threeSum(nums: number[]): number[][] {
    nums.sort((a,b) => a - b);
    let resultingArray: number[][] = [];
    for (let i = 0; i < nums.length - 2; i++) {
        if(i > 0 && nums[i] === nums[i-1]){
            continue;
        }
        for (let j = nums.length-1; j >= i+2; j--) {
            if(j < nums.length-1 && nums[j] === nums[j+1]){
                continue;
            }

            let difference = nums[i] + nums[j];
            let indexOfMiddleOperand = -1;
            if(difference <= 0){
                for( let m = j-1; m >= i+1; m--){
                    if(nums[m] + difference < 0){
                        break;
                    }
                    if(nums[m] + difference == 0){
                        indexOfMiddleOperand = m;
                        break;
                    }
                    
                }
            } else {
                for( let m = i+1;  m <= j-1; m++){
                    if(nums[m] + difference > 0){
                        break;
                    }
                    if(nums[m] + difference == 0){
                        indexOfMiddleOperand = m;
                        break;
                    }
                    
                }
            }
            if(indexOfMiddleOperand !== -1){
                resultingArray.push([nums[i], nums[indexOfMiddleOperand], nums[j]]);
            }
      
        }
    }

    return resultingArray;
};