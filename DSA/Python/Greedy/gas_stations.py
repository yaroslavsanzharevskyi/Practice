class Solution:
    def canCompleteCircuit(self, gas_amount: List[int], gas_consumpion: List[int]) -> int:
        # verify that there is anough gas in a loop
        total_gas = 0
        total_cost = 0
        current_gas = 0
        starting_position = 0
        
        for i in range(len(gas_amount)):
            total_gas += gas_amount[i]
            total_cost += gas_consumpion[i]
            
            current_gas += gas_amount[i] - gas_consumpion[i]
            
            if current_gas < 0:
                starting_position = i + 1
                current_gas = 0
        
        return starting_position if total_gas >= total_cost else -1