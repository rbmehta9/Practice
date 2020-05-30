Assumptions:
1.The search will ignore case
2.The search will ignore extra spacing
3.Filename must have an extension txt
4.Filename must reside in the same folder as executable (I have it in bin\Debug folder)


Explanation:
Although the problem asks for 2 keyword search, the core service (ProximitySearchService) implemented is generalized 
for any number of keywords (though the argument parser class in the console only assumes 2 keywords). 


Language: C#
Algorithm:
1.Store all the words in the inputfile in a List<string> 
2.Store Position of each keyword in a separate collection. Hence for K keywords there will be K collections.
  Hence 2 keywords 2 collections
  The collection should be sorted. In my case I used a stack.While creating stacks, the positions were
  already sorted since we looped though all the words in the file in increasing order
3. Have a counter for numberofMatches = 0  
4. Find the stack having the least position min by using stack.peek() for each. Let smin be stack with least position
5. Find Count of the positions in each stack(excluding smin) which are less than or equal to (range - 1) and get their product.The product
   gives us the number of matches for each position in the min stack
   Increment counter by prod.
   For 2 keywords,the counter gets simply incremented by nonminimum stack count
6. Pop minimum element from the stack containing it
7. if stack with minimum element is empty return numberofMatches. Else go to step 3

Complexity:
It will depend on 
1.Number of words in text (n) 
2.Range (r) 
3.Number of keywords (k)
4.Smallest frequency amongst all keywords i.e.initial smallest stack size of stack (n1<n2<n3<n4)
For 2 keywords, complexity O(n1r) where n1 is the keyword with least occurence
Generalizing for k keywords : O(n) + O(n1kr). If n1, k and r are very small then it becomes O(n) else as n1,k,r increase they will approach n and may exceed.


I will demonstrate the eg used in the pdf but I have used different texts and higher keywords in my unit tests

Sample text:
the man  the  plan  the canal   panama  panama  canal the  plan  the	 	man	 the	 the	 man	 the plan  the	  canal	  panama

TextWords : ["the", "man", "the", "plan", "the", "canal", "panama", "panama", "canal", "the", "plan", "the", "man", "the", "the", "man", "the", "plan", "the", "canal", "panama"]

Keywords: ["the", "canal"]

Stacks with positions for keywords:

0,2,4,9,11,13,14,16,18  - the (s1)
5,8,19                  - canal (s2)
numberofMatches = 0
Let smin be stack with least position

Loop Begins:
Iteration 1:
s1.peek < s2.Peek , hence smin = s1
Find number of elements in other stack(s2) such that they are less than or equal to smin.peek + range - 1 i.e. 0 + 6 -1 (only 5 is in that range)
Hence numberofMatches = 1
Remove minimum position from smin by smin.pop() (0)

Is Any stack empty ? No 

Iteration 2:
New Contents of stacks:
2,4,9,11,13,14,16,18  - the (s1)
5,8,19                - canal (s2)

s1.peek < s2.Peek , hence smin = s1
Find number of elements in other stack(s2) such that they are less than or equal to smin.peek + range - 1 i.e. 2 + 6 -1  (only 5 is in that range)
Hence numberofMatches = 2
Remove minimum position from smin by smin.pop() (2)

Is Any stack empty ? No

Iteration 3:
4,9,11,13,14,16,18  - the (s1)
5,8,19                - canal (s2)
s1.peek < s2.Peek , hence smin = s1
Find number of elements in other stack(s2) such that they are less than or equal to smin.peek + range - 1 i.e. 4 + 6 -1  ( 5 and 8 is in that range)
Increment numberofMatches by 2
Hence numberofMatches = 4
Remove minimum position from smin by smin.pop() (4)

Is Any stack empty ? No

Iteration 4:
9,11,13,14,16,18  - the (s1)
5,8,19            - canal (s2)
s2.peek < s1.Peek , hence smin = s2
Find number of elements in other stack(s1) such that they are less than or equal to smin.peek + range - 1 i.e. 5 + 6 -1  (only 9 is in that range)
Hence numberofMatches = 5
Remove minimum position from smin by smin.pop() (5)

Is Any stack empty ? No

Iteration 5:
9,11,13,14,16,18  - the (s1)
8,19            - canal (s2)
s2.peek < s1.Peek , hence smin = s2
Find number of elements in other stack(s1) such that they are less than or equal to smin.peek + range - 1 i.e. 8 + 6 -1  (9,11,13 is in that range)
Increment numberofMatches by 3
Hence numberofMatches = 8
Remove minimum position from smin by smin.pop() (8)
Is Any stack empty ? No

Iteration 6:
9,11,13,14,16,18  - the (s1)
19            - canal (s2)
s1.peek < s2.Peek , hence smin = s1
Find number of elements in other stack(s2) such that they are less than or equal to smin.peek + range - 1 i.e. 9 + 6 -1  ( no element found)
Hence numberofMatches = 8 (no change)
Remove minimum position from smin by smin.pop() (9)
Is Any stack empty ? No

Iteration 7
11,13,14,16,18  - the (s1)
19            - canal (s2)
s1.peek < s2.Peek , hence smin = s1
Find number of elements in other stack(s2) such that they are less than or equal to smin.peek + range - 1 i.e. 11 + 6 -1  ( no element found)
Hence numberofMatches = 8 (no change)
Remove minimum position from smin by smin.pop() (11)
Is Any stack empty ? No

Iteration = 8
13,14,16,18  - the (s1)
19            - canal (s2)
s1.peek < s2.Peek , hence smin = s1
Find number of elements in other stack(s2) such that they are less than or equal to smin.peek + range - 1 i.e. 13 + 6 -1  ( no element found)
Hence numberofMatches = 8 (no change)
Remove minimum position from smin by smin.pop() (13)
Is Any stack empty ? No

Iteration = 9
14,16,18  - the (s1)
19            - canal (s2)
s1.peek < s2.Peek , hence smin = s1
Find number of elements in other stack(s2) such that they are less than or equal to smin.peek + range - 1 i.e. 14 + 6 -1  ( 19 found)
Hence numberofMatches = 9 
Remove minimum position from smin by smin.pop() (16)
Is Any stack empty ? No

Iteration = 10
16,18  - the (s1)
19            - canal (s2)
s1.peek < s2.Peek , hence smin = s1
Find number of elements in other stack(s2) such that they are less than or equal to smin.peek + range - 1 i.e. 16 + 6 -1  ( 19 found)
Hence numberofMatches = 10
Remove minimum position from smin by smin.pop() (16)
Is Any stack empty ? No

Iteration = 11
18  - the (s1)
19            - canal (s2)
s1.peek < s2.Peek , hence smin = s1
Find number of elements in other stack(s2) such that they are less than or equal to smin.peek + range - 1 i.e. 18 + 6 -1  ( 19 found)
Hence numberofMatches = 11
Remove minimum position from smin by smin.pop() (18)

<empty>       - the (s1)
19            - canal (s2)

Is Any stack empty ? Yes (s1). Hence numberofMatches = 11









