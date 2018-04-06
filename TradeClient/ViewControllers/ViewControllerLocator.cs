using System;
using System.Collections.Generic;
using System.Text;

namespace TradeClient
{
    public class ViewControllerLocator
    {
       
        public DetailViewController DetailView
        {
            get
            {
                if (DetailViewController.DetailView == null)
                {
                    DetailViewController.DetailView = NavigationViewController.NavigationView.Storyboard.InstantiateViewController("DetailViewController") as DetailViewController;
                }
                return DetailViewController.DetailView;
            }
        }
        public LoginViewController LoginView
        {
            get
            {
                if (LoginViewController.LoginView == null)
                {
                    LoginViewController.LoginView = NavigationViewController.NavigationView.Storyboard.InstantiateViewController("LoginViewController") as LoginViewController;
                }
                return LoginViewController.LoginView;
            }
        }

        public SignupViewController SignupView
        {
            get
            {
                if (SignupViewController.SignupView == null)
                {
                    SignupViewController.SignupView = NavigationViewController.NavigationView.Storyboard.InstantiateViewController("SignupViewController") as SignupViewController;
                }
                return SignupViewController.SignupView;
            }
        }

        public BalanceViewController BalanceView
        {
            get
            {
                if (BalanceViewController.BalanceView == null)
                {
                    BalanceViewController.BalanceView = NavigationViewController.NavigationView.Storyboard.InstantiateViewController("BalanceViewController") as BalanceViewController;
                }
                return BalanceViewController.BalanceView;
            }
        }
    }
}
