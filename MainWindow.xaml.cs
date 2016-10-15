using Microsoft.Win32;
using System.Windows;
using System.Reflection;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Media.Animation;

namespace BakaScheduler {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    ///


    //    interface Anim {
    //       void Refresh();
    //       int RuningState
    //        {
    //            get;
    //            set;
    //        }


    //}
    //    class AnimState {
    //        public static int STATE_OPENING = 1;
    //        public static int STATE_CLOSING = 2;
    //    }

    //    class DialogTransAnim:Anim{
    //        Image m;
    //        public delegate void AnimOp(Image i,double op);
    //        public AnimOp aop;
    //        int targetOp;
    //        double thisOp;
    //        int state;
    //        public int RuningState
    //        {
    //            get
    //            {
    //                return state;
    //            }
    //            set
    //            {
    //                state = value;
    //            }
    //        }
    //        public DialogTransAnim(Image m) {


    //        }
    //        public static void AnimSetOp(Image m,double i)
    //        {

    //            m.Opacity = i;
    //        }

    //        public DialogTransAnim(Image a,int ta) {
    //            m = a;
    //            state = -1;
    //            aop = new AnimOp(AnimSetOp);
    //            thisOp = m.Opacity;
    //            targetOp = ta;
    //        }
    //        public void Refresh() {
    //            if (state == AnimState.STATE_OPENING) {

    //                if (thisOp < targetOp - 4)
    //                   thisOp += 4;
    //                else
    //                    state = -1;

    //            }
    //            else if(state== AnimState.STATE_CLOSING) {
    //                if (thisOp > 4)
    //                    thisOp -= 4;
    //                else
    //                    state = -1;

    //            }
    //            aop.Invoke(m, thisOp);
    //        }
    //    }
    //    class AnimManager {
    //        public static AnimManager globalAnimManager;
    //        Dictionary<string, Anim> dc = new Dictionary<string, Anim>();
    //        Thread a = new Thread(RefreshAll);
    //        public void AddAnim(string s,Anim a){
    //            dc.Add(s, a);
    //        }

    //        public AnimManager() {
    //            a.Start();
    //        }
    //        public void SetAnimState(string s ,int state) {
    //            Anim tag = dc[s];
    //            if (tag == null) throw null;
    //            dc[s].RuningState = state;

    //        }
    //        public static void  RefreshAll() {
    //            while (true) {
    //                int sum = 0;
    //                foreach (var a in globalAnimManager.dc) {
    //                    Anim b = a.Value;
    //                    if (b.RuningState != -1)
    //                        b.Refresh();
    //                    sum += b.RuningState;
    //                }
    //                Thread.Sleep(33);
    //            }

    //        }

    //    }
    class WordsUnit {
        public int consNum; //约束条件
      
    }
    class WordsList {

        public WordsList(string file) {
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
            DoubleAnimation da = new DoubleAnimation();
            
            da.From = 0;    //起始值
            da.To = 0.66;      //结束值
            da.Duration = TimeSpan.FromSeconds(0.5);         //动画持续时间
            dialog_grid.BeginAnimation(Grid.OpacityProperty, da);//开始动画

        }
        public void ShutDownDialog() {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0.66;    
            da.To = 0;
            da.Duration = TimeSpan.FromSeconds(0.2);
            dialog_grid.BeginAnimation(Grid.OpacityProperty, da);
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
