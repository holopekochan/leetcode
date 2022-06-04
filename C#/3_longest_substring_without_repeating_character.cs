// First attempt solution
// Runtime: 254 ms, faster than 11.34% of C# online submissions for Longest Substring Without Repeating Characters.
// Memory Usage: 49 MB, less than 5.73% of C# online submissions for Longest Substring Without Repeating Characters.

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int longest = 0;
        for(int charIndex = 0; charIndex < s.Length; charIndex++) {
            int counter = 1;
            string currentSubString = s[charIndex].ToString();
            for (int i = charIndex + 1; i < s.Length ; i++ ) {
                if(currentSubString.Contains(s[i])){
                    break;
                }
                currentSubString += s[i];
                counter++;
            }
            if(longest < counter) {
                longest = counter;
            }
        }
        return longest;
    }
}

// Second attempt solution
// Runtime: 253 ms, faster than 11.40% of C# online submissions for Longest Substring Without Repeating Characters.
// Memory Usage: 37.8 MB, less than 33.88% of C# online submissions for Longest Substring Without Repeating Characters.

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int longest = 0;
        for(int charIndex = 0; charIndex < s.Length; charIndex++) {
            int counter = 1;
            var dictionary = new Dictionary<char, bool>();
   
            dictionary.Add(s[charIndex], true);


            for (int i = charIndex + 1; i < s.Length ; i++ ) {
                if(dictionary.ContainsKey(s[i])){
                    break;
                }
                dictionary.Add(s[i], true);
                counter++;
            }
            if(longest < counter) {
                longest = counter;
            }
        }
        return longest;
    }
}


// Third attempt solution
// Runtime: 127 ms, faster than 34.42% of C# online submissions for Longest Substring Without Repeating Characters.
// Memory Usage: 36.8 MB, less than 74.45% of C# online submissions for Longest Substring Without Repeating Characters.

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int result = 0;
        List<char> charList = new List<char>();
        List<int> lengthList = new List<int>();
            
        for(int i = 0 ; i < s.Length ; i++) {
            if(!charList.Contains(s[i])) {
                charList.Add(s[i]);
            } else {
                lengthList.Add(charList.Count());
                // When character are the same, start i again from next character
                // i.e abcabcdd
                // i.e i = 3 - 3 = 0 then i = 4 - 3 = 1, i = 5 - 3 = 2, i = 7 - 4 = 3, 7 - 3 = 4, 7 - 2 = 5, 7-1 = 6 
                // then i++ after, so index moves to next to 2,3,4,5,6,7
                i = i - charList.Count;
                charList.Clear();
            }
        }
        lengthList.Add(charList.Count());

        
        result = lengthList.Max();
        return result;
    }
}