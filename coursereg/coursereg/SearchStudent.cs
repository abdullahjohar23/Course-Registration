﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursereg
{
    public partial class SearchStudent : Form
    {
        public SearchStudent()
        {
            InitializeComponent();
        }

        private void SearchStudent_Load(object sender, EventArgs e)
        {
            // SSQL connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = ABDULLAH-JOHAR\\SQLEXPRESS; database = db; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // joining table
            cmd.CommandText = "select NewAdmission.NAID as Student_ID, NewAdmission.fname as Full_Name, NewAdmission.mname as Mother_Name, NewAdmission.gender as Gender, NewAdmission.dob as Date_Of_Birth, NewAdmission.mobile as Mobile, NewAdmission.email as Email_ID, NewAdmission.semester as Semester, NewAdmission.prog as Program, NewAdmission.sname as School_Name, NewAdmission.duration as Course_Duration, NewAdmission.addres as Address, fees.fees as Fees from NewAdmission inner join fees on NewAdmission.NAID = fees.NAID";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds); // bridge create

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = ABDULLAH-JOHAR\\SQLEXPRESS; database = db; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewAdmission where NAID = "+textBox1.Text+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
