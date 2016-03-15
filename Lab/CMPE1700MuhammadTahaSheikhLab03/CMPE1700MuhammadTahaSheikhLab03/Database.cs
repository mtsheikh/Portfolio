/************************************************************
 * Program:     Database.cs
 * Description: Creates an editable database from given files
 *              that a user can search through
 * Date:        April. 16/2015
 * Author:      Muhammad Taha Sheikh
 * Class:       CNT 17000
 * Section:     A02
 ***********************************************************/
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE1700MuhammadTahaSheikhLab03
{
    class Database
    {
        // The mark structure which contains the value, out of and weight
        // variable
        private struct Mark
        {
            public double _value;
            public double _outOf;
            public double _weight;

            public Mark(double value, double outOf, double weight)
            {
                _value = value;
                _outOf = outOf;
                _weight = weight;
            }
        }
        // The student structure which contains the first name, last name 
        // and student ID which writes with the right format to the console
        private struct Student
        {
            public string _firstName;
            public string _lastName;
            public string _studentId;
            public double _marks;

            public Student(string firstName, string lastName, string studentId, double marks)
            {
                _firstName = firstName;
                _lastName = lastName;
                _studentId = studentId;
                _marks = marks;
            }
            public override string ToString()
            {
                return _lastName + ", " + _firstName + " = " + _studentId + " GPA: " + _marks;
            }
        }
        /*********************************************************************
         * Method:     static private void Menu(string records)
         * Purpose:    This method displays the menu to the Console
         * Parameters: string records - the times there was a student added to
         *             the database in a single run 
         * Returns:    Nothing
         *********************************************************************/
        static private void Menu(int records)
        {
            Console.WriteLine(records + " student records stored");
            Console.WriteLine("A - Add new student");
            Console.WriteLine("M - Add new mark");
            Console.WriteLine("L - List all records (alphabetical order)");
            Console.WriteLine("S - Search by Student ID");
            Console.WriteLine("N - Search by Last Name");
            Console.WriteLine("Q - Quit");
            Console.WriteLine("X - Quit and save to disk\n");
            Console.Write("Your choice: ");
        }
        /*********************************************************************
         * Method:     static private double Calculation(double outof, 
         *             double weight, double value)
         * Purpose:    This method calculates the marks 
         * Parameters: outof - the marks our of 
         *             weight - the weight of the marks
         *             value - the marks gotten
         * Returns:    the final calculation 
         *********************************************************************/
        static private double Calculation(double outof, double weight, double value)
        { return Math.Truncate((value / outof) * weight * 100); }

        static void Main(string[] args)
        {
            StreamWriter swOutputFile;      // Writing to the file variable
            int records = 0;                // Variable to keep track of amount of tiems a student is added
            StreamReader srInputFile;       // Reading from the file variable 
            string userMenuchc = "";        // Variable to store user's choice about the menu
            bool quit = false;              // Stores the decision about quiting or not the program
            double marks = 0;               // Stores the marks for student
            string sentence = "";           // Stores the output from the files
            // Contains the infromation from the student Struct and student Id as Key
            Dictionary<string, Student> myDict = new Dictionary<string, Student>();
            // Contains the infromation from the Mark Struct and student Id as Key
            Dictionary<string, Mark> myMarkDict = new Dictionary<string, Mark>();
            // Contains the alphabetical order to populate the database with
            List<string> alphaSortList = new List<string>();
            // This variable stores the file path for the files to be used
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Open the File marks.txt
            srInputFile = new StreamReader(filepath + "\\marks.txt");
            // As lnog as all the lines in the file has been read
            while (srInputFile.Peek() > -1)
            {
                // store the line in sentence variable
                sentence = srInputFile.ReadLine();
                // split the sentence into string list with each number
                string[] split = sentence.Split(new Char[] { ' ' });
                // populate the mark structure with the corresponding values 
                Mark mark = new Mark(double.Parse(split[1]), double.Parse(split[2]), double.Parse(split[3]));
                // add the Marks in the myMarkDict Dictionary with the corresponding student ID
                myMarkDict.Add(split[0], mark);
            }
            //Close the file marks.txt
            srInputFile.Close();
            //Open the file students.txt
            srInputFile = new StreamReader(filepath + "\\students.txt");
            // As lnog as all the lines in the file has been read
            while (srInputFile.Peek() > -1)
            {
                // store the line in sentence variable
                sentence = srInputFile.ReadLine();
                // split the sentence into string list with each number
                string[] split = sentence.Split(new Char[] { ' ', ',' });
                // populate the mark structure with the corresponding values 
                // Calaculate the marks based on the values in the mark structure
                marks = Calculation(myMarkDict[split[3]]._outOf, myMarkDict[split[3]]._weight
                    , myMarkDict[split[3]]._value);
                Student student = new Student(split[2], split[0], split[3], marks);
                alphaSortList.Add(student._lastName);
                // if this key already exists in the dictionary
                if (myDict.ContainsKey(student._studentId) == true)
                {
                    // Replaces the value of the Key of the old one with the 
                    // new one
                    myDict.Remove(student._studentId);
                    myDict.Add(student._studentId, student);
                }
                else
                {
                    // add to the Dictionary myDict
                    myDict.Add(student._studentId, student);
                }
            }
            // Close the File students.txt
            srInputFile.Close();
            // Clear the Console
            Console.Clear();
            // Keep on repeating till the user decides to quit
            do
            {
                // Display the Menu
                Menu(records);
                // store user's decision in the userMenuchc variable
                userMenuchc = Console.ReadLine();
                Console.WriteLine("");
                // Based on the userchoice do one of the 7 options from the menu
                switch (userMenuchc.ToLower())
                {
                    // if the user chooses x (Save and Exit)
                    case "x":
                        // open students.txt to write to it
                        swOutputFile = new StreamWriter(filepath + "\\students.txt");
                        // as long as the dictionary's end has not reached
                        foreach (KeyValuePair<string, Student> pair in myDict)
                        {
                            // write to the file in the appropiate format
                            swOutputFile.WriteLine(pair.Value._lastName + ", " + pair.Value._firstName + " "
                                + pair.Key);
                        }
                        // Close the students.txt file
                        swOutputFile.Close();
                        // open marks.txt to write to it
                        swOutputFile = new StreamWriter(filepath + "\\marks.txt");
                        // as long as the dictionary's end has not reached
                        foreach (KeyValuePair<string, Mark> pair in myMarkDict)
                        {
                            // write to the file in the appropiate format
                            swOutputFile.WriteLine(pair.Key + " " + pair.Value._value +
                                " " + pair.Value._outOf + " " + pair.Value._weight);
                        }
                        // CLose the marks.txt file
                        swOutputFile.Close();
                        // make quit true so you can exit the Do while loop
                        quit = true;
                        // Clear the Console
                        Console.Clear();
                        //Exit the Loop
                        break;
                    // if the user chooses a (Add a new Student)
                    case "a":
                        string fullName = "";                      // stores the user given FullName
                        string corForLName = "";                   // stores last name in the correct format
                        string studentId = "";                     // stores the user given StudentID                                                      
                        // Ask the user for student's Full name and store it in fullName variable
                        Console.Write("Enter the Full Name of the Student(First Name, Last Name): ");
                        fullName = Console.ReadLine();
                        // Ask the user for student's ID and store it in the studentId variable
                        Console.Write("Enter the StudentId of the Student(Numeric value 8 characters): ");
                        studentId = Console.ReadLine();
                        // create a string array and fill the array with first Name and last Name
                        string[] split2 = fullName.Split(new Char[] { ' ' });
                        // This section converts the user supplied student name in the appropiate format 
                        corForLName = split2[0][0].ToString().ToUpper();
                        for (int i = 1; i < split2[0].Length; i++)
                        {
                            corForLName += split2[0][i].ToString().ToLower();
                        }
                        // Populate the student struct with the user given info and put in 0 for GPA
                        Student student = new Student(split2[1], corForLName, studentId, 0.0);
                        // store the Last name in the sorter list
                        alphaSortList.Add(student._lastName);
                        // if this key already exists in the dictionary
                        if (myDict.ContainsKey(student._studentId) == true)
                        {
                            // Replaces the value of the Key of the old one with the new one
                            myDict.Remove(student._studentId);
                            myDict.Add(student._studentId, student);
                            records++;
                        }
                        else
                        {
                            // add to the Dictionary myDict
                            myDict.Add(student._studentId, student);
                            records++;
                        }
                        // Display the exit Message
                        Console.Write("Press any key to continue...");
                        Console.ReadKey(true);
                        // Clear the Console
                        Console.Clear();
                        // exit the loop
                        break;
                    // if the user chooses m (Adding mark using student Id)
                    case "m":
                        bool fail = true;                       // Error message flag
                        bool sucfulInput = false;               // successful Input flag
                        string Id = "";                         // stores the user given student ID
                        // This do while repeats until the user inputs an appropiate student ID
                        do
                        {
                            // Clear the Console
                            Console.Clear();
                            // Display the Menu
                            Menu(records);
                            // Ask the user for Student ID and store it in the Id variable
                            Console.Write("\n\nEnter the student id of the Student to add the marks to: ");
                            Id = Console.ReadLine();
                            // as long as the end of dictioanry has not reached
                            foreach (KeyValuePair<string, Student> pair in myDict)
                            {
                                // if user given Id matches the student ID records
                                if (Id == pair.Key)
                                {
                                    // then exit the loop and don't display the error message
                                    fail = false;
                                    sucfulInput = true;
                                }
                            }
                            // if the student Id doesn't exist 
                            if (fail)
                            {
                                // Display error message
                                Console.WriteLine("This student id doesn't exist in this directory");
                                Console.WriteLine("Press any key tp continue...");
                                Console.ReadKey(true);
                            }
                        } while (!sucfulInput);
                        // ask the user for the student's mark and store it in the newMark variable
                        Console.Write("Enter the Mark for this Student: ");
                        double newMark = double.Parse(Console.ReadLine());
                        // ask the user for the student's mark's out of and store it in the newMark variable
                        Console.Write("Enter how much it is out of for this Student: ");
                        double newMarkof = double.Parse(Console.ReadLine());
                        // ask the user for the student's mark's weight and store it in the newMarkwgt variable
                        Console.Write("Enter the weight of this mark for this Student: ");
                        double newMarkwgt = double.Parse(Console.ReadLine());
                        Mark newMarks = new Mark(newMark, newMarkof, newMarkwgt);
                        double GPA = Calculation(newMarkof, newMarkwgt, newMark);
                        // populate the structure with the pre given name but put in the new mark
                        Student newStudent = new Student(myDict[Id]._firstName, myDict[Id]._lastName, Id, GPA);
                        // Exchange the List and dictionary with the new student structure formed from the old one
                        alphaSortList.Remove(myDict[Id]._lastName);
                        alphaSortList.Add(myDict[Id]._lastName);
                        myDict.Remove(Id);
                        myDict.Add(Id, newStudent);
                        // Exchange the dictionary with the new Mark structure formed from the old one
                        myMarkDict.Remove(Id);
                        myMarkDict.Add(Id, newMarks);
                        // Display the exit Message
                        Console.Write("Press any key to continue...");
                        Console.ReadKey(true);
                        // Clear the Console
                        Console.Clear();
                        // exit the loop
                        break;
                    // if the user chooses q (Quit without saving)
                    case "q":
                        string choice = "";                        // the user choice about quiting
                        // store the decision about quiting choice in the variable choice
                        Console.Write("Are you sure you want to exit without saving? press y for YES: ");
                        choice = Console.ReadLine();
                        // if the user presses y then exit the loop and close the program
                        quit = choice.ToLower().Trim() == "y" ? true : false;
                        // Clear the Console
                        Console.Clear();
                        // Exit the Loop
                        break;
                    // If the user chooses n (Search for the student by their last name)
                    case "n":
                        fail = true;                       // Error message flag
                        sucfulInput = false;               // successful Input flag
                        // keep on repeating this till you get a successful lastname that is in directory
                        do
                        {
                            // Clear the Console
                            Console.Clear();
                            // Display the Menu
                            Menu(records);
                            // ask the user for the student's last name and store it in the userName variable
                            Console.Write("\n\nEnter the Last Name of the Student to Search: ");
                            string userName = "";           // To store lastname provided by the user
                            userName = Console.ReadLine();

                            string corForName = "";         // To store the correct format for username 
                            // This section converts the user supplied student name in the appropiate format 
                            corForName = userName[0].ToString().ToUpper();
                            for (int i = 1; i < userName.Length; i++)
                            {
                                corForName += userName[i].ToString().ToLower();
                            }
                            // for every single value in myDict
                            foreach (KeyValuePair<string, Student> pair in myDict)
                            {
                                // if the user provided last name matches the last name in myDict
                                if (pair.Value._lastName == corForName)
                                {
                                    // Write the Value out to the console and exit the loop
                                    Console.WriteLine(pair.Value);
                                    fail = false;
                                    sucfulInput = true;
                                }
                            }
                            // if there were no matches then ask for it again
                            if (fail) { Console.WriteLine("This student last name doesn't exist in this directory"); }
                            // Display continuing message 
                            Console.Write("Press any key to continue...");
                            Console.ReadKey(true);
                        } while (!sucfulInput);
                        // Clear Console
                        Console.Clear();
                        // set to defaults
                        fail = false;
                        // Exit the loop
                        break;
                    // If the user chooses l (List all values in the dictionary in an alphabetical order)
                    case "l":
                        // convert the alphaSortList to a string array
                        string[] cells = alphaSortList.ToArray();
                        // sort the string array alphabetically
                        Array.Sort<string>(cells);
                        // as long as the string array has not reached its end
                        for (int i = 0; i < cells.Length; i++)
                        {
                            // as long as myDict has not reached its end
                            foreach (var item in myDict)
                            {
                                // if the last name value in dictionary matches the string at that index
                                if (cells[i] == item.Value._lastName)
                                {
                                    // Write the value in the Console
                                    Console.WriteLine(item.Value);
                                }
                            }
                        }
                        // Display Continuing message
                        Console.Write("Press any key to continue...");
                        Console.ReadKey(true);
                        // Clear the Console
                        Console.Clear();
                        // Exit the loop
                        break;
                    // if the user choose s (Searching via Student ID)
                    case "s":
                        // set all variables to default
                        sucfulInput = false;
                        Id = "";
                        fail = true;
                        // do this unless you find an appropiate user input
                        do
                        {
                            // Clear the Console
                            Console.Clear();
                            // Display the Menu
                            Menu(records);
                            // Asks the user to enter a student ID then stores it in ID
                            Console.Write("\n\nEnter the student id of the Student to Search: ");
                            Id = Console.ReadLine();
                            // as long as the end of myDIct has not reached
                            foreach (KeyValuePair<string, Student> pair in myDict)
                            {
                                // if ID matches the key of myDict
                                if (Id == pair.Key)
                                {
                                    // Write the Value at the Key to the console
                                    Console.WriteLine(pair.Value);
                                    fail = false;
                                    sucfulInput = true;
                                }
                            }
                            // if there is no match then output the error message and get them to try again
                            if (fail) { Console.WriteLine("This student id doesn't exist in this directory"); }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey(true);
                        } while (!sucfulInput);
                        // Clear the Console
                        Console.Clear();
                        fail = false;
                        break;
                    // if the user chooses an unavailable option 
                    default:
                        // Display Error and Exit Message
                        Console.WriteLine("Choose from the options above");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey(true);
                        // Clear the Console
                        Console.Clear();
                        // Exit the Loop
                        break;
                }
                // As Long as the user doesn't choose to quit
            } while (!quit);
        }
    }
}
