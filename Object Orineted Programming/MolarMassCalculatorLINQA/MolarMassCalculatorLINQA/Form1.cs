// Brett Kueber - kueber1@ualberta.ca
// Layne Love - deavle2@gmail.com
// Gabe Natividad - gnatividad2@studentmail.nait.ca
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace MolarMassCalculatorLINQA
{
    public partial class Form1 : Form
    {
        // BINDING SOURCE
        BindingSource bSource = new BindingSource();
        
        //LIST OF ELEMENTS
        List<Element> AllTheElements = new List<Element>();

        //DICTIONARY OF USER'S MOLECULE
        Dictionary<string, int> myDict = new Dictionary<string, int>(); //key is element symbol, value is number of that element in the formula

        public Form1()
        {
            InitializeComponent();
            PopElements();

            DGV_Elements.DataSource = bSource; 

            AllTheElements.ForEach(x => myDict.Add(x.symbol, 1));
            ShowElementCounts();
        }
        
        private void PopElements()
        {
            AllTheElements.Add(new Element("H", "Hydrogen", 1, 1.008));
            AllTheElements.Add(new Element("He", "Helium", 2, 4.003));
            AllTheElements.Add(new Element("Li", "Lithium", 3, 6.941));
            AllTheElements.Add(new Element("Be", "Beryllium", 4, 9.012));
            AllTheElements.Add(new Element("B", "Boron", 5, 10.811));
            AllTheElements.Add(new Element("C", "Carbon", 6, 12.011));
            AllTheElements.Add(new Element("N", "Nitrogen", 7, 14.007));
            AllTheElements.Add(new Element("O", "Oxygen", 8, 15.999));
            AllTheElements.Add(new Element("F", "Fluorine", 9, 18.998));
            AllTheElements.Add(new Element("Ne", "Neon", 10, 20.180));
            AllTheElements.Add(new Element("Na", "Sodium", 11, 22.990));
            AllTheElements.Add(new Element("Mg", "Magnesium", 12, 24.305));
            AllTheElements.Add(new Element("Al", "Aluminum", 13, 26.982));
            AllTheElements.Add(new Element("Si", "Silicon", 14, 28.086));
            AllTheElements.Add(new Element("P", "Phosphorus", 15, 30.974));
            AllTheElements.Add(new Element("S", "Sulfur", 16, 32.066));
            AllTheElements.Add(new Element("Cl", "Clorine",17 , 35.453));
            AllTheElements.Add(new Element("Ar", "Argon", 18, 39.948));
            AllTheElements.Add(new Element("K", "Potassium",19 ,39.098));
            AllTheElements.Add(new Element("Ca", "Calcium", 20, 40.078));
            AllTheElements.Add(new Element("SC", "Scandium", 21, 44.956));
            AllTheElements.Add(new Element("Ti", "Titanium", 22, 47.867));
            AllTheElements.Add(new Element("V", "Vanadium", 23, 50.942));
            AllTheElements.Add(new Element("Cr", "Chromium", 24, 51.996));
            AllTheElements.Add(new Element("Mn", "Manganese", 25, 54.938));
            AllTheElements.Add(new Element("Fe", "Iron", 26, 55.845));
            AllTheElements.Add(new Element("Co", "Cobalt", 27, 58.933));
            AllTheElements.Add(new Element("Ni", "Nickel", 28, 58.693));
            AllTheElements.Add(new Element("Cu", "Copper", 29, 63.546));
            AllTheElements.Add(new Element("Zn", "Zinc", 30, 65.38));
            AllTheElements.Add(new Element("Ga", "Gallium", 31, 69.723));
            AllTheElements.Add(new Element("Ge", "Germanium", 32, 72.631));
            AllTheElements.Add(new Element("As", "Arsenic", 33, 74.922));
            AllTheElements.Add(new Element("Se", "Selenium", 34, 78.971));
            AllTheElements.Add(new Element("Br", "Bromine", 35, 79.904));
            AllTheElements.Add(new Element("Kr", "Krypton", 36, 84.798));
            AllTheElements.Add(new Element("Rb", "Rubidium", 37, 84.468));
            AllTheElements.Add(new Element("Sr", "Strontium", 38,87.62));
            AllTheElements.Add(new Element("Y", "Yttrium", 39, 88.906));
            AllTheElements.Add(new Element("Zr", "Zirconiu,", 40, 91.224));
            AllTheElements.Add(new Element("Nb", "Niobium", 41, 92.906));
            AllTheElements.Add(new Element("Mo", "Molybdenum", 42, 95.95));
            AllTheElements.Add(new Element("Tc", "Technetium", 43, 98.907));
            AllTheElements.Add(new Element("Ru", "Ruthenium", 44, 101.07));
            AllTheElements.Add(new Element("Rh", "Rhodium", 45, 102.906));
            AllTheElements.Add(new Element("Pd", "Palladium", 46, 106.42));
            AllTheElements.Add(new Element("Ag", "Silver", 47, 107.868));
            AllTheElements.Add(new Element("Cd", "Cadmium", 48, 112.411));
            AllTheElements.Add(new Element("In", "Indium", 49, 114.818));
            AllTheElements.Add(new Element("Sn", "Tin", 50, 118.711));
            AllTheElements.Add(new Element("Sb", "Antimony", 51, 121.760));
            AllTheElements.Add(new Element("Te", "Tellurium", 52, 127.6));
            AllTheElements.Add(new Element("I", "Iodine", 53, 126.904));
            AllTheElements.Add(new Element("Xe", "Xenon", 54, 131.294));
            AllTheElements.Add(new Element("Cs", "Cesium", 55, 132.905));
            AllTheElements.Add(new Element("Ba", "Barium", 56, 137.328));
            AllTheElements.Add(new Element("La", "Lanthanum", 57, 138.905));
            AllTheElements.Add(new Element("Ce", "Cerium", 58, 140.116));
            AllTheElements.Add(new Element("Pr", "Praseodymium", 59, 140.908));
            AllTheElements.Add(new Element("Nd", "Neodymium", 60, 144.243));
            AllTheElements.Add(new Element("Pm", "Promethium", 61, 144.913));
            AllTheElements.Add(new Element("Sm", "Samarium", 62, 150.36));
            AllTheElements.Add(new Element("Eu", "Europium", 63, 151.964));
            AllTheElements.Add(new Element("Gd", "Gadolinium", 64, 157.25));
            AllTheElements.Add(new Element("Tb", "Terbium", 65, 158.925));
            AllTheElements.Add(new Element("Dy", "Dysprosium", 66, 162.5));
            AllTheElements.Add(new Element("Ho", "Holmium", 67, 164.93));
            AllTheElements.Add(new Element("Er", "Erbium", 68, 167.259));
            AllTheElements.Add(new Element("Tm", "Thulium", 69, 168.934));
            AllTheElements.Add(new Element("Yb", "Ytterbium", 70, 173.055));
            AllTheElements.Add(new Element("Lu", "Lutetium", 71, 174.967));
            AllTheElements.Add(new Element("Hf", "Hafnium", 72, 178.49));
            AllTheElements.Add(new Element("Ta", "Tantalum", 73, 180.948));
            AllTheElements.Add(new Element("W", "Tungsten", 74, 183.84));
            AllTheElements.Add(new Element("Re", "Rhenium", 75, 186.207));
            AllTheElements.Add(new Element("Os", "Osmium", 76, 190.23));
            AllTheElements.Add(new Element("Ir", "Iridium", 77, 192.217));
            AllTheElements.Add(new Element("Pt", "Platinum", 78, 195.085));
            AllTheElements.Add(new Element("Au", "Gold", 79, 196.967));
            AllTheElements.Add(new Element("Hg", "Murcury", 80, 200.592));
            AllTheElements.Add(new Element("Tl", "Thallium", 81, 204.383));
            AllTheElements.Add(new Element("Pb", "Lead", 82, 207.2));
            AllTheElements.Add(new Element("Bi", "Bismuth", 83, 208.980));
            AllTheElements.Add(new Element("Po", "Polonium", 84, 208.982));
            AllTheElements.Add(new Element("At", "Astatine", 85, 209.987));
            AllTheElements.Add(new Element("Rn", "Radon", 86, 222.018));
            AllTheElements.Add(new Element("Fr", "Francium", 87, 223.020));
            AllTheElements.Add(new Element("Ra", "Radium", 88, 226.025));
            AllTheElements.Add(new Element("Ac", "Actinium", 89, 227.028));
            AllTheElements.Add(new Element("Th", "Thorium", 90, 232.038));
            AllTheElements.Add(new Element("Pa", "Protactinium", 91, 231.036));
            AllTheElements.Add(new Element("U", "Uranium", 92, 238.029));
            AllTheElements.Add(new Element("Np", "Neptunium", 93, 237.048));
            AllTheElements.Add(new Element("Pu", "Plutonium", 94, 244.064));
            AllTheElements.Add(new Element("Am", "Americium", 95, 243.061));
            AllTheElements.Add(new Element("Cm", "Curium", 96, 247.070));
            AllTheElements.Add(new Element("Bk", "Berkelium", 97, 247.070));
            AllTheElements.Add(new Element("Cf", "Californium", 98, 251.080));
            AllTheElements.Add(new Element("Es", "Einsteinium", 99, 254.0));
        }

        // ----------------------------------------------------------
        // METHOD:  ShowElementCounts
        // DESCR:   Updates the grid view with the user's created 
        //          molecule via a binding source. Binding source is 
        //          set to contain an anonymous type.
        // ----------------------------------------------------------
        private void ShowElementCounts()
        {
            bSource.DataSource = from kvp in myDict
            select new
            {
                Element = AllTheElements.Find((x) => x.symbol == kvp.Key).Name,
                Count = kvp.Value,
                Mass = AllTheElements.Find((x) => x.symbol == kvp.Key).AM,
                TotalMass = kvp.Value * AllTheElements.Find((x) => x.symbol == kvp.Key).AM
            };
        }

        //Gabe's additions: BuildChems, DatMass, Text_Changed event: DON'T TOUCH ANYTHING! Esp not the names.
        // WELL DONE HOLY
        private bool BuildChems(string input)
        {
            bool happy = true;
            string elementRegexCheck = "([A-Z][a-z]*)([0-9]*)";
            //[A-Z] = first char has to be capital alphabet (must appear exactly once - note the lack of * or + beside it)
            //[a-z] = char following must be lowercase
            // * = the condition before ([a-z] in this case) can appear zero or more times, ie lowercase char is optional
            //[0-9] = char following must be a number, again, * is there because a number is optional.
            string cheese = "^(" + elementRegexCheck + ")+$";
            // ^ = the match must start at the beginning of the string/line
            // + = matches the previous element (the elementRegexCheck pattern in this case) one or more times.
            // $ = match must be at the end of the string or before the end of the line

            if (!Regex.IsMatch(input, cheese)) return !happy;//Get out and fix your input coz it's invalid :(

            //All good?
            myDict.Clear(); 
            //Reading the whole string again means clearing the existing dictionary. 
            //Avoids adding "H" and "He" when you only put in "He"

            foreach (Match box20 in Regex.Matches(input, elementRegexCheck))
            {
                //find all text with valid format
                string G = box20.Groups[1].Value;
                int oxicated = box20.Groups[2].Value == "" ? 1 : int.Parse(box20.Groups[2].Value);//Number beside the element? No - count = 1, Yes - count = number
                Element Zero = AllTheElements.Find(Waldo => Waldo.symbol == G);//format correct. Does the element exist?
                if (Zero == null) return !happy;//no it doesn't exist
                //yes it does? Is it already accounted for?
                if (myDict.Keys.Contains(G))
                    myDict[G] += oxicated;
                else
                    myDict.Add(G, oxicated);

            }
            return happy;
        }
        private void ChemsBox_TextChanged(object sender, EventArgs e)
        {
            bool dozer = BuildChems(ChemsBox.Text); 
            ChemsBox.BackColor = dozer ? Color.Green : Color.Red; //Good input? Green is Good. Red is dead.
            if (!dozer) return; //Get out. Check yo self b4 u wreck my methods
            ShowElementCounts();
            MolarMBox.Text = DatMass().ToString("N2");
        }
        private double DatMass() //method to return dat molar mass
        {
            //prepare for trouble
            //and make it double...

            double trouble = 0;
            foreach (KeyValuePair<string,int> kvp in myDict)
            {
                Element ary = AllTheElements.Find(Gabe => Gabe.symbol == kvp.Key);
                trouble += ary.AM * kvp.Value; //Total MM = elemental atomic mass (in g/mol) * number of occurrences
            }
            return trouble;
        }
        //End of Gabe's additions;

        private void _BSortByName_Click(object sender, EventArgs e)
        {
            var _sortName = from n in AllTheElements
                            orderby n.Name
                            select n;
            _sortName.ToList().ForEach((o) => Console.WriteLine(
                o.Name.ToString()));           
        }

        private void _BSingleChar_Click(object sender, EventArgs e)
        {
            var _singleChar = from c in AllTheElements
                              orderby c.Name
                              orderby c.symbol.Length
                              select c;
                              
                              // I THINK THIS WORKS :D      -BK
                              //select new
                              //{
                                  //AtomicNumber = c.AN,
                                  //Name = c.Name,
                                  //Symbol = c.symbol,
                                  //Mass = c.AM
                              //};

            //bSource.DataSource = _singleChar;

            _singleChar.ToList().ForEach((o) => Console.WriteLine(
                    o.Name.ToString() + " || " + o.symbol.ToString()));
        }

        private void _BSortByAtomic_Click(object sender, EventArgs e)
        {
            var _sortAtomic = from a in AllTheElements
                              orderby a.AN
                              select a;
            _sortAtomic.ToList().ForEach((o) => Console.WriteLine(
                    o.Name.ToString() + " || " + o.AN.ToString()));
        }

        
    }
}
