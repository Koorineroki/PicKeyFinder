# PicKeyFinder
This is the code for the Mars Base project, in which users provide corresponding pictures when communicating with Ai.

## Update Log
- R6.09.13：  
Completed Demo and passed verification  
- R6.09.18：  
Upload the project to GitHub  
- R6.09.19：  
**Optimize code:** Move **Analysis of time-consuming methods** to **DebugTools** Class  
**Note:** After testing, I found that GayHub's ReadMe.md requires pressing the space bar twice to wrap the line.  
**Optimize code:** Move **Debug info function** to **DebugTools** Class.  
**Optimize code:** completely separate "debug logic" from main logic.
- R6.09.21:  
Code refactoring optimization.  
Optimize file structure.  
Rename TextProcess to UtteranceProcess.  
In UtteranceProcess, the dictionary used to store words and weights. I used List instead and removed the use of foreach, which eventually saved about 200ms in word segmentation.  
Introduce Lexi2PEngine Class as an encapsulation of details when calling functions in a single thread(unfinished).  
Introduce SynonymFilter Class to match the obtained keywords with the vocabulary (unfinished).  
Updated the functionality of SynonymFilters, added a Filter method for filtering words, and made the PickWords method more concise.
  
## Plan To Do  
Migrate "synonymDictionary" in SynonymFilter Class to file format and support hot reload.  
Logger.  
Support input commands.  

## Third-party libraries used
- **[jieba.NET](https://github.com/anderscui/jieba.NET)** - Licensed under the MIT License.