using System;
class SharableSpreadSheet
{
    private String[,] spreadSheet;
    private Semaphore[] rows_mutex;
    private Semaphore[] cols_mutex;
    private Semaphore countersLock;
    private Semaphore resource;
    private long searchers_counter;
    private long non_writers_counter;
    private int numOfRows;
    private int numOfCols;
    private long concurrentSearchLimit;

    // nUsers used for setConcurrentSearchLimit, -1 mean no limit.
    // construct a nRows*nCols spreadsheet
    public SharableSpreadSheet(int nRows, int nCols, int nUsers = -1)
    {
        if (nRows < 1 || nCols < 1 )
            throw new Exception("Invalid row/col");
        numOfCols = nCols;
        numOfRows = nRows;
        concurrentSearchLimit = nUsers;
        spreadSheet = new string[nRows, nCols];
        cols_mutex = new Semaphore[numOfCols];
        rows_mutex = new Semaphore[numOfRows];
        countersLock = new Semaphore(0, 1);
        countersLock.Release();
        resource = new Semaphore(0, 1);
        resource.Release();
        searchers_counter = 0;

        for (int i = 0; i < numOfRows; i++)
        {
            rows_mutex[i] = new Semaphore(0,1);
            rows_mutex[i].Release();
        }
        for (int i = 0; i < numOfCols; i++)
        {
            cols_mutex[i] = new Semaphore(0, 1);
            cols_mutex[i].Release();
        }
    }
    public String getCell(int row, int col)
    {
        if (row < 0 || col < 0 || row >= numOfRows || col >= numOfCols)
            throw new Exception("Invalid row/col");
        readerRequest();
        rows_mutex[row].WaitOne();
        String cell = spreadSheet[row, col];
        rows_mutex[row].Release();
        readerRelease();
        return cell;
    }
    public void setCell(int row, int col, String str)
    {
        if (row < 0 || col < 0 || row >= numOfRows || col >= numOfCols)
            throw new Exception("Invalid row/col");
        readerRequest();
        rows_mutex[row].WaitOne();
        cols_mutex[col].WaitOne();
        spreadSheet[row, col] = str;
        cols_mutex[col].Release();
        rows_mutex[row].Release();
        readerRelease();
    }

    // return first cell indexes that contains the string (search from first row to the last row)
    public Tuple<int, int> searchString(String str)
    {
        if (!searcherRequest())
            return new Tuple<int, int>(-1,-1);
        int row, col;
        Tuple<int, int> position;
        for (int i = 0; i < numOfRows; i++)
        {
            rows_mutex[i].WaitOne();
            for (int j = 0; j < numOfCols; j++)
            {

                if (spreadSheet[i, j] == str)
                {
                    row = i;
                    col = j;
                    position = new Tuple<int, int>(row, col);
                    rows_mutex[i].Release();
                    searcherRelease();
                    return position;
                }
            }
            rows_mutex[i].Release();
        }
        searcherRelease();
        return new Tuple<int, int>(-1, -1);
    }

    // resource the content of row1 and row2
    public void ExchangeRows(int row1, int row2)
    {
        if (row1 < 0 || row2 < 0 || row1 >= numOfRows || row2 >= numOfRows)
            throw new Exception("Invalid row");
        writerRequest();
        for (int i = 0; i < numOfCols; i++)
        {
            String s = spreadSheet[row1, i];
            spreadSheet[row1, i] = spreadSheet[row2, i];
            spreadSheet[row2, i] = s;
        }
        writerRelease();
    }

    // resource the content of col1 and col2
    public void ExchangeCols(int col1, int col2) 
    {
        if (col1 < 0 || col2 < 0 || col1 >= numOfCols || col2 >= numOfCols)
            throw new Exception("Invalid col");
        writerRequest();
        for (int i = 0; i < numOfRows; i++)
        {
            String s = spreadSheet[i, col1];
            spreadSheet[i, col1] = spreadSheet[i, col2];
            spreadSheet[i, col2] = s;
        }
        writerRelease();
    }


    // perform search in specific row
    public int searchInRow(int row, String str)
    {
        if (row < 0 || row >= numOfRows)
            throw new Exception("Invalid row");
        if (!searcherRequest())
            return -1;
        int col;
        rows_mutex[row].WaitOne();
        for (int i =0; i < numOfCols; i++)
        {
            if (spreadSheet[row, i] == str)
            {
                col = i;
                rows_mutex[row].Release();
                searcherRelease();
                return col;
            }
        }
        rows_mutex[row].Release();
        searcherRelease();
        return -1;

    }

    // perform search in specific col
    public int searchInCol(int col, String str)
    {
        if (col < 0 || col >= numOfCols)
            throw new Exception("Invalid col");
        if (!searcherRequest())
            return -1;
        int row;
        cols_mutex[col].WaitOne();
        for (int i = 0; i < numOfRows; i++)
        {
            if (spreadSheet[i, col] == str)
            {
                row = i;
                cols_mutex[col].Release();
                searcherRelease();
                return row;
            }
        }
        cols_mutex[col].Release();
        searcherRelease();
        return -1;
    }

    // perform search within spesific range: [row1:row2,col1:col2] 
    //includes col1,col2,row1,row2
    public Tuple<int, int> searchInRange(int col1, int col2, int row1, int row2, String str)
    {
        if (col1 < 0 || col1 >= numOfCols || col2 < 0 || col2 >= numOfCols || row1 < 0 || row2 < 0 || row1 >= numOfRows || row2 >= numOfRows)
            throw new Exception("Invalid parameters");

        if (col1 > col2 || row1 > row2)
            throw new Exception("Wrong range");
        if (!searcherRequest())
            return new Tuple<int, int>(-1, -1);
        int row, col;
        Tuple<int, int> position;

        for (int i = row1; i <= row2; i++)
        {
            rows_mutex[i].WaitOne();
            for (int j = col1; j <= col2; j++)
            {
                if (spreadSheet[i,j] == str)
                {
                    position = new Tuple<int,int>(i,j);
                    rows_mutex[i].Release();
                    searcherRelease();
                    return position;
                }
            }
            rows_mutex[i].Release();
        }
        searcherRelease();
        return new Tuple<int, int>(-1, -1);
    }

    //add a row after row1
    public void addRow(int row1)
    {
        if (row1 < 0 || row1 >= numOfRows)
            throw new Exception("Invalid row");
        writerRequest();
        String[,] newSpreadSheet = new String[numOfRows + 1, numOfCols];
        for (int i = 0; i <= row1; i++)
        {
            for(int j = 0; j< numOfCols; j++)
            {
                newSpreadSheet[i,j] = spreadSheet[i,j];
            }
        }
        for (int i = row1+1 ; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfCols; j++)
            {
                newSpreadSheet[i+1, j] = spreadSheet[i, j];
            }
        }
        rows_mutex = new Semaphore[numOfRows+1];
        for ( int i = 0; i < numOfRows+1; i++)
        {
            rows_mutex[i] = new Semaphore(0,1);
            rows_mutex[i].Release();
        }
        spreadSheet = newSpreadSheet;
        numOfRows++;
        writerRelease();

    }

    //add a column after col1
    public void addCol(int col1)
    {
        if (col1 < 0 || col1 >= numOfCols)
            throw new Exception("Invalid col");
        writerRequest();
        String[,] newSpreadSheet = new String[numOfRows, numOfCols+1];
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j <= col1; j++)
            {
                newSpreadSheet[i, j] = spreadSheet[i, j];
            }
        }
        for (int i = 0 ; i < numOfRows; i++)
        {
            for (int j = col1+1; j < numOfCols; j++)
            {
                newSpreadSheet[i, j+1] = spreadSheet[i, j];
            }
        }
        cols_mutex = new Semaphore[numOfCols + 1];
        for (int i = 0; i < numOfCols + 1; i++)
        {
            cols_mutex[i] = new Semaphore(0,1);
            cols_mutex[i].Release();
        }
        spreadSheet = newSpreadSheet;
        numOfCols++;
        writerRelease();
    }

    // perform search and return all relevant cells according to caseSensitive param
    public Tuple<int, int>[] findAll(String str, bool caseSensitive)
    {
        if (str == null)
            throw new Exception("Empty String");
        if (!searcherRequest())
            return null;
        List<Tuple<int, int>> allStrings = new List<Tuple<int, int>>();
        String strToLower = str.ToLower();

        for(int i = 0; i < numOfRows; i++)
        {
            rows_mutex[i].WaitOne();
            for (int j = 0; j < numOfCols; j++)
            {
                if (caseSensitive)
                {
                    String toCompare = spreadSheet[i, j];
                    if (str.Equals(toCompare))
                        allStrings.Add(new Tuple<int, int>(i, j));
                }
                else
                {
                    String toCompare = spreadSheet[i, j];
                    if (toCompare == null)
                    {
                        continue;
                    }

                    toCompare = toCompare.ToLower();

                    if (strToLower.Equals(toCompare))
                        allStrings.Add(new Tuple<int, int>(i, j));
                }
            }
            rows_mutex[i].Release();
        }
        searcherRelease();
        return allStrings.ToArray();

    }

    // replace all oldStr cells with the newStr str according to caseSensitive param
    public void setAll(String oldStr, String newStr, bool caseSensitive)
    {
        Tuple<int, int>[] allStrings = findAll(oldStr, caseSensitive);
        if (allStrings == null)
            return;
        writerRequest();
        for (int i = 0; i < allStrings.Length; i++)
        {
            int row = allStrings[i].Item1;
            int col = allStrings[i].Item2;
            spreadSheet[row, col] = newStr;
        }
        writerRelease();
    }

    // return the size of the spreadsheet in nRows, nCols
    public Tuple<int, int> getSize()
    {
        readerRequest();
        int nRows = numOfRows;
        int nCols = numOfCols;
        Tuple<int, int> spreadSheetSize = new Tuple<int, int>(nRows, nCols);
        readerRelease();
        return spreadSheetSize;
    }

    // this function aims to limit the number of users that can perform the search operations concurrently.
    // The default is no limit. When the function is called, the max number of concurrent search operations is set to nUsers. 
    // In this case additional search operations will wait for existing search to finish.
    // This function is used just in the creation
    public void setConcurrentSearchLimit(int nUsers)
    {
        if (nUsers <= 0)
            concurrentSearchLimit = -1;
        else
            concurrentSearchLimit = nUsers;
    }

    // save the spreadsheet to a file fileName.
    // you can decide the format you save the data. There are several options.
    public void save(String fileName)
    {
        writerRequest();
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            sw.Write("Rows:{0}" + "\n", numOfRows);
            sw.Write("Cols:{0}" + "\n", numOfCols);
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfCols; j++)
                {
                    sw.Write(spreadSheet[i, j] + ",");
                }
                sw.Write("\n");
            }
            sw.Close();
        }
        writerRelease();
    }

    // load the spreadsheet from fileName
    // replace the data and size of the current spreadsheet with the loaded data
    public void load(String fileName)
    {
        writerRequest();
        int rows, cols;
        String[] lines = System.IO.File.ReadAllLines(fileName);
        rows = int.Parse(lines[0].Substring(5));
        cols = int.Parse(lines[1].Substring(5));

        SharableSpreadSheet s0 = new SharableSpreadSheet(rows, cols);

        for (int i = 2; i < rows+2; i++)
        {
            String[] parsedLine = lines[i].Split(",");
            for(int j = 0; j < cols; j++)
            {
                s0.setCell(i - 2, j, parsedLine[j]);
            }
        }
        numOfRows = rows;
        numOfCols = cols;
        spreadSheet = s0.spreadSheet;
        writerRelease();
    }


    private void readerRequest()
    {
        countersLock.WaitOne();
        Interlocked.Increment(ref non_writers_counter);
        if (Interlocked.Read(ref non_writers_counter) == 1)
        {
            resource.WaitOne();
        }
        countersLock.Release();
    }

    private void readerRelease()
    {
        countersLock.WaitOne();
        Interlocked.Decrement(ref non_writers_counter);
        if (Interlocked.Read(ref non_writers_counter) == 0)
            resource.Release();
        countersLock.Release();
    }

    private bool searcherRequest()
    {
        countersLock.WaitOne();
        // concurrentSearchLimit==-1 means there no limit on searcher counter
        if (concurrentSearchLimit==-1 || searchers_counter < concurrentSearchLimit)
        {
            Interlocked.Increment(ref non_writers_counter);
            Interlocked.Increment(ref searchers_counter);
            if (Interlocked.Read(ref non_writers_counter) == 1)
            {
                resource.WaitOne();
            }
            countersLock.Release();
            return true;
        }
        countersLock.Release();
        return false;
    }

    private void searcherRelease()
    {
        countersLock.WaitOne();
        Interlocked.Decrement(ref non_writers_counter);
        Interlocked.Decrement(ref searchers_counter);
        if (Interlocked.Read(ref non_writers_counter) == 0)
            resource.Release();
        countersLock.Release();
    }

    private void writerRelease()
    {
        resource.Release();
    }

    private void writerRequest()
    {
        resource.WaitOne();
    }
    public int getCols()
    {
        return numOfCols;
    }
    public int getRows()
    {
        return numOfRows;
    }

    public void PrintSheet()
    {
        String col = "";
        for (int i=0; i < numOfRows; i++)
        {
            for (int j=0 ; j < numOfCols; j++)
            {
                col += spreadSheet[i, j];
                col += ",";
            }
            Console.WriteLine(col);
            col = "";
        }
    }
}





