using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

/* 
   you can enter at least 3 values
   1- enter 1.0 , then click "+" button
   2- enter 2.0 , then click "+" button
   3- enter 3.0 , then click "=" button to show all calculated results.
   4- click "C" button to clear all value for starting next turn. 

*/

namespace RohitAPP
{
   
    public sealed partial class MainPage : Page
    {
       
        private int i = 0;
        private double[] firstnum = new double [3];
        //private List<double> text = new List<double>();
        private double numSum;
        private double numAver;
        

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void buttonAddition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*firstnum get value from the TextBox*/
                firstnum[i] = Double.Parse(TBdisplaytext.Text);
                numSum += firstnum[i];
                TBdisplaytext.Text = " ";
                i++;
            }
            catch(Exception ex)
            {
                TBLErrorHanding.Text = ex.ToString();
            }
           

        }

        private void buttonEqual_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                firstnum[i] = Double.Parse(TBdisplaytext.Text);

                /* Sum */
                numSum += firstnum[i];
                TBLSumValue.Text = String.Format("{0:0.00}", numSum);


                /* Average */
                //numAver = numSum / (i+1);
                numAver = firstnum.Average();
                TBLAverValue.Text = String.Format("{0:0.00}", numAver);


                /* Standard Divation */
                double average = firstnum.Average();
                //double average = numAver;
                double sumOfSquaresOfDifferences = firstnum.Select(val => (val - average) * (val - average)).Sum();
                double SD = Math.Sqrt(sumOfSquaresOfDifferences / firstnum.Length);
                TBLSDValue.Text = String.Format("{0:0.00}", SD);
                TBdisplaytext.Text = " ";
            }
            catch(Exception ex)
            {
                TBLErrorHanding.Text = ex.ToString();
            }
          
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            /* clear all data  */
            TBdisplaytext.Text = " ";
            TBLAverValue.Text = " ";
            TBLSDValue.Text = " ";
            TBLSumValue.Text = " ";
            i = 0;
            numAver = 0.0;
            numSum = 0.0;
            Array.Clear(firstnum, 0, firstnum.Length);
            TBLErrorHanding.Text = " ";
        }
    }
}
