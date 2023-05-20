using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookManger_WPF
{
    //快捷键propa+Tab键，新建附加属性

    class PasswordBoxHelper
    {
        public static string GetMyPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(MyPasswordProperty);
        }

        public static void SetMyPassword(DependencyObject obj, string value)
        {
            obj.SetValue(MyPasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPasswordProperty =
            DependencyProperty.RegisterAttached("MyPassword", typeof(string), typeof(PasswordBoxHelper));



        public static bool GetIsEnableBind(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnableBindProperty);
        }

        public static void SetIsEnableBind(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnableBindProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsEnableBind.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEnableBindProperty =
            DependencyProperty.RegisterAttached("IsEnableBind", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false,OnPasswordPropertyChanged));

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwd = d as PasswordBox;
            if (pwd == null)
            {
                return;
            }

            if ((bool)e.OldValue)
                pwd.PasswordChanged -= OnPwdProChanged;
            if((bool)e.NewValue)
                pwd.PasswordChanged += OnPwdProChanged;
        }

        private static void OnPwdProChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pwd = sender as PasswordBox;

            SetMyPassword(pwd, pwd.Password);
        }
    }
}
