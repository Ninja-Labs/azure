using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using NinjaLab.Redis.Models;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace NinjaLab.Redis.Helpers
{
    public class RedisHelper
    {
        //Cadena de conexión del servicio creado en Azure [password]@[rediscache]?ssl=true
        private const string RedisUri =
            "LkjmVSfgq3QudyrTIvsIjUZSEijb++ZF7U/5D5lp2xY=@ninjacampredis.redis.cache.windows.net?ssl=true";
        private static IRedisClient redisClient;

        //Método requerido para establecer una conexión con el servicio de Redis
        public static void RedisConnection()
        {
            if (redisClient == null)
            {
                var clientsManager = new PooledRedisClientManager(RedisUri);
                redisClient = clientsManager.GetClient();
            }
        }
        //Permite Obtener la lista completa de datos almacenados en Redis
        public static List<Event> GetAll()
        {
            RedisConnection();
            var lstEvents = new List<Event>();
            var keys = redisClient.GetAllKeys();
            if (keys != null && keys.Count() > 0)
            {
                var eventsResult = redisClient.GetAll<string>(keys);
                foreach (var @event in eventsResult)
                {
                    lstEvents.Add(JsonConvert.DeserializeObject<Event>(@event.Value));
                }
            }
            return lstEvents;
        }
        //Permite obtener solo el registro correspondiente a un Id
        public static Event Get(string id)
        {
            RedisConnection();
            var response = redisClient.Get<string>(id);
            return response != null ? JsonConvert.DeserializeObject<Event>(response) : null;
        }
        //Permite remover o eliminar un registro de la cache según su Id
        public static bool Remove(string id)
        {
            RedisConnection();
            return redisClient.Remove(id);
        }
        //Permite almacenar o guardar un registro en redis cache con su Id respectivo
        public static bool Set(Event @event)
        {
            RedisConnection();
            return redisClient.Set(@event.Id.ToString(), JsonConvert.SerializeObject(@event));
        }
    }
}