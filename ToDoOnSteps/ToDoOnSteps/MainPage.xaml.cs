﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoOnSteps
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            startlogo.Source = ImageSource.FromResource("ToDoOnSteps.Img.startLogo.png");
        }

        private async void nextPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoList());
        }
    }
}
