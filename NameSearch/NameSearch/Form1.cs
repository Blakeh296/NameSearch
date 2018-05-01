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
                StreamReader inputFile = File.OpenText("Names.csv");
                StreamWriter outputFile;
                
                // Input names into Names Array while counter is less than the number of items
                while (counter < namesArray.Length && !inputFile.EndOfStream)
                {
                    namesArray[counter] = inputFile.ReadLine();
                    counter++;
                }

                // Sort Array alphabetically 
                Array.Sort(namesArray);
                
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
                label1.Text = Time.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private int BinarySearch(string[] namesArray, int size, string value)
        {
            int first = 0;
            int last = namesArray.Length - 1;
            int middle;
            int position = -1;
            bool found = false;

            while (!found && first <= last)
            {
                middle = (first + last) / 2;
                if (namesArray[middle] == value)
                {
                    found = true;
                    position = middle;
                }
                else if (string.Compare(namesArray[middle], value, false) > 0)
                {
                    last = middle - 1;
                }
                else
                {
                    first = middle + 1;
                }

            }

            return position;

        }
        
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            

            try
            {
                string value = textBox1.Text;
                int position;
                string output;

                const int SIZE = 5000;
                string[] namesArray = new string[SIZE];
                StreamReader inputFile = File.OpenText("Names.csv");

                position = BinarySearch(namesArray, SIZE, value);

                output = namesArray[position];

                inputFile.Close();
                Array.Sort(namesArray);
                lbOutPut.Items.Add(output);
                /*
                foreach (string valuee in namesArray)
                {
                    lbOutPut.Items.Add(value);
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int counter = 0;

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
                Array.Sort(namesArray);

                // Assign the file name to a variable
                outputFile = File.CreateText("OutputNames.csv");

                // While index < Array length, output array elements to the file
                for (int index = 0; index < namesArray.Length; index++)
                {
                    outputFile.WriteLine(namesArray[index]);
                }

                // Close the file
                inputFile.Close();
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
                Array.Sort(namesArray);

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
                label1.Text = Time.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbOutPut.Items.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
        
    }

