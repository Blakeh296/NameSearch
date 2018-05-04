using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NameSearch
{
    public partial class Form1 : Form
    {
        // Array variables
        const int SIZE = 5000;
        string[] namesArray = new string[SIZE];

        // Take the names from the file
        StreamReader inputFile = File.OpenText("Names.csv");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int counter = 0;

            try
            {
                // Time variables 
                DateTime start = DateTime.Now;
                DateTime Finish;
                TimeSpan Time;

                // Just to be sure the label populates correctly
                if (radioButton1.Checked)
                {
                    label2.Text = "Type Anything";
                }
                else if (radioButton2.Checked)
                {
                    label2.Text = "Type Exact 'Last name, First name'";
                }
                
                // Input names into Names Array while counter is less than the number of items
                while (counter < namesArray.Length && !inputFile.EndOfStream)
                {
                    namesArray[counter] = inputFile.ReadLine();
                    counter++;
                }

                // Sort Array alphabetically 
                SelectionSort(namesArray);
                
                // Close file connection
                inputFile.Close();

                // Output Full Array to the list box
                foreach (string value in namesArray)
                {
                    lbOutPut.Items.Add(value);
                }

                // Save the time everything finished
                Finish = DateTime.Now;
                // Subtract the times to get the total time
                Time = Finish - start;
                // output time for the user

                // Code changes message based on how long it took to load
                if (Time.Seconds > 1)
                {
                    label1.Text = "Loaded " + SIZE + " Items in " + Time.Seconds.ToString() + " Seconds.";
                }
                else
                {
                    label1.Text = "Loaded " + SIZE + " Items in " + Time.Seconds.ToString() + " Second.";
                }

                
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //The Swap method accepts two integer arguments, by reference
        //and swaps there contents
        private void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        private int BinarySearch(string[] namesArray, string value)
        {
            // Declare variables
            int first = 0;
            int last = namesArray.Length - 1;
            int middle;
            int position = -1;
            bool found = false;

            // While not found and first is less than or equal to last
            while (!found && first <= last)
            {

                // Initialize my middle point
                middle = (first + last) / 2;

                // if value is found at mid point
                if (namesArray[middle] == value)
                {
                    found = true;
                    position = middle;
                }
                //Else if value is in lower half
                else if (string.Compare(namesArray[middle], value, false) > 0)
                {
                    last = middle - 1;
                }
                //Else if value is in upper half
                else
                {
                    first = middle + 1;
                }

            }

            return position;
        }

        private void SelectionSort(string[] namesArray)
        {
            int minIndex; //Subscript of smallest value in scanned area
            string minValue; //smallest value in the scanned area

            //The outter loop steps through all the array elements, Except the last one
            // The startscan variable marks the position where the scan should begin
            for (int startScan = 0; startScan < namesArray.Length - 1; startScan++)
            {
                //Assume the first element in the scannable area 
                //Is the smallest value
                minIndex = startScan;
                minValue = namesArray[startScan];

                //Scan the array, starting at the 2nd element in the 
                //Scannable area, looking for the smallest value.
                for (int index = startScan + 1; index < namesArray.Length; index++)
                {
                    if (string.Compare(minValue, namesArray[index], true) == 1)
                    {
                        minValue = namesArray[index];
                        minIndex = index;
                    }
                }

                //Swap the element with the smallest value with the
                // first element in the scannable area
                Swap(ref namesArray[minIndex], ref namesArray[startScan]);

            }
        }

            

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Variables
            DateTime First = DateTime.Now;
            DateTime Last;
            TimeSpan Time;

            try
            {
                // Array variables

                string txtPath = "CustomOutPutNames.csv";
                StreamWriter outputFile = new StreamWriter(txtPath);

                // write each item in listbox to output file
                foreach (string name in lbOutPut.Items)
                {
                    outputFile.WriteLine(name.ToString());
                }


                // Close the file
                inputFile.Close();

                Last = DateTime.Now;

                Time = Last - First;

                // Code changes message based on how the items took to export
                if (Time.Seconds > 1)
                {
                    label1.Text = "Exported " + lbOutPut.Items.Count + " Items in " + Time.Seconds.ToString() + " Seconds.";
                }
                else
                {
                    label1.Text = "Exported " + lbOutPut.Items.Count + " Items in " + Time.Seconds.ToString() + " Second.";
                }

                MessageBox.Show("Done !");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void loadAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int counter = 0;

            try
            {
                // Time variables 
                DateTime start = DateTime.Now;
                DateTime Finish;
                TimeSpan Time;
                // Array variables
                const int SIZE = 5000;
                string[] namesArray = new string[SIZE];
                StreamReader inputFile = File.OpenText("Names.csv");

                // Input names into Names Array while counter is less than the number of items
                while (counter < namesArray.Length && !inputFile.EndOfStream)
                {
                    namesArray[counter] = inputFile.ReadLine();
                    counter++;
                }

                // Sort Array alphabetically 
                SelectionSort(namesArray);

                // Close file connection
                inputFile.Close();

                // Output Full Array to the list box
                foreach (string value in namesArray)
                {
                    lbOutPut.Items.Add(value);
                }

                // Save the time everything finished
                Finish = DateTime.Now;
                // Subtract the times to get the total time
                Time = Finish - start;
                // output time for the user
                // Code changes message based on how long it took to load
                if (Time.Seconds > 1)
                {
                    label1.Text = "Loaded " + SIZE + " Items in " + Time.Seconds.ToString() + " Seconds.";
                }
                else
                {
                    label1.Text = "Loaded " + SIZE + " Items in " + Time.Seconds.ToString() + " Second.";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear list box
            lbOutPut.Items.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close Program
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    // Time variables
                    DateTime start = DateTime.Now;
                    DateTime Finish;
                    TimeSpan Time;

                    label2.Text = "Type Anything";
                    string search = textBox1.Text;
                    // Clears list box and prepares it to show results
                    lbOutPut.Items.Clear();
                    // Searches for the item in the array that contains the text from text box
                    lbOutPut.Items.AddRange(namesArray.Where(n => n.Contains(search)).ToArray());
                    //Time variables
                    Finish = DateTime.Now;
                    Time = Finish - start; string text = lbOutPut.GetItemText(lbOutPut.SelectedItem);
                    label1.Text = lbOutPut.Items.Count + " " + "found in" + " " + (Time.TotalSeconds.ToString()) + " " + "seconds";
                }
                else
                {
                    MessageBox.Show("Please check that 'Standard Search Option' is selected");
                }
                

            }
            catch
            { 
                MessageBox.Show("Unknown Error");
            }
        }



        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (radioButton2.Checked && e.KeyCode == Keys.Enter)
                {
                    //Time variables
                        DateTime start = DateTime.Now;
                    DateTime Finish;
                    TimeSpan Time;

                    
                    // Get the search item
                    string SearchObject = textBox2.Text;

                    // Perform binary search with the search object
                    int position = BinarySearch(namesArray, SearchObject);

                    // create a bool to use later
                    bool found = namesArray.Contains(SearchObject);

                    lbOutPut.SetSelected(position, true);
                    // if the binary search is unsuccessful
                    if (found == false)
                    {
                        MessageBox.Show("This name could not be found");
                    }
                    else
                    {
                        // finish calculation
                        Finish = DateTime.Now;
                        Time = Finish - start;

                        // Move selected item to the searched item
                        lbOutPut.SetSelected(position, true);

                        // declare a string to use later
                        string text = lbOutPut.GetItemText(lbOutPut.SelectedItem);

                        // Communicate to the user
                        label1.Text = text + " Found at location " + position + " in " + (Time.TotalSeconds.ToString()) + " Seconds";

                        // Communicate to the user
                        textBox2.Text = "Type and press enter";
                    }
                }


            }
            catch
            {
                MessageBox.Show("String must be exact");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Type Exact 'Last name, First name'";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Type Anything";
        }

        private void immersiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
  
            radioButton2.Visible = false;
            textBox2.Visible = false;
            btnClear.Visible = false;
            lbOutPut.Location = new Point(17, 118);
            lbOutPut.Size = new Size(297, 202);

        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton2.Visible = true;
            textBox2.Visible = true;
            btnClear.Visible = true;
            btnClear.Location = new Point(225, 218);
            lbOutPut.Location = new Point(14, 155);
            lbOutPut.Size = new Size(191, 148);

        }
    }
        
    }

