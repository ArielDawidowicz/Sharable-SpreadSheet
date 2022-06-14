class Simulator
{
    static SharableSpreadSheet spreadSheet;

    public static void Main(string[] args)
    {
        if (args.Length != 5)
            throw new ArgumentException("Please enter 5 arguments");

        if (int.Parse(args[0]) <= 0 || int.Parse(args[1]) <= 0 || int.Parse(args[2]) <= 0 || int.Parse(args[3]) <= 0 || int.Parse(args[4]) < 0)
            throw new ArgumentException("Invalid arguments");

        spreadSheet = new SharableSpreadSheet(int.Parse(args[0]), int.Parse(args[1]));


        Random random = new Random();
        for (int i = 0; i < spreadSheet.getRows(); i++)
        {
            for (int j = 0; j < spreadSheet.getCols(); j++)
            {
                spreadSheet.setCell(i, j, random.Next(9).ToString());
            }
        }
        Console.WriteLine("////////////////////START\\\\\\\\\\\\\\\\\\\\\\");
        Thread[] ts = new Thread[int.Parse(args[2])];
        for (int i = 0; i < ts.Length ; i++)
        {

            ts[i] = new Thread(() =>
            {
                for (int j = 0; j < int.Parse(args[3]); j++)
                {
                    Simulator.randomFunc();
                    Thread.Sleep(int.Parse(args[4]));
                }
            }); 
        }

        for (int i = 0; i < ts.Length; i++)
        {
            if (ts[i] != null)
                ts[i].Start();
        }

        for (int i = 0; i < ts.Length; i++)
        {
            if (ts[i] != null)
                ts[i].Join();
        }

        Console.WriteLine("////////////////////DONE\\\\\\\\\\\\\\\\\\\\\\");
    }

    //this function returns a random function of SharableSpreadSheet class to test multithreading
    public static void randomFunc()
    {
        int dimensions = 100;
        Random r = new Random();
        int n = r.Next(12);
        int x = r.Next(dimensions);
        int y = r.Next(dimensions);
        int x0 = r.Next(dimensions);
        int y0 = r.Next(dimensions);
        int str = r.Next(9);
        int newStr = r.Next(9);
        bool b = x > y ? true : false;
        if (n == 0)
        {
            string s = spreadSheet.getCell(x, y);
            Console.WriteLine("User[{0}]: [{1}] found:{2} in cell ({3},{4})", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), s, x, y);
        }
        else if (n == 1)
        {
            spreadSheet.setCell(x, y, str.ToString());
            Console.WriteLine("User[{0}]: [{1}] set:{2} in cell ({3},{4})", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), str.ToString(), x, y);
        }
        else if (n == 2)
        {
            Tuple<int, int> t = spreadSheet.searchString(str.ToString());
            Console.WriteLine("User[{0}]: [{1}] searched:{2} and found it in cell {3}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), str.ToString(), t.ToString());
        }
        else if (n == 3)
        {
            spreadSheet.ExchangeRows(x, y);
            Console.WriteLine("User[{0}]: [{1}] exchanged rows:{2} and {3}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), x, y);

        }
        else if (n == 4)
        {
            spreadSheet.ExchangeCols(x, y);
            Console.WriteLine("User[{0}]: [{1}] exchanged cols:{2} and {3}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), x, y);

        }
        else if (n == 5)
        {
            spreadSheet.searchInRow(x, str.ToString());
            Console.WriteLine("User[{0}]: [{1}] searched:{2} in row:{3}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), str.ToString(), x);
        }
        else if (n == 6)
        {
            spreadSheet.searchInCol(x, str.ToString());
            Console.WriteLine("User[{0}]: [{1}] searched:{2} in col:{3}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), str.ToString(), x);
        }
        else if (n == 7)
        {
            try
            {
                spreadSheet.searchInRange(x, y, x0, y0, str.ToString());
                Console.WriteLine("User[{0}]: [{1}] searched:{2} in range:[{3},{4}] x [{5},{6}]", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), str.ToString(), x, y, x0, y0);
            }
            catch (Exception ex)
            {

            }

        }
        else if (n == 8)
        {
            spreadSheet.addRow(x);
            Console.WriteLine("User[{0}]: [{1}] added row after row:{2}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), x);
        }
        else if (n == 9)
        {
            spreadSheet.addCol(x);
            Console.WriteLine("User[{0}]: [{1}] added col after col:{2}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), x);
        }
        else if (n == 10)
        {
            spreadSheet.findAll(str.ToString(), b);
            Console.WriteLine("User[{0}]: [{1}] searched for all:{2} instances", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), str.ToString());
        }
        else if (n == 11)
        {
            spreadSheet.setAll(str.ToString(), newStr.ToString(), b);
            Console.WriteLine("User[{0}]: [{1}] setted all:{2} instances to {3}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), str.ToString(), newStr.ToString());
        }
        else
        {
            Tuple<int, int> t = spreadSheet.getSize();
            Console.WriteLine("User[{0}]: [{1}] got {2} as the size of the sheet", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString(), t.ToString());
        }
    }

}
