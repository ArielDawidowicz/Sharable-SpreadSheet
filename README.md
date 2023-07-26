## Sharable-SpreadSheet - Thread-Safe Concurrent Spreadsheet

The Sharable-SpreadSheet is a thread-safe, concurrent spreadsheet designed to allow multiple users to read and write data simultaneously. Each user operates as a separate thread, performing various operations on the spreadsheet. To handle concurrent access and ensure thread safety, the Reader-Writer problem is addressed using a combination of binary semaphores and specific locking mechanisms.

### Design Overview

- The spreadsheet is represented as a two-dimensional array with dimensions [rows, cols], where each cell contains a string.

- To maintain thread safety, a total of (number of rows + number of cols + 2) binary semaphores are employed. For each row and column, a semaphore is created to protect them from concurrent modifications.

- A semaphore named "resource" safeguards the entire spreadsheet, and another semaphore is used to protect the modification of two counters essential for the spreadsheet's operation.

- Binary semaphores are chosen over mutexes for their relatively higher efficiency.

### Operations and User Groups

The possible operations are classified into three groups:

1. **Readers Group** - These include operations like `getCell`, `setCell`, and `getSize`. Multiple readers can operate concurrently.

2. **Searchers Group** - These operations (`findString`, `findInRow`, `findInCol`, `findInRange`, `findAll`) are also readers, but there is a limit on the number of concurrent searchers (defined by the argument `nUsers`). The searchers have to respect this limit.

3. **Writers Group** - Operations like `ExchangeRows`, `ExchangeCols`, `addRows`, `addCols`, `setAll`, `save`, and `load` fall under this category. Writers are exclusive and can only operate when there are no readers/searchers currently active. These operations have a significant impact on the entire spreadsheet.

### Implementation Details

- A counter tracks the number of readers currently operating. The first reader/searcher locks the resource lock, and the last reader to leave releases it.

- Each reader/search operation locks the corresponding row's lock, except `findInCol`, which locks the specific column each time, and `setCell`, which locks the specific row and column to modify the cell.

- The design allows a single cell write operation to occur without locking the entire spreadsheet, while still allowing multiple readers to operate concurrently.

- Each searcher increases the searchers' counter and waits if the limit is reached. A reader/searcher may increase the counter only after acquiring the counter's lock.

- Writers, being exclusive operations, don't need to lock any specific rows or columns. When a writer owns the resource lock, all other operations wait for it to finish.

### Conclusion

The Sharable-SpreadSheet is a robust, thread-safe implementation of a concurrent spreadsheet, allowing multiple users to perform read and write operations simultaneously. The combination of binary semaphores, specific row/column locking, and counter management ensures smooth and efficient operation in a concurrent environment. 

![image](https://user-images.githubusercontent.com/101277239/173196578-efd682f6-6034-4dc3-a497-9781eb444b5c.png)
![image](https://user-images.githubusercontent.com/101277239/173196587-a8a66f88-d88b-48d3-a293-c2443efa38f3.png)
![image](https://user-images.githubusercontent.com/101277239/173196609-35fa648f-7025-4d52-b96c-f22438494fcf.png)



GUI discripttion:


![GUI discription](https://user-images.githubusercontent.com/101277239/173197510-44df626a-eb81-4fe0-b4c2-bf05fc1b5e22.png)



