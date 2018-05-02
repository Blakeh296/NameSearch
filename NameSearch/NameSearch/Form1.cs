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

                // Array variables
                const int SIZE = 5000;
                string[] namesArray = new string[SIZE];

                // Take the names from the file
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
                else if (string.Compare(namesArray[middle], value, false) == 1)
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

        private void btnNameSearch_Click_1(object sender, EventArgs e)
        {
            DateTime Start = DateTime.Now;
            DateTime Finish;
            TimeSpan Time;
            int counter = 0;

            try
            {
                // Declare Variables
                string value = textBox1.Text;
                int position;
                string output;

                // Constant for Array
                const int SIZE = 5000;

                // Array declaration
                string[] namesArray = new string[SIZE];

                // Open file
                StreamReader inputFile = File.OpenText("Names.csv");

                // Input names into Names Array while counter is less than the number of items
                while (counter < namesArray.Length && !inputFile.EndOfStream)
                {
                    namesArray[counter] = inputFile.ReadLine();
                    counter++;
                }
                // Perform Selection sort
                SelectionSort(namesArray);

                // Use position variable to perform BinarySearch, with the Array and TextBox String
                position = BinarySearch(namesArray, value);

                // Close the file
                inputFile.Close();

                Finish = DateTime.Now;

                Time = Finish - Start;

                // Clear the Listbox
                lbOutPut.Items.Clear();
                // Output position to list box
                lbOutPut.Items.Add("Found : " + value.ToString());
                // display the time this took in the Label

                // Code changes message based on how long it took to load
                if (Time.Seconds > 1)
                {
                    label1.Text = Time.Seconds.ToString() + " Seconds.";
                }
                else
                {
                    label1.Text = Time.Seconds.ToString() + " Second.";
                }

                MessageBox.Show("Found !");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int counter = 0;
            DateTime First = DateTime.Now;
            DateTime Last;
            TimeSpan Time;

            try
            {
                // Array variables
                const int SIZE = 5000;
                string[] namesArray = new string[SIZE];
                StreamReader inputFile = File.OpenText("Names.csv");
                StreamWriter outputFile;

                // Input names into Names Array while counter is less than the number of items
                while (counter < namesArray.Length && !inputFile.EndOfStream)
                {
                    namesArray[counter] = inputFile.ReadLine();
                    counter++;
                }

                // Sort Array alphabetically 
                SelectionSort(namesArray);

                // Assign the file name to a variable
                outputFile = File.CreateText("OutputNames.csv");

                // While index < Array length, output array elements to the file
                for (int index = 0; index < namesArray.Length; index++)
                {
                    outputFile.WriteLine(namesArray[index]);
                }

                // Close the file
                inputFile.Close();

                Last = DateTime.Now;

                Time = Last - First;

                // Code changes message based on how the items took to export
                if (Time.Seconds > 1)
                {
                    label1.Text = "Exported " + SIZE + " Items in " + Time.Seconds.ToString() + " Seconds.";
                }
                else
                {
                    label1.Text = "Exported " + SIZE + " Items in " + Time.Seconds.ToString() + " Second.";
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

        
    }
        
    }

