
import java.util.*;

class Solution {
    public int[] separateDigits(int[] nums) {

        List<Integer> list = new ArrayList<>();

        for (int num : nums) {

            List<Integer> temp = new ArrayList<>();

            while (num > 0) {

                int digit = num % 10;

                temp.add(digit);

                num = num / 10;
            }

            // Add digits in correct order
            for (int i = temp.size() - 1; i >= 0; i--) {
                list.add(temp.get(i));
            }
        }

        // Convert ArrayList to int[]
        int[] answer = new int[list.size()];

        for (int i = 0; i < list.size(); i++) {
            answer[i] = list.get(i);
        }

        return answer;
    }
}