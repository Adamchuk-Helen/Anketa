using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Anketa
{

    public partial class Anketa : Form
    {
        public static string gender;
        public static string art;
        public static string sport;
        public static string technology;
        public static string other;
        public Anketa()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            lbAge.Show();
            tbAge.Show();
            int age = DateTime.Today.Year - Convert.ToInt32(dateTimePicker1.Value.Year);
            tbAge.Text = Convert.ToString(age);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {

                pbPicture.Image = Properties.Resources._699_6999322_business_man_icon_png_business_man_transparent_png;
                gender = "male";
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbPicture.Image = Properties.Resources._105_1051514_business_woman_silhouette_female_business_person_icon_hd2;
                gender = "female";
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbOther_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOther.Checked)
            {
                tbOtherHobby.Show();

            }
            else
            {
                tbOtherHobby.Hide();
            }

        }
        struct Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Age { get; set; }
            public string Country { get; set; }

            public bool male;

            public bool female;

            public bool sport;

            public bool art;

            public bool technology;

            public bool other;

            public string Other { get; set; }

        }


        private void cbSport_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSport.Checked)
            {
                sport = "sport";
            }
        }

        private void cbArt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbArt.Checked)
            {
                art = "art";
            }
        }

        private void cbTechnology_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTechnology.Checked)
            {
                technology = "technology";
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            XDocument xDoc = new XDocument();
            XElement person1 = new XElement("person");
            XElement personName = new XElement("name", tbName.Text);
            XElement personSurname = new XElement("surname", tbSurname.Text);
            XElement personBirthDay = new XElement("birthday", dateTimePicker1.Value);
            XElement personAge = new XElement("age", tbAge.Text);
            XElement personcountry = new XElement("country", cbCountry.SelectedItem);
            XElement personGender = new XElement("gender", gender);
            XElement hobbySport = new XElement("sport", sport);
            XElement hobbyArt = new XElement("art", art);
            XElement hobbyTechnology = new XElement("technology", technology);
            XElement hobbyOther = new XElement("other", other);
            person1.Add(personName);
            person1.Add(personSurname);
            person1.Add(personBirthDay);
            person1.Add(personAge);
            person1.Add(personcountry);
            person1.Add(personGender);
            person1.Add(hobbySport);
            person1.Add(hobbyArt);
            person1.Add(hobbyTechnology);
            person1.Add(hobbyOther);
            xDoc.Add(person1);
            xDoc.Save("person.xml");
        }

        private void tbOtherHobby_TextChanged(object sender, EventArgs e)
        {
            other = tbOtherHobby.Text;
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load("person.xml");
            foreach (XElement myperson in xdoc.Elements("person"))
            {
                tbName.Text = Convert.ToString(myperson.Element("name").Value);
                tbSurname.Text = Convert.ToString(myperson.Element("surname").Value);
                if (myperson.Element("birthday").Value != "")
                {
                    dateTimePicker1.Value = Convert.ToDateTime(myperson.Element("birthday").Value);
                    lbAge.Show();
                    tbAge.Show();
                    tbAge.Text = Convert.ToString(myperson.Element("age").Value);
                }

                cbCountry.SelectedItem = Convert.ToString(myperson.Element("country").Value);

                if (myperson.Element("gender").Value != "")
                {
                    if (myperson.Element("gender").Value == "male")
                    {
                        rbMale.Checked = true;
                        pbPicture.Image = Properties.Resources._699_6999322_business_man_icon_png_business_man_transparent_png;
                    }
                    else if (myperson.Element("gender").Value == "female")
                    {
                        rbFemale.Checked = true;
                        pbPicture.Image = Properties.Resources._105_1051514_business_woman_silhouette_female_business_person_icon_hd2;
                    }


                    if (myperson.Element("sport").Value != "")
                    {
                        cbSport.Checked = true;
                    }
                    if (myperson.Element("art").Value != "")
                    {
                        cbArt.Checked = true;
                    }
                    if (myperson.Element("technology").Value != "")
                    {
                        cbTechnology.Checked = true;
                    }
                    if (myperson.Element("other").Value != "")
                    {
                        cbOther.Checked = true;
                        tbOtherHobby.Show();
                        tbOtherHobby.Text = Convert.ToString(myperson.Element("other").Value);
                    }
                }
            }
        }
    }
}
