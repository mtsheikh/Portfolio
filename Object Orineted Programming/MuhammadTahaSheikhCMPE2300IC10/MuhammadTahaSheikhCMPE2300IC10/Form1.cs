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

namespace MuhammadTahaSheikhCMPE2300IC10
{
    public partial class Form1 : Form
    {
        SortedDictionary<string, int> myDict = new SortedDictionary<string, int>();
        string path = @"C:\Users\msheikh11\Desktop\MuhammadTahaSheikhCMPE2300IC10\Keywords.txt";
        List<string> myListOfWords = new List<string>();
        List<string> input;
        public Form1()
        {
            InitializeComponent();
            input = File.ReadLines(path).ToList();
            foreach (string sentence in input)
            {
                List<string> mySentence = sentence.Split(' ', '(', ')', ';', '=', ',', '.', '{', '}').ToList();
                foreach (string word in mySentence)
                {
                    if (word != "")
                        myListOfWords.Add(word);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ShowDictionary()
        {
            lv_box.Items.Clear();
            foreach (KeyValuePair<string, int> item in myDict)
            {
                lv_box.Items.Add(item.Key).SubItems.Add(item.Value.ToString());
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            ofdFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            DialogResult dr = ofdFile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                myDict.Clear();
                List<string> userListOfWords = File.ReadLines(ofdFile.FileName).ToList();
                foreach (string sentence in userListOfWords)
                {
                    List<string> words = sentence.Split(' ', '(', ')', ';', '=', ',', '.', '{', '}').ToList();
                    foreach (string word in words)
                    {
                        if (myListOfWords.Contains(word))
                        {
                            if (myDict.ContainsKey(word))
                            {
                                int value;
                                myDict.TryGetValue(word, out value);
                                value++;
                                string key = word;
                                myDict.Remove(word);
                                myDict.Add(key, value);
                            }
                            else
                            {
                                myDict.Add(word, 1);
                            }
                        }
                    }
                }
            }
            ShowDictionary();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e.KeyChar == Keys.Add)
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                // This gets every key in the dictionary, and than if the key value is less than 10
                // it will remove all of the keys that it acquired from the dictionary
                myDict.Keys.ToList().FindAll(x => myDict[x] < 10).ForEach(x => myDict.Remove(x));
                ShowDictionary();
            }            
        }        
    }
}
