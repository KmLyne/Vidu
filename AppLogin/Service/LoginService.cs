﻿using AppLogin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Service
{
    public class LoginService : ILoginRepository
    {
        public async Task<UserInfo> Login(string username, string password)
        {
            var userInfo = new List<UserInfo>();
            var client = new HttpClient();

            string url = "http://192.168.1.107:8099/api/UserIfoes/LoginUser/"+username+"/"+password;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage  response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                userInfo = JsonConvert.DeserializeObject<List<UserInfo>>(content);

                return await Task.FromResult(userInfo.FirstOrDefault());
            }
            else
            {
                return null;
            }
        }
    }
}
