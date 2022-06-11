using Microsoft.VisualBasic;

namespace SpreadsheetApp
{
    public partial class Form1 : Form
    {

        SharableSpreadSheet s;

        public Form1()
        {
            InitializeComponent();
            initGrid(20,20); 
        }

        public void initGrid(int rows,int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                spreadSheet.Columns.Add("", "");
            }
            for (int i = 0; i < rows; i++)
            {
                spreadSheet.Rows.Add();
            }

            s = new SharableSpreadSheet(rows, cols);
        }

        public void ClearGrid()
        {
            for (int i = 0; i < spreadSheet.Rows.Count; i++)
            {
                for (int j = 0; j < spreadSheet.Columns.Count; j++)
                {
                    spreadSheet[i, j].Value = "";
                }
            }
        }

        public void NewGrid(int rows, int cols)
        {
            int difference = 0;
            if (cols < spreadSheet.Columns.Count)
            {
                difference = spreadSheet.Columns.Count - cols;
                for (int i = 0; i < difference; i++)
                {
                    spreadSheet.Columns.RemoveAt(0);
                }
            }
            if (rows < spreadSheet.Rows.Count)
            {
                difference = spreadSheet.Rows.Count - rows;
                for (int i = 0; i < difference; i++)
                {
                    spreadSheet.Rows.RemoveAt(0);
                }
            }
            if (cols > spreadSheet.Columns.Count)
            {
                difference = cols - spreadSheet.Columns.Count;
                for (int i = 0; i < difference; i++)
                {
                    spreadSheet.Columns.Add("", "");
                }
            }
            if (rows > spreadSheet.Rows.Count)
            {
                difference = rows - spreadSheet.Rows.Count;
                for (int i = 0; i < difference; i++)
                {
                    spreadSheet.Rows.Add();
                }
            }


        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            
        }

        public void NewFileDialog()
        {
            int rows;
            int cols;
            string row = Microsoft.VisualBasic.Interaction.InputBox("Set rows", "New grid", "Please enter number of rows");
            if (int.TryParse(row, out rows) && rows >= 0)
            {
                string col = Microsoft.VisualBasic.Interaction.InputBox("Set columns", "New grid", "Please enter number of columns");
                if (int.TryParse(col, out cols) && cols >= 0)
                {
                    ClearGrid();
                    NewGrid(rows, cols);
                }
                else
                {
                    MessageBox.Show("Invalid number of columns");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid number of rows");
            }
        }

        public void SaveFileDialog()
        {
            StreamWriter myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != null && s != null)
                {
                    myStream = new StreamWriter(saveFileDialog1.FileName + ".txt");
                    // Code to write the stream goes here.
                    myStream.Write("Rows:{0}" + "\n", s.getRows());
                    myStream.Write("Cols:{0}" + "\n", s.getCols());
                    for (int i = 0; i < s.getRows(); i++)
                    {
                        for (int j = 0; j < s.getCols(); j++)
                        {
                            myStream.Write(s.getData()[i, j] + ",");
                        }
                        myStream.Write("\n");
                    }
                    myStream.Close();
                }
                else
                {
                    MessageBox.Show("Empty file not saved");
                }
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit without saving?", "New file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                NewFileDialog();

            }
            else if (dialogResult == DialogResult.No)
            {
                SaveFileDialog();
                NewFileDialog();
            }
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    s = new SharableSpreadSheet(10, 10);
                    bool isLoaded = false;
                    try
                    {
                        s.load(filePath);
                        isLoaded = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bad file");
                    }
                    //Load SpreadSheet to grid
                    if (isLoaded)
                    {
                        // setting the size of the file
                        ClearGrid();
                        int rows = s.getRows();
                        int cols = s.getCols();
                        NewGrid(rows, cols);
                        string[,] data = s.getData();
                        for (int i = 0; i < s.getRows(); i++)
                        {
                            for (int j = 0; j < s.getCols(); j++)
                            {
                                spreadSheet.Rows[i].Cells[j].Value = data[i, j];
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Bad File");
                }
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SpreadSheetApp made by Ariel Dawidowicz and Eitan Markman.\n This project was made for Operation systems course.");
        }

        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            s.addRow(s.getRows()-1);
            spreadSheet.Rows.Add();
        }

        private void AddColBtn_Click_1(object sender, EventArgs e)
        {
            s.addCol(s.getCols() - 1);
            spreadSheet.Columns.Add("", "");
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            int row;
            int col;
            string str = SearchTextBox.Text;
            bool caseSensitive = caseSensitiveCheckBox.Checked;

            if (str != "")
            {
                Tuple<int, int>[] tupleList = s.findAll(str, caseSensitive);
                spreadSheet.ClearSelection();
                for (int i = 0; i < tupleList.Length; i++)
                {
                    row = tupleList[i].Item1;
                    col = tupleList[i].Item2;
                    spreadSheet.Rows[row].Cells[col].Selected = true;
                }

                if(tupleList.Length == 0)
                {
                    MessageBox.Show(str + " Not found");
                }
                caseSensitiveCheckBox.Checked = false;
                SearchTextBox.Clear();
            }
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            int rowindex = spreadSheet.CurrentCell.RowIndex;
            int columnindex = spreadSheet.CurrentCell.ColumnIndex;
            string newStr = setTextBox.Text;

            Int32 selectedCellCount = spreadSheet.GetCellCount(DataGridViewElementStates.Selected);

            if (selectedCellCount > 1 && newStr != "")
            {
                for (int i = 0;i < selectedCellCount; i++)
                {
                    s.setCell(spreadSheet.SelectedCells[i].RowIndex, spreadSheet.SelectedCells[i].ColumnIndex, newStr);
                    spreadSheet.Rows[spreadSheet.SelectedCells[i].RowIndex].Cells[spreadSheet.SelectedCells[i].ColumnIndex].Value = newStr;
                }
                setTextBox.Clear();
            }
            else if(newStr != "" && rowindex != null && columnindex != null)
            {

                s.setCell(rowindex, columnindex, newStr);
                spreadSheet.Rows[rowindex].Cells[columnindex].Value = newStr;
                setTextBox.Clear();
            } 
        }

        private void GetBtn_Click(object sender, EventArgs e)
        {
            int row;
            int col;
            if (RowTextBox.Text == "" || ColTextBox.Text == "")
                MessageBox.Show("Please enter row number and column number");
            else if (!int.TryParse(RowTextBox.Text, out row))
            {
                MessageBox.Show("Please enter a valid row number");
            }
            else if(row < 0 || row > s.getRows())
            {
                MessageBox.Show("Please enter a valid row number");
            }
            else if (!int.TryParse(ColTextBox.Text, out col))
            {
                MessageBox.Show("Please enter a valid column number");
            }
            else if (col < 0 || col > s.getCols())
            {
                MessageBox.Show("Please enter a valid column number");
            }
            else
            {
                spreadSheet.ClearSelection();
                spreadSheet.Rows[row].Cells[col].Selected = true;
                MessageBox.Show("Row: " + row + ", Column: " + col + " Value: " + s.getCell(row,col) );
                RowTextBox.Clear();
                ColTextBox.Clear();
            }
        }

    }
};