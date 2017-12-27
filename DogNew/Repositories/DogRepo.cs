using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DogNew.api;
using Newtonsoft.Json;

namespace DogRepo.Repository
{
    public class DogResponse
    {
        public string Status { get; set; }
        public List<string> Message { get; set; }
    }
    public class DogImageResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
    public class DogRepository
    {
        private string _dogBaseUrl;
        public DogRepository()
        {
            _dogBaseUrl = "https://dog.ceo/api/";
        }

        public async Task<List<string>> GetBreedList()
        {
            var client = new HttpClient();
             var response = await client.GetAsync(_dogBaseUrl + "breeds/list");
           
            //some logic
            var content = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<DogResponse>(content);

            return list.Message;
            
        }
         public async Task<String> GetImagesList(String name)  
         {
             
              var client = new HttpClient();
              var response = await client.GetAsync(_dogBaseUrl + "breed/" +name + "/images/random");
            
            var content = await response.Content.ReadAsStringAsync();
            var images = JsonConvert.DeserializeObject<DogImageResponse>(content);

            return images.Message;
         }

         public async Task<List<DogModel>>loadBothAsync()
         {
             List<String> Listed=new List<string>();
             Listed=await GetBreedList();
            List<DogModel> Doglist=new List<DogModel>(); 
            for(int i=0;i<10;i++)
            {
                Doglist.Add(new DogModel(){DogList=Listed[i],DogImage=await GetImagesList(Listed[i]) } );
            }       
             
             return Doglist;
        }
    }
    }