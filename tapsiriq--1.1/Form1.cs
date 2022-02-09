using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tapsiriq__1._1
{
    public partial class Form1 : Form
    {
        class User
        {
            public User(string name, string surname, string father_name, string country, string city, string birthday, string gender)
            {
                this.name = name;
                this.surname = surname;
                this.father_name = father_name;
                this.country = country;
                this.city = city;
                this.birthday = birthday;
                this.gender = gender;
            }

            public string name { get; set; }
            public string surname { get; set; }
            public string father_name { get; set; }
            public string country { get; set; }
            public string city { get; set; }
            public string birthday { get; set; }
            public string gender { get; set; }
        }
        List<User> users = new List<User>();

        

        public Form1()
        {
            InitializeComponent();
            var jsonStr = File.ReadAllText("userss.json");

            users = JsonConvert.DeserializeObject<List<User>>(jsonStr);

        }

        private void save_button_Click(object sender, EventArgs e)
        {

            label_qeydiyyat.Dispose();
            string text;
            if(radioButton1.Checked)text=radioButton1.Text;
            else text=radioButton2.Text;
            if (textBox_name.Text.Length == 0)
            {
                label_errorname.Text = "You must enter a name";
                label_errorname.BackColor = Color.Red;
            }
            else
            {
                label_errorname.Text = "";
                label_errorname.BackColor = Color.Transparent;
            }
            if (textBox_surname.Text.Length == 0)
            {
 
                label_errorsurname.Text = "You must enter a surname";
                label_errorsurname.BackColor = Color.Red;

            }
            else
            {
                label_errorsurname.Text = "";
                label_errorsurname.BackColor = Color.Transparent;
            }
            if (textBox_father.Text.Length == 0)
            {
 
                label_errorfathername.Text = "You must enter a father";
                label_errorfathername.BackColor = Color.Red;

            }
            else
            {
                label_errorfathername.Text = "";
                label_errorfathername.BackColor = Color.Transparent;
            }
            if (textBox_country.Text.Length == 0)
            {

                label_errorcountry.Text = "You must enter a country";
                label_errorcountry.BackColor = Color.Red;

            }
            else
            {
                label_errorcountry.Text = "";
                label_errorcountry.BackColor = Color.Transparent;
            }
            if (textBox_city.Text.Length == 0)
            {
               
                label_errorcity.Text = "You must enter a city";
                label_errorcity.BackColor = Color.Red;
                return;

            }
            else
            {
                label_errorcity.Text = "";
                label_errorcity.BackColor = Color.Transparent;
            }
            if (maskedTextBox1.MaskFull==false)
            {
         
                label_errormobilnumber.Text = "You must enter a mobil number";
                label_errormobilnumber.BackColor = Color.Red;
                


            }
            else
            {
                label_errormobilnumber.Text = "";
                label_errormobilnumber.BackColor = Color.Transparent;
            }
            if ((2022-Convert.ToInt32(dateTimePicker1.Value.Year))<18)
            {
                
                label_errorbirthday.Text = "Not less than 18 years old";
                label_errorbirthday.BackColor = Color.Red;
         
            }
            else
            {
                label_errorbirthday.Text = "";
                label_errorbirthday.BackColor = Color.Transparent;
            }
            if (radioButton1.Checked==false && radioButton2.Checked == false)
            {
               
                label_errorgender.Text = "You must enter a gender";
                label_errorgender.BackColor = Color.Red;
                return;
            }
            else{
                label_errorgender.Text = "";
                label_errorgender.BackColor = Color.Transparent;
              

            }
            User user = new User(textBox_name.Text, textBox_surname.Text, textBox_father.Text, textBox_country.Text, textBox_city.Text, dateTimePicker1.Text, text);
            users.Add(user);
            var usersjsonn = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("userss.json", usersjsonn);

           
            label_qeydiyyat.Text = "  registration was successful";
            label_qeydiyyat.BackColor = Color.Green;
            

        }

        private void button_load_Click(object sender, EventArgs e)
        {
            var count = 0;
            
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].name == textBox_input.Text)
                {
                    textBox_name.Text = users[i].name;  
                    textBox_surname.Text= users[i].surname;
                    textBox_father.Text = users[i].father_name;
                    textBox_country.Text= users[i].country;
                    textBox_city.Text= users[i].city;
                    dateTimePicker1.Text=users[i].birthday;
                    if (radioButton1.Text == users[i].gender) radioButton1.Checked = true;
                    else radioButton2.Checked = true;
                    count++;
                    label_errorinput.Text = "------";
                    label_errorinput.BackColor = Color.Transparent;
                }
            }
            if (count == 0)
            {
                label_errorinput.Text = "There is no user name you entered";
                label_errorinput.BackColor = Color.Red;
            }
        }

    }
}
