using Newtonsoft.Json;
using Scoutome.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scoutome.DAO
{
    public class DataAccessObject
    {
        private ObservableCollection<Anime> myAnimeListView = new ObservableCollection<Anime>();
        private ObservableCollection<Reunion> myReunionList = new ObservableCollection<Reunion>();

        public DataAccessObject()
        {

        }

        public ObservableCollection<Anime> getChildrenList ()
        {
            CallWebApiAsyncListAnime();
            return myAnimeListView;
        }

        public async Task CallWebApiAsyncListAnime()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://scoutome.azurewebsites.net/api/animes");
            string json = await response.Content.ReadAsStringAsync();
            var animes = Newtonsoft.Json.JsonConvert.DeserializeObject<Anime[]>(json);


            List<Anime> li = new List<Anime>();
            li = animes.ToList<Anime>();

            for (int i = 0; i < li.Count(); i++)
            {
                myAnimeListView.Add(li[i]);
            }
        }

        public void addReunion (Reunion reunion, ObservableCollection<Anime> selectedAnime)
        {
            CallWebApiAddReunion(reunion, selectedAnime);
        }

        public async Task<bool> CallWebApiAddReunion(Reunion reunion, ObservableCollection<Anime> selectedAnime)
        {
            HttpClient client = new HttpClient();
            string json = JsonConvert.SerializeObject(reunion);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://scoutome.azurewebsites.net/api/reunions", content);
            if (response.IsSuccessStatusCode)
            {
                //    Pour ajouter les présences  
                for (int i = 0; i < selectedAnime.Count(); i++)
                {
                    Presences pre = new Presences();
                    pre.codeReunion = reunion.codeReunion;
                    pre.useless = 1;
                    pre.codeAnime = selectedAnime[i].codeAnime;

                    string jsonPresence = JsonConvert.SerializeObject(pre);
                    HttpContent contentPresence = new StringContent(jsonPresence, Encoding.UTF8, "application/json");
                    HttpResponseMessage responsefav = await client.PostAsync("http://scoutome.azurewebsites.net/api/presences", contentPresence);
                    if (responsefav.IsSuccessStatusCode)
                    {

                    }
                }

            }
            return false;
        }

        public ObservableCollection<Reunion> getReunionList ()
        {
            CallWebApiReunionList();
            return myReunionList;
        }

        public async Task CallWebApiReunionList()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://scoutome.azurewebsites.net/api/reunions");
            string json = await response.Content.ReadAsStringAsync();
            var reunions = Newtonsoft.Json.JsonConvert.DeserializeObject<Reunion[]>(json);
            
            List<Reunion> li = new List<Reunion>();
            li = reunions.ToList<Reunion>();

            for (int i = 0; i < li.Count(); i++)
            {
                myReunionList.Add(li[i]);
            }
        }
    }
}
