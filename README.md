# File-Organization-Project2
This is my second project about File Organization.  It's all about  Perfect Hashing Cichelli’s Algorithm.

Cichelli's hashing functions are very simple. Given a word w, the hash value is Value( First_Letter( w ) ) + Value( Last_Letter( w ) ) + Length( w ). The mapping function Value() is normally implemented as a table that maps characters into numbers. Figure 1 is an example of table and hash values of a minimal perfect hashing functions for the days of the week. Note that you only need to keep a small table for Value(), since only first and last letters need to be mapped. Calculating the hash value takes only two accesses in the table and two additions. 

Cichelli's algorithm 
The original algorithm uses an exhaustive approach with backtracking. Every possible mapping is tried for Value(), and whenever an assignment results in a collision, the search path is pruned and another solution is tried. The algorithm is easy to code, but can take exponential time (in the number of words) to calculate. 
Cichelli suggested two ways to speed up this approach. One way is to sort the keys: compute the frequency of the first and last letter, then sort the words according to the sum of the frequency for the first and last letters. This guarantees that the most common letters are assigned values early, and increases the probability that collisions are found when the depth of the search tree is still small. This reduces the cost of backtracking. 
This isn't always sufficient, however. Consider the set of keys:

{aa, ab, ac, ad, ae, af, ag, bd, cd, ce, de, fg},

which sorts to

{aa, ad, ac, ae, ab, af, ag, cd, de, bd, ce, fg}.

Now, the value of the key cd is determined as soon as ac is given a value, but a test for collision on cd is not done until five more branches in the search tree are taken. This makes a collision on cd much more costly than it ought to be. 
Cichelli suggested a second heuristic to address the problem. If a key in this sorted list has letters that have already occurred, the key is placed immediately after the one that completes its mapping. In the aforementioned example, cd will be moved immediately after ac. While doing so, you must try to maintain the original sorting order whenever possible: listing 1 is a snippet of my C++ implementation. 

There are five steps to Cichelli's algorithm: 
(1) Calculate the frequency of first and last letters. 
(2) Order the keys in decreasing order of the sum of the frequencies. 
(3) Reorder the keys from the beginning of the list, so that if a key's first and last letters have already appeared, that key is placed next to the completing key in the list. 
(4) Search cycle: for each key, if both values for first and last letters are already assigned, try to place the key in the table (step 5); otherwise, if only one value needs to be assigned, try all the possible assignments. If both values must be assigned, use two nested loops to try all the possible assignments for the two letters. 
(5) Given the key, the length, and the Value mapping, compute the address in the table. Backtrack to step (4) if there is a collision; otherwise place the key in the table. If is the last letter, a perfect hashing has been found; otherwise, recursively go into step (4) for the next key.

The table size is not fixed. If the table size is equal to the number of keys, we are looking for a minimal perfect hashing; otherwise, some empty buckets remain at the end of the process. 

Source:
http://www.eptacom.net/pubblicazioni/pub_eng/mphash.html
