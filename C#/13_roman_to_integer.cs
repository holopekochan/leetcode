public class Solution {

    Dictionary<char, int>  romanToNumber = new Dictionary<char, int>{
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    public int RomanToInt(string s) {
        if(s.Length < 1 || s.Length > 15) {
            throw new ArgumentException("String length cannot be short than 1 or longer than 15");
        }
        int sum = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if(romanToNumber[s[i-1]] < romanToNumber[s[i]]){
               sum -= romanToNumber[s[i-1]];

            } else {
                sum += romanToNumber[s[i-1]];
            }
        }
        sum += romanToNumber[s[s.Length - 1]];
        return sum;
        
    }
}
