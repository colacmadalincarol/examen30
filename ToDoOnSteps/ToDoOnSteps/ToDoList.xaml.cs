using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoOnSteps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoList : ContentPage
    {

        private ObservableCollection<Task> _task;
        public ToDoList()
        {
            InitializeComponent();
        }

        private async void AddTask(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTask());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Task>();

            var task = conn.Table<Task>().ToList();

            _task = new ObservableCollection<Task>(task);

            tasksListView.ItemsSource = _task;
            conn.Close();
        }

        private async void tasksListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddTask
                {
                    BindingContext = e.SelectedItem as Task
                });
            }
        }

        private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checbox = sender as CheckBox;
            var task = checbox.BindingContext as Task;

            if (task != null)
            {
                task.Checked = e.Value;
                SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
                conn.CreateTable<Task>();
                int rows = conn.Update(task);
                conn.Close();
            }
        }
    }
}