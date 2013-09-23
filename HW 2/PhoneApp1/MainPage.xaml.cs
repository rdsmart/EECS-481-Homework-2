using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using System.Windows.Threading;


namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        int ball_x = 150;
        double left_wall_x;
        double right_wall_x;
        int direction = 1;
        int direction2 = 1;
        int direction3 = 1;
             
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            DispatcherTimer newTimer = new DispatcherTimer();
            // timer interval specified as 1 second
            newTimer.Interval = TimeSpan.FromSeconds(.0005);
            // Sub-routine OnTimerTick will be called at every 1 second
            newTimer.Tick += OnTimerTick;
            // starting the timer
            newTimer.Start();
            left_wall_x = Canvas.GetLeft(Left_Wall);
            right_wall_x = Canvas.GetLeft(Right_Wall);
            Canvas.SetLeft(Ball, ball_x);
        }//end main page

//Funtion to move objects on timer tick//////////////////////////////////////////////
        void moveBall(int direction, int direction2, int direction3)
        {
            if (direction == 0)
            {
                ball_x = ball_x - 5;
               // y = y - 30;
            }
            else if (direction == 1)
            {
                ball_x = ball_x + 5;
                //y = y - 30;
            }

            if (direction2 == 0)
            {
                left_wall_x = left_wall_x - 2;
                // y = y - 30;
            }
            else if (direction2 == 1)
            {
                left_wall_x = left_wall_x + 2;
                //y = y - 30;
            }

            if (direction3 == 0)
            {
                right_wall_x = right_wall_x - 2;
                // y = y - 30;
            }
            else if (direction3 == 1)
            {
                right_wall_x = right_wall_x + 2;
                //y = y - 30;
            }
        }//end move ball

//TImer tick function//////////////////////////////////////////////////////////////////////////
        void OnTimerTick(Object sender, EventArgs args)
        {
            if (Canvas.GetLeft(Ball) > (Canvas.GetLeft(Right_Wall) - Ball.Width))
            {
                direction = 0;
            }
            if (Canvas.GetLeft(Ball) < (Canvas.GetLeft(Left_Wall) + Left_Wall.Width))
            {
                direction = 1;
            }

            if (Canvas.GetLeft(Left_Wall) > 200)
            {
                direction2 = 0;
            }
            if (Canvas.GetLeft(Left_Wall) < 0)
            {
                direction2 = 1;
            }

            if (Canvas.GetLeft(Right_Wall) > 450)
            {
                direction3 = 0;
            }
            if (Canvas.GetLeft(Right_Wall) < 300)
            {
                direction3 = 1;
            }
            moveBall(direction, direction2, direction3);
            Canvas.SetLeft(Ball, ball_x);
            Canvas.SetLeft(Left_Wall, left_wall_x);
            Canvas.SetLeft(Right_Wall, right_wall_x);
        }//end on timer tick

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}