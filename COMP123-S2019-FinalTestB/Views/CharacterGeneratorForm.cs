using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
/*
 * STUDENT NAME: Abdul Moeed Saqib 
 * STUDENT ID: 301004138
 * DESCRIPTON: This is CharacterForm
 */
namespace COMP123_S2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : MasterForm
    {
        public static List<string> FirstNameList;
        public static List<string> LastNameList;
        public static string[] firstNames;
        public static string[] lastNames;

        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count -1)
            {
                MainTabControl.SelectedIndex++;
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            GenerateNames(firstNames, lastNames);
            Program.character.FirstName = firstNames.ToString();
            Program.character.LastName = lastNames.ToString();
        }

        private void GenerateNames(string[] firstNames, string[] lastNames)
        {
            var rand = new Random();

            var randomFirstNames = rand.Next(0, firstNames.Length - 1);
            var randomLastNames = rand.Next(0, lastNames.Length - 1);

            var numOfFirstNames = firstNames[randomFirstNames];
            var numOfLastNames = lastNames[randomLastNames];

            FirstNameList.Add(numOfFirstNames);
            LastNameList.Add(numOfLastNames);

            FirstNameDataLabel.Text = numOfFirstNames.ToString();
            LastNameDataLabel.Text = numOfLastNames.ToString();
        }

        private static void LoadNames(out string[] firstNames, out string[] lastNames)
        {
            FirstNameList = new List<string>();
            LastNameList = new List<string>();


            firstNames = File.ReadAllLines("firstNames.txt");
            lastNames = File.ReadAllLines("lastNames.txt");
        }

        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadNames(out firstNames, out lastNames);
            GenerateNames(firstNames, lastNames);
        }
    }
}
