using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Services.Dialogs;
using System;
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
using WpfSchedules.Models;

namespace WpfSchedules
{
    public partial class MainWindow : Window
    {
        private readonly string _mainUrl;
        private string resultRequest;
        public JObject jwtModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainUrl = "https://localhost:44317";
            resultRequest = "";
            jwtModel = new JObject();
        }

        private void bShowEvents(object sender, RoutedEventArgs e)
        {
            FillEventDataGrid();
        }

        private void bCreateEvent(object sender, RoutedEventArgs e)
        {
            var eventEntity = new EventCreateDto
            {
                Name = (string)tName.Text,
                HoldingDate = (DateTime)dpHoldingDate.SelectedDate,
                UserCreateId = (int)jwtModel["userId"],
                Description = (string)tDescription.Text
            };
             CreateEvent(eventEntity);
        }
      
        private void bDelete(object sender, RoutedEventArgs e)
        {
            Object listEvents = gEvents.SelectedItem;
            DeleteEvent((EventApi)listEvents);
        }

        private void bLogIn(object sender, RoutedEventArgs e)
        {
            var loginData = new LoginModel
            {
                Email = (string)tbLogin.Text,
                Password = (string)tbLoginPassword.Text
            };
            Authenticate(loginData);
        }

        private void bSingUp(object sender, RoutedEventArgs e)
        {
            var singupData = new UserCreateModel
            {
                FirstName = (string)tbFirstName.Text,
                LastName = (string)tbLastName.Text,
                Email = (string)tbEmail.Text,
                Password = (string)tbPassword.Text
            };
            UserSingUp(singupData);
        }

        private void bExit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }



        private void CreateEvent(EventCreateDto entity)
        {                    
            string url = string.Format(_mainUrl + "/api/event/add");

            HttpClient client = new HttpClient();
           
            var json = JsonConvert.SerializeObject(entity);

            var stringContent1 = new StringContent(json, Encoding.UTF8, "application/json");
                       
            client.PostAsync(url, stringContent1)
                      .ContinueWith(response =>
                      {
                          if (response.Exception != null)
                          {
                              MessageBox.Show(response.Exception.Message);
                          }
                          else
                          {
                              FillEventDataGrid();                              
                          }
                      });
            lText.Content = "Event " + tName.Text + "successfully created";
        }

        private void DeleteEvent(EventApi entity)
        {
            HttpClient client = new HttpClient();

            string url = string.Format(_mainUrl + "/api/event/delete/" + entity.Id);

            client.GetAsync(url)
                .ContinueWith(response =>
                {
                    if (response.Exception != null)
                    {
                        MessageBox.Show(response.Exception.Message);
                    }
                    else
                    {
                        FillEventDataGrid();
                    }
                });
        }

        public void FillEventDataGrid()
        {
            HttpClient client = new HttpClient();

            string url = string.Format(_mainUrl + "/api/event/geteventsbyuserId?id=" + jwtModel["userId"]);

            client.GetAsync(url)
                .ContinueWith(response =>
                {
                    if (response.Exception != null)
                    {
                        MessageBox.Show(response.Exception.Message);
                    }
                    else
                    {
                        HttpResponseMessage message = response.Result;
                        string responseText = message.Content.ReadAsStringAsync().Result;
                        JavaScriptSerializer jss = new JavaScriptSerializer();

                        var serializedProduct = JsonConvert.SerializeObject(responseText);

                        dynamic json = JsonConvert.DeserializeObject(serializedProduct);
                        List<EventApi> sad = JsonConvert.DeserializeObject<List<EventApi>>(json);
                        this.Dispatcher.Invoke(() =>
                        {
                            gEvents.ItemsSource = sad;
                        });
                    }
                });
        }

        public void Authenticate(LoginModel model) 
        {
            var res = this.Dispatcher.Invoke(async () => {
                HttpClient client = new HttpClient();
                string url = string.Format(_mainUrl + "/api/authenticate/auth");
                var json = JsonConvert.SerializeObject(model);

                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response =  await client.PostAsync(url, stringContent);

                this.resultRequest = response.Content.ReadAsStringAsync().Result;

                JavaScriptSerializer jss = new JavaScriptSerializer();

                var serializedProduct = JsonConvert.SerializeObject(this.resultRequest);

                var jsonAnswer =  JsonConvert.DeserializeObject(serializedProduct);
                this.jwtModel = JObject.Parse((string)jsonAnswer);

                if (this.jwtModel["access_token"] != null)           
                {
                    this.tiWorkSpace.Visibility = Visibility.Visible;
                    this.tiWorkSpace.Focus();
                    this.tiLogin.Visibility = Visibility.Collapsed;
                }
            });
        }

        public void UserSingUp(UserCreateModel model)
        {
            var a = this.Dispatcher.Invoke(async () => {
                HttpClient client = new HttpClient();
                string url = string.Format(_mainUrl + "/eventschedules/user/add");
                var json = JsonConvert.SerializeObject(model);

                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, stringContent);

                this.resultRequest = response.Content.ReadAsStringAsync().Result;

                MessageBox.Show("User created", "Notify",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                this.tiLoginPage.Focus();
            });
        }
    }
}
