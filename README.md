# Please note  
This code base was created in a short period of time without considering maintainability in order to complete a project suddenly proposed by the school. This code is more for personal learning and storage. I don't think it will be of value to you for reference or actual use.  
  
这个代码库是在短时间不考虑维护性，为了完成学校突然提出的项目而制作的，本代码更多用于个人学习以及储存使用，我不认为对您会有参考学习或是实际使用的价值。  

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
Implemented disk loading of dictionaries  
- R6.09.22:  
Created Logger  
- R6.09.23  
  Updated the Logger code to make it a static class.  
  Updated Lexi2Engine and added the instanceIndex property  
  Added the EnginePool class. Now you can use the object pool to manage the engine!  

## Plan To Do  
- Image Selector  
- http communication  

## Third-party libraries used
- **[jieba.NET](https://github.com/anderscui/jieba.NET)** - Licensed under the MIT License.
