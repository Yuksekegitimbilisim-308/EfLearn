using EfLearn.AbstractEntityRepository;
using EfLearn.Entities;
using EfLearn.Models;
using EfLearn.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfLearn
{
    public partial class Form1 : Form
    {
        IGradeRepository _gradeRepository;
        IStudentRepository _studentRepository;
        public Form1()
        {
            AppDbContext context = new AppDbContext();

            InitializeComponent();
            _gradeRepository = new GradeRepository(context);
            _studentRepository = new StudentRepository(context);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _studentRepository.GetStudentsWithGrade();
            comboGrades.DataSource = _gradeRepository.GetAll();
            comboGrades.ValueMember = "Id";
            comboGrades.DisplayMember = "LessonName";


        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text;
            string phoneNumber = txtPhoneNumber.Text;
            bool isActive = chcIsActive.Checked;
            int gradeId = (int)comboGrades.SelectedValue;
            Student student = new Student
            {
                Fullname = fullname,
                PhoneNumber = phoneNumber,
                GradeId = gradeId,
                IsActive = isActive,
            };
            _studentRepository.Add(student);
            dataGridView1.DataSource = _studentRepository.GetStudentsWithGrade();
            ClearTexbox();
        }

        private void txtSearchTerm_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearchTerm.Text;
           dataGridView1.DataSource =  _studentRepository.GetStudentsWithGradeWhereLikeFullname(searchTerm);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            StudentWithGrade studentModel = (StudentWithGrade)row.DataBoundItem;
            txtFullname.Text = studentModel.StudentName;
            txtPhoneNumber.Text = studentModel.PhoneNumber;
            txtId.Text = studentModel.Id.ToString();
            chcIsActive.Checked = studentModel.IsActive;
            comboGrades.Text = studentModel.LessonName;


            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                Student student = new Student
                {
                    Id =int.Parse(txtId.Text),
                    Fullname = txtFullname.Text,
                    IsActive = chcIsActive.Checked,
                    PhoneNumber = txtPhoneNumber.Text,
                    GradeId = (int)comboGrades.SelectedValue
                };

                _studentRepository.Update(student);
                dataGridView1.DataSource = _studentRepository.GetStudentsWithGrade();
                ClearTexbox();
            }
        }
        private void ClearTexbox()
        {
            txtFullname.Text = "";
            txtId.Text = "";
            txtPhoneNumber.Text = "";
            chcIsActive.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                _studentRepository.Delete(int.Parse(txtId.Text));
                dataGridView1.DataSource= _studentRepository.GetStudentsWithGrade();
                ClearTexbox();
            }
        }
    }
}
