using BookStoreApi.Models.DatabaseModels;
using Microsoft.Win32;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;

namespace BookStoreWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync($"https://localhost:44352/api/books/{textBox1.Text}");
				response.EnsureSuccessStatusCode();

				if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
				{
					var contentStream = await response.Content.ReadAsStreamAsync();
					var streamReader = new StreamReader(contentStream);

					try
					{
						var book = await JsonSerializer.DeserializeAsync<Book>(contentStream,
													new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

						Uri resourceUri = new Uri($"{book.Path}");
						imgDynamic.Source = new BitmapImage(resourceUri);
					}

					catch (JsonException) // Invalid JSON
					{
						throw new Exception("Invalid JSON.");
					}
				}

				else
				{
					throw new Exception("HTTP Response was invalid and cannot be deserialised.");
				}
			}
		}
	}
}
