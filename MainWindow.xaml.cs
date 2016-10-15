using Microsoft.Win32;
using System.Windows;
using System.Reflection;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Media.Animation;

namespace BakaScheduler {
    class WordsUnit {
        public int consNum; //约束条件
      
    }
    class WordsList {

        public WordsList(string file) {
        }
    }
    class DialogAnimation {
        static DoubleAnimation da = new DoubleAnimation();
        public static void ObjectOpacityTrans(float start, float end, float second, UIElement fe) {
            da.From = start;
            da.To = end;
            da.Duration = TimeSpan.FromSeconds(second);
            fe.BeginAnimation(UIElement.OpacityProperty, da);
        }

    }

    class WordsManager {
        Dictionary<string, WordsList> dw = new Dictionary<string, WordsList>();
    }
    public partial class MainWindow : Window {
        void RegRun(string appName, bool f) {
            RegistryKey HKCU = Registry.CurrentUser;
            RegistryKey Run = HKCU.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            bool b = false;
            foreach (string i in Run.GetValueNames()) {
                if (i == appName) {
                    b = true;
                    break;
                }
            }
            try {
                if (f) {
                    Run.SetValue(appName, Assembly.GetExecutingAssembly().Location);
                }
                else {
                    Run.DeleteValue(appName);
                }
            }
            catch {
            }
            HKCU.Close();
        }
        public void ShowUpDialog() {
            DialogAnimation.ObjectOpacityTrans(0, 0.66f, 0.5f, dialog_grid);
        }

         public void ShutDownDialog() {
            DialogAnimation.ObjectOpacityTrans(0.66f,0 , 0.5f, dialog_grid);
        }



        public MainWindow() {
            InitializeComponent();
            this.ShowInTaskbar = false;
            RegRun("BakaScheduler", true);
            Left = SystemParameters.PrimaryScreenWidth - 400;
      
           
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e) {
            ShutDownDialog();
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) {
            ShowUpDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            SettingWindow s = new SettingWindow();
            s.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) {
            StateMachineMaker smm = new StateMachineMaker();
            smm.Show();
        }
    }
}
