using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookManger_WPF
{
    public class LoginViewModel:INotifyPropertyChanged
    {
        private MainWindow _main;
        
        public LoginViewModel(MainWindow mainWindow)
        {
            _main = mainWindow;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private LoginModel _LoginM=new LoginModel();

        public string UserName
        {
            get { return _LoginM.UserName; }
            set
            {
                _LoginM.UserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return _LoginM.Password; }
            set 
            {
                _LoginM.Password = value;
                RaisePropertyChanged("Password");
            }
        }

        void LoginFunc()
        {
            if (UserName == "WPF" && Password == "666")
            {
                //弹出新的界面
                Index index = new Index();
                index.Show();

                _main.Hide();
            }
            else
            {
                //弹出一个警告框
                MessageBox.Show("您输入的用户名或密码不正确，请重新输入");

                UserName = "";
                Password = "";
            }
        }

        bool CanLoginExecute()
        {
            return true;
        }

        //命令
        public ICommand LoginAction
        {
            get
            {
                return new RelayCommond(LoginFunc,CanLoginExecute);
            }
        }
    }
}
