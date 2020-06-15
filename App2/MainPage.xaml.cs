using App2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App2;
using Windows.ApplicationModel.Activation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string num;
        public Student click;
        ObservableCollection<Student> students =new  ObservableCollection<Student>();
        public MainPage()
        {
            this.InitializeComponent();
            FirstStep();
            list.ItemsSource = students;
        }
        private void FirstStep()
        {
            students.Add(new Student { SNo = "1", INo = "1", Name = "A", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
            students.Add(new Student { SNo = "2", INo = "3", Name = "B", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
            students.Add(new Student { SNo = "3", INo = "3", Name = "C", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
            students.Add(new Student { SNo = "4", INo = "4", Name = "D", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
            students.Add(new Student { SNo = "5", INo = "5", Name = "E", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
            students.Add(new Student { SNo = "6", INo = "6", Name = "F", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
            students.Add(new Student { SNo = "7", INo = "7", Name = "G", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
            students.Add(new Student { SNo = "8", INo = "8", Name = "H", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
            students.Add(new Student { SNo = "9", INo = "9", Name = "I", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
            students.Add(new Student { SNo = "10", INo = "10", Name = "J", Age = "18", height = "170", Weight = "60", var1 = "1", gender = "Male", var3 = "1", var2 = "1" });
        }

        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = e.ClickedItem;
            click = (Student)clickedItem;
            num = click.SNo;
            string message = click.Name + " " + click.Age + " " + click.gender;
            MessageDialog messageDialog1 = new MessageDialog(message);
            await messageDialog1.ShowAsync();  
            Edit.Visibility = Visibility.Visible;
            fillDetails(e);
            
        }

        private void fillDetails(ItemClickEventArgs e)
        {
            var clickedItem = e.ClickedItem;
            var click1 = (Student)clickedItem;
            gender.Text = click1.gender;
            name.Text = click1.Name;
            age.Text = click1.Age;
            sno.Text = click1.SNo;
            ino.Text = click1.INo;
            height.Text = click1.height;
            weight.Text = click1.Weight;
            
        }
        private void editing_Click(object sender, RoutedEventArgs e)
        {
            EnablingFunction();
        }

        private void EnablingFunction()
        {
            gender.IsEnabled = !gender.IsEnabled;
            name.IsEnabled = !name.IsEnabled;
            age.IsEnabled = !age.IsEnabled;
            sno.IsEnabled = !sno.IsEnabled;
            ino.IsEnabled = !ino.IsEnabled;
            height.IsEnabled = !height.IsEnabled;
            weight.IsEnabled = !weight.IsEnabled;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            
            click.Age = age.Text;
            foreach (var s in students)
            {
                if (s.SNo == num)
                {
                    s.SNo = sno.Text;
                    s.INo = ino.Text;
                    s.Name = name.Text;
                    s.Age = age.Text;
                    s.gender = gender.Text;
                    s.height = height.Text;
                    s.Weight = weight.Text;
                    break;
                }
            }
            EnablingFunction();
            gender.Text = "";
            name.Text = "";
            age.Text = "";
            sno.Text = "";
            ino.Text = "";
            height.Text = "";
            weight.Text = "";
            Edit.Visibility = Visibility.Collapsed;
            list.ItemsSource = null;
            list.ItemsSource = students;


        }
        private void gender_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private  void list_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var send = sender as data;
            var view = send.DataContext as Student;
            var stark= view.Name + "\n" + view.Age + "\n" + view.gender;;
            McTextBlock.Text = view.Name+"\n"+view.Age+"\n"+view.gender;
            Popup1.IsOpen = true;
        }

        private void list_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            McTextBlock.Text = "";
            Popup1.IsOpen = false;
        }
    }
}
