using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication13.Models;
using AvaloniaApplication13.Repositories;
using AvaloniaApplication13.ViewModels;

namespace AvaloniaApplication13
{
    public partial class MainWindow : Window
    {
        private BaseRepository<User> _userRepository = new BaseRepository<User>();

        public MainWindow()
        {
            InitializeComponent();
          
            DataContext = new MainViewModel();

        }
        public void Register_Click(object? sender, RoutedEventArgs e)
        {
          
            
                LoginPanel.IsVisible = false;
                Register.IsVisible = true;
             
            
         
        }
        public void Back_Click(object? sender, RoutedEventArgs e)
        {
            LoginPanel.IsVisible = true;
            Register.IsVisible = false;
          
        }
       
    
    }
}