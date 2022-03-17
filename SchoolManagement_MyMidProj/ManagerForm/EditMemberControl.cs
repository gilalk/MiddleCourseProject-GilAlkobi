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
    public partial class EditMemberControl : UserControl
    {
        public event Action? OnBackToMemberConrol2;
        public EditMemberControl()
        {
            InitializeComponent();
            FillCrewMembersNamesInCmBox();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.OnBackToMemberConrol2();
        }

        private void FillCrewMembersNamesInCmBox()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new SchoolManagementContext()))
                {
                    crewMemberscmBox.Items.Clear();
                    var crewMembers = unitOfWork.Managers.GetAllCrewMembersNames();
                    foreach (var member in crewMembers)
                    {
                        crewMemberscmBox.Items.Add(member);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("An error occured\nCouldn't load crew members list!");
            }
        }

        private void GetAllBoxesEmpty()
        {
            firstNametxt.Clear();
            lastNametxt.Clear();
            roleCmBox.ResetText();
            subjectTxt.ReadOnly = false;
            subjectTxt.Clear();
            subjectCmBox.ResetText();
            addresstxt.Clear();
            citytxt.Clear();
            emailtxt.Clear();
            phoneNumbertxt.Clear();
            crewMemberscmBox.ResetText();
        }

        private void crewMemberscmBox_SelectedValueChanged(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOfWork(new SchoolManagementContext()))
            {
                var member = unitOfWork.Managers.GetCrewMemberByFullName(crewMemberscmBox.Text);
                firstNametxt.Text = member.FirstName;
                lastNametxt.Text = member.LastName;
                roleCmBox.Text = member.Role;
                subjectTxt.Text = member.Subject;
                subjectTxt.ReadOnly = true;
                addresstxt.Text = member.Adress;
                citytxt.Text = member.City;
                emailtxt.Text = member.Email;
                phoneNumbertxt.Text = member.PhoneNumber;

            }
        }

        private void saveChangesbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new SchoolManagementContext()))
                {
                    if (String.IsNullOrEmpty(crewMemberscmBox.Text))
                    {
                        MessageBox.Show("Choose Member First!");
                        return;
                    }
                    var member = unitOfWork.Managers.GetCrewMemberByFullName(crewMemberscmBox.Text);
                    member.FirstName = firstNametxt.Text;
                    member.LastName = lastNametxt.Text;
                    member.Role = roleCmBox.Text;
                    member.Subject = subjectCmBox.Text;
                    member.Adress = addresstxt.Text;
                    member.City = citytxt.Text;
                    member.Email = emailtxt.Text;
                    member.PhoneNumber = phoneNumbertxt.Text;
                    if (!IsThisEmailValid(emailtxt.Text) && emailtxt.Text != "")
                    {
                        MessageBox.Show("Email Address is Invalid!");
                        return;
                    }
                    if (!IsThisPhoneNumberValid(phoneNumbertxt.Text) && phoneNumbertxt.Text != "")
                    {
                        MessageBox.Show("Phone Number is Invalid!");
                        return;
                    }
                    unitOfWork.Complete();
                    MessageBox.Show("Member edited successfully!");
                    GetAllBoxesEmpty();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new SchoolManagementContext()))
                {
                    if(String.IsNullOrEmpty(crewMemberscmBox.Text))
                    {
                        MessageBox.Show("Choose Member First!");
                        return;
                    }
                    var member = unitOfWork.Managers.GetCrewMemberByFullName(crewMemberscmBox.Text);
                    var account = unitOfWork.Account.GetAccount(member.AccountId);
                    string message = $"Are you sure you want to remove {member.FirstName} from system?";
                    const string caption = "Delete Member";
                    DialogResult dialogResult = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var classes = unitOfWork.Managers.GetClassesByTeacher(member);
                        if (classes != null)
                        {
                            foreach (var c in classes)
                            {
                                unitOfWork.Managers.DeleteClass(c);
                            }
                        }
                        unitOfWork.Managers.Delete(member);
                        unitOfWork.Account.Delete(account);
                        unitOfWork.Complete();
                        MessageBox.Show("Member Removed!");
                        FillCrewMembersNamesInCmBox();
                        GetAllBoxesEmpty();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
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
