using EmpLib;

namespace EmpForms
{
    public partial class Form1 : Form
    {
        Employee KpmgEmp = new Employee();

        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click2;
            button1.Click += Button1_Click3;
            KpmgEmp.Join += SriRam_Join;
            KpmgEmp.Join += Rana_Join;
            KpmgEmp.Join += Camelin_Join;
            KpmgEmp.Resign += Camelin_Resign;
            KpmgEmp.Resign += Hacker_Resign;


        }

        private void Hacker_Resign(object? sender, EventArgs e)
        {
            MessageBox.Show("Hacker Resigned KPMG successfully");
        }



        private void Camelin_Resign(object? sender, EventArgs e)
        {
            MessageBox.Show("Camelin Resigned KPMG successfully");
        }

        private void Camelin_Join(object? sender, EventArgs e)
        {
            MessageBox.Show("Camelin joined KPMG successfully");
        }

        private void Rana_Join(object? sender, EventArgs e)
        {
            MessageBox.Show("Rana joined KPMG successfully");
        }

        private void SriRam_Join(object? sender, EventArgs e)
        {
            MessageBox.Show("SriRam joined KPMG successfully");

        }

        private void Button1_Click3(object? sender, EventArgs e)
        {
            MessageBox.Show("You clicked the button thrice");
        }

        private void Button1_Click2(object? sender, EventArgs e)
        {
            MessageBox.Show("You clicked the button twice");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked the button");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KpmgEmp.TriggerJoinEvent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KpmgEmp.TriggerResignEvent();
        }
    }
}