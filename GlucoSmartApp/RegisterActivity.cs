using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GlucoSmart.Controllers;
using GlucoSmart.Models;

namespace GlucoSmart
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        RegisterModel register = new RegisterModel();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.register_activity);

            Button clearButton = FindViewById<Button>(Resource.Id.clearButton);
            Button registerButton = FindViewById<Button>(Resource.Id.registerButton);
            EditText userName = FindViewById<EditText>(Resource.Id.username);
            EditText email = FindViewById<EditText>(Resource.Id.email);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            EditText confirmPassword = FindViewById<EditText>(Resource.Id.confirmPassword);
            EditText firstName = FindViewById<EditText>(Resource.Id.firstName);
            EditText lastName = FindViewById<EditText>(Resource.Id.lastName);
            EditText dob = FindViewById<EditText>(Resource.Id.dob);
            //EditText weight = FindViewById<EditText>(Resource.Id.weight);
            EditText doctorID = FindViewById<EditText>(Resource.Id.DoctorID);

            RegisterController registerController;

            registerButton.Click


        }

        private void ClearAll()
        {
            EditText userName = FindViewById<EditText>(Resource.Id.username);
            EditText email = FindViewById<EditText>(Resource.Id.email);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            EditText confirmPassword = FindViewById<EditText>(Resource.Id.confirmPassword);
            EditText firstName = FindViewById<EditText>(Resource.Id.firstName);
            EditText lastName = FindViewById<EditText>(Resource.Id.lastName);
            EditText dob = FindViewById<EditText>(Resource.Id.dob);
            //EditText weight = FindViewById<EditText>(Resource.Id.weight);
            EditText doctorID = FindViewById<EditText>(Resource.Id.DoctorID);


            userName.Text = "";
            email.Text = "";
            password.Text = "";
            confirmPassword.Text = "";
            firstName.Text = "";
            lastName.Text = "";
            dob.Text = "";
            //weight.Text = "";
            doctorID.Text = "";
        }
    }
}