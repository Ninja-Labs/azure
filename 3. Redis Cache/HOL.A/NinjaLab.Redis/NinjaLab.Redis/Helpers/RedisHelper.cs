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

        /// <summary>
        /// Constructor estático, este es invocado cada vez que se hace referencia a un miembro estático.
        /// De esta manera le quitamos la responsabilidad a los metodos estáticos de hacer la conexión con redis
        /// para que se ocupen de la verdadera responsabilidad que debe tener el método.
        /// https://msdn.microsoft.com/es-co/library/k9x6w0hc.aspx
        /// </summary>
        static RedisHelper()
        {
            RedisConnection();
        }

        //Método requerido para establecer una conexión con el servicio de Redis
        private static void RedisConnection()
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
            var response = redisClient.Get<string>(id);
            return response != null ? JsonConvert.DeserializeObject<Event>(response) : null;
        }
        //Permite remover o eliminar un registro de la cache según su Id
        public static bool Remove(string id)
        {
            return redisClient.Remove(id);
        }
        //Permite almacenar o guardar un registro en redis cache con su Id respectivo
        public static bool Set(Event @event)
        {
            return redisClient.Set(@event.Id.ToString(), JsonConvert.SerializeObject(@event));
        }
    }
}