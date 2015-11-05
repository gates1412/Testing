using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfProgressBarDemo
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			Process();
		}


		//********************************
		//  WPF ProgressBar Demo
		//  Written by VBRocks, 7/28/09
		//********************************
		

		//Create a Delegate that matches the Signature of the ProgressBar's SetValue method
		private delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);


		private void Process()
		{
			//Configure the ProgressBar
			ProgressBar1.Minimum = 0;
			ProgressBar1.Maximum = short.MaxValue;
			ProgressBar1.Value = 0;

			//Stores the value of the ProgressBar
			double value = 0;

			//Create a new instance of our ProgressBar Delegate that points
			//  to the ProgressBar's SetValue method.
			UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(ProgressBar1.SetValue);

			//Tight Loop:  Loop until the ProgressBar.Value reaches the max
			do
			{
				value += 1;

	            /*Update the Value of the ProgressBar:
		          1)  Pass the "updatePbDelegate" delegate that points to the ProgressBar1.SetValue method
			      2)  Set the DispatcherPriority to "Background"
				  3)  Pass an Object() Array containing the property to update (ProgressBar.ValueProperty) and the new value */
				Dispatcher.Invoke(updatePbDelegate, 
					System.Windows.Threading.DispatcherPriority.Background, 
					new object[] { ProgressBar.ValueProperty, value });

			}
			while (ProgressBar1.Value != ProgressBar1.Maximum);

		}
	}
}
