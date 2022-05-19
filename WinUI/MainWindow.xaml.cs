﻿using Business;
using DataAccess.Concrete.Dapper;
using System.Windows;
using System.Windows.Input;
using WinUI.Helper.Menu;

namespace WinUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            faktory = new DataFaktory();
            MenuList.ItemsSource = TreeViewMenuManager.GetMenu(faktory);
           
        }
        DataFaktory faktory;
        private void Close_Click(object sender, RoutedEventArgs e)
        {
               Close();
        }

        private void ListBoxDemo_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var item = (MenuList.SelectedItem as TreeViewMenuChlid);
            ContentView.Content = item != null ? item.Path : null;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (Maximize.IsChecked==true)
            {
                WindowState=WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }
    }
}
