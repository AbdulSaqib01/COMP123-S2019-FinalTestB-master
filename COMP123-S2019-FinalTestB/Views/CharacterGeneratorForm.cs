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
        // String Lists
        public static List<string> FirstNameList;
        public static List<string> LastNameList;
        public static List<string> InventoryList;

        // String Arrays
        public static string[] firstNames;
        public static string[] lastNames;
        public static string[] inventory;

        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is event handler for BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// This is event handler NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count -1)
            {
                MainTabControl.SelectedIndex++;
            }
        }

        /// <summary>
        /// This is event handler GenerateButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            GenerateNames(firstNames, lastNames);
            Program.character.FirstName = firstNames.ToString();
            Program.character.LastName = lastNames.ToString();
        }

        /// <summary>
        /// This method generates random first names and last names
        /// </summary>
        /// <param name="firstNames"></param>
        /// <param name="lastNames"></param>
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

        /// <summary>
        /// This method load names from the txt files
        /// </summary>
        /// <param name="firstNames"></param>
        /// <param name="lastNames"></param>
        private static void LoadNames(out string[] firstNames, out string[] lastNames)
        {
            FirstNameList = new List<string>();
            LastNameList = new List<string>();


            firstNames = File.ReadAllLines("firstNames.txt");
            lastNames = File.ReadAllLines("lastNames.txt");
        }

        /// <summary>
        /// This is event handler CharacterGenerateForm Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadNames(out firstNames, out lastNames);
            GenerateNames(firstNames, lastNames);
            LoadInventory();
        }

        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            GenerateRandomAbilities();
        }

        private void GenerateRandomAbilities()
        {
            var randNum = new Random();
            int strengthNumRange = randNum.Next(3, 18);
            int dexterityNumRange = randNum.Next(3, 18);
            int ConstitutionNumRange = randNum.Next(3, 18);
            int intelligenceNumRange = randNum.Next(3, 18);
            int wisdomNumRange = randNum.Next(3, 18);
            int charismaNumRange = randNum.Next(3, 18);

            StrengthDataLabel.Text = strengthNumRange.ToString();
            DexterityDataLabel.Text = dexterityNumRange.ToString();
            ConstitutionDataLabel.Text = ConstitutionNumRange.ToString();
            IntelligenceDataLabel.Text = intelligenceNumRange.ToString();
            WisdomDataLabel.Text = wisdomNumRange.ToString();
            CharismaDataLabel.Text = charismaNumRange.ToString();

            Program.character.Strength = strengthNumRange.ToString();
            Program.character.Dexterity = dexterityNumRange.ToString();
            Program.character.Constitution = ConstitutionNumRange.ToString();
            Program.character.Intelligence = intelligenceNumRange.ToString();
            Program.character.Wisdom = wisdomNumRange.ToString();
            Program.character.Charisma = charismaNumRange.ToString();
        }

        private void GenerateInventoryItemsButton_Click(object sender, EventArgs e)
        {
            GenerateRandomInventory();
        }

        private void GenerateRandomInventory()
        {
            var randItem = new Random();

            var randomInventoryItems1 = randItem.Next(0, inventory.Length - 1);
            var numOfItems1 = inventory[randomInventoryItems1];
            var randomInventoryItems2 = randItem.Next(0, inventory.Length - 1);
            var numOfItems2 = inventory[randomInventoryItems2];
            var randomInventoryItems3 = randItem.Next(0, inventory.Length - 1);
            var numOfItems3 = inventory[randomInventoryItems3];
            var randomInventoryItems4 = randItem.Next(0, inventory.Length - 1);
            var numOfItems4 = inventory[randomInventoryItems4];

            InventoryList.Add(numOfItems1);
            InventoryList.Add(numOfItems2);
            InventoryList.Add(numOfItems3);
            InventoryList.Add(numOfItems4);

            OneDataLabel.Text = numOfItems1.ToString();
            TwoDataLabel.Text = numOfItems2.ToString();
            ThirdDataLabel.Text = numOfItems3.ToString();
            FourthDataLabel.Text = numOfItems4.ToString();

            Program
           
        }

        private void LoadInventory()
        {
            InventoryList = new List<string>();

            inventory = File.ReadAllLines("Inventory.txt");
        }
    }
}
