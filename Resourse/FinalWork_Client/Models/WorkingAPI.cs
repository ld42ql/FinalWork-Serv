using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Windows;
using Newtonsoft.Json;
using System.Text;

namespace FinalWork_Client.Models
{
    

    class WorkingAPI
    {
        WebClient webClient = new WebClient();

        /// <summary>
        /// Создаем адрес, с кодировкой UTF8
        /// </summary>
        /// <param name="urlMetod">Имя метода из API</param>
        /// <returns></returns>
        private string ConnectionUrl(string urlMetod)
        {
            webClient.Encoding = System.Text.Encoding.UTF8;
            return $"http://localhost:62975/{urlMetod}";
        }

        /// <summary>
        /// Показать всю таблицу
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Employee> ViewList()
        {
            var temp = webClient.DownloadString(ConnectionUrl("getList/"));

            return JsonConvert.DeserializeObject<ObservableCollection<Employee>>(temp);
        }

        /// <summary>
        /// Показать работника
        /// </summary>
        /// <param name="id">Номер работника</param>
        /// <returns></returns>
        public Employee ViewEmployee(int id)
        {
            var temp = webClient.DownloadString($"{ConnectionUrl("getList/")}{id}");
            return JsonConvert.DeserializeObject<Employee>(temp);
        }
    }
}
