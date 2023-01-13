using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace M015;

public partial class MainWindow : Window
{
	public int Counter;

	public MainWindow()
	{
		InitializeComponent();

		CB.ItemsSource = new List<string>() { "E1", "E2", "E3" };
		LB.ItemsSource = new List<string>() { "L1", "L2", "L3" };
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		TB.Text = (++Counter).ToString();

		Window2 w2 = new Window2();
		w2.Show(); //erzeugt ein neues Fenster
		bool? b = w2.ShowDialog(); //erzeugt ein neues Fenster das den Hintergrund blockiert
		if (b == true)
		{

		}
	}

	private void CB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
	{
		TB.Text = CB.SelectedItem.ToString();
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		TB.Text = "Checkbox gecheckt";
	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{
		TB.Text = "Checkbox ungecheckt";
	}

	private void RadioButton_Checked(object sender, RoutedEventArgs e)
	{
		RadioButton rb = sender as RadioButton;
		switch (rb.Content.ToString())
		{

		}
	}

	private void MenuItem_Click(object sender, RoutedEventArgs e)
	{
		MessageBoxResult res = MessageBox.Show("Willst du wirklich beenden?", "Beenden", MessageBoxButton.YesNo, MessageBoxImage.Question);
		if (res == MessageBoxResult.Yes)
			Environment.Exit(0);
	}
}
