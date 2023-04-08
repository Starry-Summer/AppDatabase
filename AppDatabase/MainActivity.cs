using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Service.Autofill;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace AppDatabase
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtUser;
        EditText txtId;
        EditText txtEmail;
        EditText txtDescription;
        Button show;
        Button insert;
        Button update;
        Button delete;
        TextView ViewOne;
        TextView ViewTwo;
        TextView ViewThree;
        TextView ViewFour;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            show = FindViewById<Button>(Resource.Id.show); 
            insert = FindViewById<Button>(Resource.Id.insert);
            update = FindViewById<Button>(Resource.Id.update);
            delete = FindViewById<Button>(Resource.Id.delete);
            txtUser = FindViewById<EditText>(Resource.Id.txtUser);
            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtDescription = FindViewById<EditText>(Resource.Id.txtDescription);
            ViewOne = FindViewById<TextView>(Resource.Id.ViewOne);
            ViewTwo = FindViewById<TextView>(Resource.Id.ViewTwo);
            ViewThree = FindViewById<TextView>(Resource.Id.ViewThree);
            ViewFour = FindViewById<TextView>(Resource.Id.ViewFour);

            show.Click += Show_Click;
            insert.Click += Insert_Click;
            update.Click += Update_Click;
            delete.Click += Delete_Click;
        }

        private void Delete_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    new Auxiliar().Destroy(int.Parse(txtId.Text.Trim()));
                    Toast.MakeText(this, "Datos eliminados", ToastLength.Short).Show();                    
                }
                else
                {
                    Toast.MakeText(this, "Campo vacio. Rellene el campo de ID", ToastLength.Long).Show();
                }
            }
            catch (Exception X)
            {
                Toast.MakeText(this, X.ToString(), ToastLength.Short).Show();
            }
            //throw new System.NotImplementedException();
        }

        private void Update_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUser.Text.Trim()) && !string.IsNullOrEmpty(txtId.Text.Trim()) && !string.IsNullOrEmpty(txtEmail.Text.Trim()) && !string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                    // = new Auxiliar().Insert(txtUser.Text.Trim(), txtId.Text.Trim(), txtEmail.Text.Trim(), txtDescription.Text.Trim());
                    new Auxiliar().Insert(new Sign() { User = txtUser.Text.Trim(), ID = int.Parse(txtId.Text.Trim()), Email = txtEmail.Text.Trim(), Description = txtDescription.Text.Trim() });
                    Toast.MakeText(this, "Datos actualizados", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Campos o campo vacio. Rellene todos los campos", ToastLength.Long).Show();
                }
            }
            catch (Exception X)
            {
                Toast.MakeText(this, X.ToString(), ToastLength.Short).Show();
            }
            //throw new System.NotImplementedException();
        }

        private void Insert_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUser.Text.Trim())&& !string.IsNullOrEmpty(txtEmail.Text.Trim())&& !string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                    // = new Auxiliar().Insert(txtUser.Text.Trim(), txtId.Text.Trim(), txtEmail.Text.Trim(), txtDescription.Text.Trim());
                    new Auxiliar().Insert(new Sign() { User = txtUser.Text.Trim(), ID = 0, Email = txtEmail.Text.Trim(),Description = txtDescription.Text.Trim() });
                    Toast.MakeText(this, "Datos guardados", ToastLength.Short).Show();
                    
                }
                else
                {
                    Toast.MakeText(this, "Campos o campo vacio. Rellene todos los campos", ToastLength.Long).Show();
                }
            }
            catch (Exception X)
            {
                Toast.MakeText(this, X.ToString(), ToastLength.Short).Show();
            }
            //throw new System.NotImplementedException();
        }

        private void Show_Click(object sender, System.EventArgs e)
        {
            try
            {
                Sign Data = null;
                if (!string.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    Data = new Auxiliar().Selection(int.Parse(txtId.Text.Trim()));
                    if (Data != null)
                    {
                        ViewOne.Text = Data.User.ToString();
                        ViewTwo.Text = Data.ID.ToString();
                        ViewThree.Text = Data.Email.ToString();
                        ViewFour.Text = Data.Description.ToString();
                    }
                    else
                    {
                        Toast.MakeText(this, "Datos invalidos", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Campos o campo vacio. Rellene todos los campos", ToastLength.Long).Show();
                }

            }
            catch (Exception X)
            {
                Toast.MakeText(this, X.ToString(), ToastLength.Short).Show();
            }
            // throw new System.NotImplementedException();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}