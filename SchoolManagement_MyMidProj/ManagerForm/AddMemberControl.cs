using SchoolManagement.DB;
using SchoolManagement.DB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerForm
{
    public partial class AddMemberControl : UserControl
    {
        
        // an event which helps me move between user controls
        public event Action? OnBackToMemberControl;
        
        public AddMemberControl()
        {
            InitializeComponent();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.OnBackToMemberControl();
        }

        // add the new crewmember
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new SchoolManagementContext()))
                {
                    if (String.IsNullOrEmpty(firstNametxt.Text) || String.IsNullOrEmpty(lastNametxt.Text))
                    {
                        MessageBox.Show("First name or Last name is missing");
                        return;
                    }
                    DateTime dateTime = DateTime.Now;
                    CrewMember crewMember = new CrewMember();
                    crewMember.FirstName = firstNametxt.Text;
                    crewMember.LastName = lastNametxt.Text;
                    crewMember.Gender = gendercmBox.Text;
                    crewMember.Role = rolCmBox.Text;
                    crewMember.Subject = subjectCmBox.Text;
                    crewMember.Adress = addresstxt.Text;
                    crewMember.City = citytxt.Text;
                    crewMember.Email = emailtxt.Text;
                    crewMember.PhoneNumber = phoneNumbertxt.Text;
                    crewMember.DateOfBirth = birthDatePicker.Value;
                    crewMember.Age = dateTime.Year - birthDatePicker.Value.Year;

                    if (!IsThisEmailValid(emailtxt.Text) && emailtxt.Text != "") { MessageBox.Show("Email Address is Invalid!"); }
                    if (!IsThisPhoneNumberValid(phoneNumbertxt.Text) && phoneNumbertxt.Text != "") { MessageBox.Show("Phone Number is Invalid!"); }

                    var newAccount = unitOfWork.Managers.CreateCrewMemberAccount(crewMember);

                    crewMember.AccountId = newAccount.Id;

                    unitOfWork.Managers.AddCrewMember(crewMember);

                    unitOfWork.Complete();

                    MessageBox.Show("Member added successfully!");
                    GetAllBoxesEmpty();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("One of your detail is improper");
            }
        }

        /// <summary>
        /// Reset all fields in screen
        /// </summary>
        private void GetAllBoxesEmpty()
        {
            firstNametxt.Clear();
            lastNametxt.Clear();
            gendercmBox.ResetText();
            rolCmBox.ResetText();
            subjectCmBox.ResetText();
            addresstxt.Clear();
            citytxt.Clear();
            emailtxt.Clear();
            phoneNumbertxt.Clear();
            birthDatePicker.ResetText();
        }

        #region ErrorProviders with Regex

        private bool IsThisEmailValid(string emailAdress)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(emailAdress);
        }

        private bool IsThisPhoneNumberValid(string phoneNumber)
        {
            Regex regex = new Regex(@"^([0-9]{10}|\d{10})$");
            return regex.IsMatch(phoneNumber);
        }

        private void phoneNumbertxt_TextChanged_1(object sender, EventArgs e)
        {
            if (!IsThisPhoneNumberValid(phoneNumbertxt.Text))
            {
                phoneNumErrorProvider1.SetError(phoneNumbertxt, "Wrong Format!");
            }
            else
            {
                phoneNumErrorProvider1.Clear();
            }
        }

        private void emailtxt_TextChanged_1(object sender, EventArgs e)
        {
            if (!IsThisEmailValid(emailtxt.Text))
            {
                emailErrorProvider1.SetError(emailtxt, "Wrong Format!");
            }
            else
            {
                emailErrorProvider1.Clear();
            }
        }


        #endregion


    }
}
