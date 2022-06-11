# Sharable-SpreadSheet

We have designed a sharable spreadsheet which allows multiple users to read and write concurrently (each thread is one user that performs multiple operations). The spreadsheet deals with the Reader-Writer problem, and it is designed to be thread-safe. The spreadsheet is a two-dimensional array with sizes [rows, cols] each cell contains a string. A total number of (number of rows + number of cols+2) binary semaphores were used to ensure thread-safety, a semaphore is created for each row and each column. One semaphore named resource protects the entire spreadsheet and another semaphore protects the modification of 2 counters that are used by the spreadsheet. We decided to use Binary semaphores instead of mutexes because they are slightly more effective. 
We have classified the possible operations to 3 groups: 
1.	Readers group- [ getCell, setCell, getSize].
2.	Searchers group- [ findString, findInRow, findInCol, findInRange, findAll]  they are also readers but there is a limit on the possible number of concurrent searchers ( an argument nUsers defines the limit) .
3.	Writers group- [ ExchangeRows, ExchangeCols, addRows, addCols, setAll, save, load] 
Multiple readers/searchers can operate at the same time, on the other hand writers are exclusive- they can operate only when there are no readers operating currently. The writers group operations are high impact operation which affect most of the spreadsheet. There is a counter for number of readers currently operating, the first reader/searcher locks the resource lock and only last reader to leave releases it. 
Each reader/search operation locks the suitable row’s lock, except findInCol which locks the specific col each time and setCell which locks the specific row and col to be able to modify the cell. The design lets a single cell write operation to happen without locking the whole spreadsheet, while letting many readers operate at the same time. 
Each searcher increases the searchers counter and if the limit is reached the searcher needs to wait. A reader/searcher may increase the counter only after getting the counter’s lock.
Each writer is the sole operation on the spreadsheet, thus doesn’t need to lock any rows or cols. When a writer owns the resource lock, all the other operations are waiting for it to finish. 

![image](https://user-images.githubusercontent.com/101277239/173196578-efd682f6-6034-4dc3-a497-9781eb444b5c.png)
![image](https://user-images.githubusercontent.com/101277239/173196587-a8a66f88-d88b-48d3-a293-c2443efa38f3.png)
![image](https://user-images.githubusercontent.com/101277239/173196609-35fa648f-7025-4d52-b96c-f22438494fcf.png)


# Sharable-SpreadSheet GUI
In this part we decided to make a gui to the SharableSpreadSheet class with forms app.
the application supports some of the original class functions: new file, save file, load file, add rows, add columns, search words, set cell, get cell.

GUI discripttion:


![GUI discription](https://user-images.githubusercontent.com/101277239/173197510-44df626a-eb81-4fe0-b4c2-bf05fc1b5e22.png)



