using Animals.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Animals.Controllers
{
    public partial class AanimalFoorm : Form
    {
        AnimalLogic animalLogic = new AnimalLogic();
        public AanimalFoorm()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Animal newAnimal = new Animal
            {
                Name = txtb2.Text,
                Age = int.Parse(txtb3.Text),
                BreedId = int.Parse(txtb4.Text)
            };
            animalLogic.Create(newAnimal);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtb1.Text))
            {
                MessageBox.Show("Не си избрал Id за изтриване!");
                return;
            }

            int id = int.Parse(txtb1.Text);
            animalLogic.Delete(id);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtb1.Visible == false)
            {
                lbl1.Visible = true;
                txtb1.Visible = true;
            }

            //btnFind_Click(sender, e);
            if (string.IsNullOrEmpty(txtb1.Text) || txtb1.Text == "")
            {
                MessageBox.Show("Ne si izbral Id za iztrivane!");
                return;
            }
            lbl2.Enabled = false;
            txtb2.Enabled = false;
            lbl3.Enabled = false;
            txtb3.Enabled = false;
            lbl4.Enabled = false;
            txtb4.Enabled = false;
            Animal newProduct = animalLogic.Get(int.Parse(txtb1.Text));
            txtb1.Text = newProduct.Id.ToString();
            txtb2.Text = newProduct.Name;
            txtb4.Text = newProduct.Age.ToString();

        }
    }
}
