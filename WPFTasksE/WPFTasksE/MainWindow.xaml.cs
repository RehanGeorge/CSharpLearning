﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace WPFTasksE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(OnHtmlChanged));


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} is running");
                HttpClient webClient = new HttpClient();
                string html = webClient.GetStringAsync("https://google.com").Result;

                MyButton.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} owns MyButton");
                    MyButton.Content = "Done";
                });

                MessageBox.Show("Web request completed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }

        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            string myHtml = "x";
            Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} before awaiting Task");
            await Task.Run(async () =>
            {
                Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} during await Task");
                HttpClient webClient = new HttpClient();
                string html = await webClient.GetStringAsync("https://google.com");
                myHtml = html;
            });
            Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} after awaiting Task");
            MessageBox.Show("Web request completed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            MyButton.Content = "Done";
            MyWebBrowser.SetValue(HtmlProperty, myHtml);
        }

        static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} is running OnHtmlChanged");
            WebBrowser webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null )
            {
                webBrowser.NavigateToString(e.NewValue as string);
            }
        }
    }
}
