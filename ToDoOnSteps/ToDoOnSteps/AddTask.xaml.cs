using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoOnSteps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTask : ContentPage
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private async void saveTask_Clicked(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;

            if (task == null)
                task = new Task { Name = entry_task.Text, Checked = false };

            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Task>();

            int rows;
            if (task.Id != 0)
            {
                rows = conn.Update(task);
            }
            else
            {
                rows = conn.Insert(task);
            }

            if (rows > 0)
                await DisplayAlert("Success", "Task successfully added", "OK");
            else
                await DisplayAlert("Error", "Failed to add the task", "OK");

            conn.Close();


            await Navigation.PopAsync();
        }

        private async void deleteTask_Clicked(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Task>();
            if (task != null)
                conn.Delete(task);
            conn.Close();

            await Navigation.PopAsync();


        }

        private async void deleteAllTask_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Task>();
            conn.DeleteAll<Task>();
            conn.Close();

            await Navigation.PopAsync();
        }

        private async void cancelTask_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}