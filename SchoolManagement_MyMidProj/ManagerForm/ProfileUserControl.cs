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
    public partial class ProfileUserControl : UserControl
    {
        public event Action OnBackToHomeControl;
        private string userFullName = FormLogin1.fullName;
        public ProfileUserControl()
        {
            InitializeComponent();
            FillInformationInLabels();
            changePasswordgrBox.Visible = false;
            changeDetailsgrBox.Visible = false;
        }

        private void FillInformationInLabels()
        {
            using(var unitOfWork = new UnitOfWork(new SchoolManagementContext()))
            {
                var crewMember = unitOfWork.Managers.GetCrewMemberByFullName(userFullName);
                firstNamelbl.Text = crewMember.FirstName;
                lastNamelbl.Text = crewMember.LastName;
                rolelbl.Text = crewMember.Role;
                subjectlbl.Text = crewMember.Subject;
                birthDatelbl.Text = crewMember.DateOfBirth.ToString();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.OnBackToHomeControl();
        }

        private void changePassbtn_Click(object sender, EventArgs e)
        {
            changePasswordgrBox.Visible = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            using(var unitOfWork = new UnitOfWork(new SchoolManagementContext()))
            {
                var user = unitOfWork.Managers.GetCrewMemberByFullName(userFullName);
                var account = unitOfWork.Account.GetAccount(user.AccountId);
                if(account == null)
                {
                    MessageBox.Show("Username is not exist!");
                }
                else if(string.IsNullOrEmpty(newPasswordtxt.Text) || string.IsNullOrEmpty(verifyPasswordtxt.Text))
                {
                    MessageBox.Show("Enter Input First!");
                }
                else if(newPasswordtxt.Text != verifyPasswordtxt.Text)
                {
                    MessageBox.Show("Verified password Doesn't match!");
                }
                else if(account.UserName == usernametxt.Text && newPasswordtxt.Text == verifyPasswordtxt.Text)
                {
                    account.Password = verifyPasswordtxt.Text;
                    unitOfWork.Complete();
                    MessageBox.Show("Password changed!");
                    usernametxt.Clear();
                    newPasswordtxt.Clear();
                    verifyPasswordtxt.Clear();
                    changePasswordgrBox.Visible = false;
                }
                else
                {
                    MessageBox.Show("Wrong User Name!");
                }

            }
        }

        private void changeDetbtn_Click(object sender, EventArgs e)
        {
            using(var unitOfWork = new UnitOfWork(new SchoolManagementContext()))
            {
                changeDetailsgrBox.Visible = true;
                var member = unitOfWork.Managers.GetCrewMemberByFullName(userFullName);
                firstNametxt.Text = member.FirstName;
                lastNametxt.Text = member.LastName;
                roleCmBox.Text = member.Role;
                subjectCmBox.Text = member.Subject;
                addresstxt.Text = member.Adress;
                citytxt.Text = member.City;
                emailtxt.Text = member.Email;
                phoneNumbertxt.Text = member.PhoneNumber;

                if(FormLogin1.role != "manager" && FormLogin1.role != "deputy director")
                {
                    roleCmBox.Enabled = false;
                    subjectCmBox.Enabled = false;
                }
            }
        }

        private void saveDetsbtn_Click(object sender, EventArgs e)
        {
            using(var unitOfWork = new UnitOfWork(new SchoolManagementContext()))
            {
                var member = unitOfWork.Managers.GetCrewMemberByFullName(userFullName);
                member.FirstName = firstNametxt.Text;
                member.LastName = lastNametxt.Text;
                member.Role = roleCmBox.Text;
                member.Subject = subjectCmBox.Text;
                member.Adress = addresstxt.Text;
                member.City = citytxt.Text;
                member.PhoneNumber = phoneNumbertxt.Text;
                if(emailtxt.Text != "" && phoneNumbertxt.Text != "")
                {
                    if (!IsThisPhoneNumberValid(phoneNumbertxt.Text) && !IsThisEmailValid(emailtxt.Text))
                    {
                        MessageBox.Show("Invalid Phone Number and Email Address!");
                    }
                }
                
                else if(!IsThisEmailValid(emailtxt.Text) && emailtxt.Text != "")
                {
                    MessageBox.Show("Invalid Email Address!");
                }
                else if (!IsThisPhoneNumberValid(phoneNumbertxt.Text) && phoneNumbertxt.Text != "")
                {
                    MessageBox.Show("Invalid Phone Number!");
                }

                MessageBox.Show("Details Saved Successfully!");
                unitOfWork.Complete();
                firstNametxt.Clear();
                lastNametxt.Clear();
                roleCmBox.ResetText();
                subjectCmBox.ResetText();
                addresstxt.Clear();
                citytxt.Clear();
                phoneNumbertxt.Clear();
                changeDetailsgrBox.Visible = false;
            }
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

        private void emailtxt_TextChanged(object sender, EventArgs e)
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

        private void phoneNumbertxt_TextChanged(object sender, EventArgs e)
        {
            if (!IsThisPhoneNumberValid(phoneNumbertxt.Text))
            {
                phoneNumberErrorProvider1.SetError(phoneNumbertxt, "Wrong Format!");
            }
            else
            {
                phoneNumberErrorProvider1.Clear();
            }
        }

        #endregion
    }
}
