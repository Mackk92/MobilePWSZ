using Android.Util;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using BazusApi;
using MobilePWSZService;


namespace AndroidApp
{
    public class ServiceAgent
    {

        private static EndpointAddress endPoint = new EndpointAddress("http://77.245.247.158:4198/Service1.svc");
        public static BasicHttpBinding binding;
        public bool validCheck { get; set; }
        public string passHash { get; set; }

        public string AddWydarz { get; set; }
        public string PlanUpdated { get; set; }

        private LessonPlan plan = new LessonPlan();

        static ServiceAgent()
        {
            binding = CreateBasicHttpBinding();
        }

        private static BasicHttpBinding CreateBasicHttpBinding()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };

            TimeSpan timeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            return binding;
        }

        public static async Task<bool> GetAuthenticate(string value1, string value2, string value3)
        {
            IService1 _client;
            try
            {
                // object a = new object();

                // var res = Task<bool>.Factory.FromAsync(test, test1, null);
                //_client.BeginGetAuthenticate,
                //_client.EndGetAuthenticate, value1, value2, null);

                _client = new Service1Client(binding, endPoint);
                var res = Task<bool>.Factory.FromAsync(_client.BeginGetAuthenticate, _client.EndGetAuthenticate, value1,
                    value2, value3, null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<string> GetHash(string value1, string value2)
        {
            IService1 _client;
            try
            {
                // object a = new object();

                // var res = Task<bool>.Factory.FromAsync(test, test1, null);
                //_client.BeginGetAuthenticate,
                //_client.EndGetAuthenticate, value1, value2, null);

                _client = new Service1Client(binding, endPoint);
                var res = Task<string>.Factory.FromAsync(_client.BeginGetHash, _client.EndGetHash, value1,
                    value2, null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static async Task<bool> GetRegister(string value1, string value2, string value3)
        {
            IService1 _client;
            try
            {
                // object a = new object();

                // var res = Task<bool>.Factory.FromAsync(test, test1, null);
                //_client.BeginGetAuthenticate,
                //_client.EndGetAuthenticate, value1, value2, null);

                _client = new Service1Client(binding, endPoint);
                var res = Task<bool>.Factory.FromAsync(_client.BeginGetRegister, _client.EndGetRegister, value1, value2,
                    value3,
                    null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<string> GetCheckPlanUpdate(string kierunek, string rok)
        {
            IService1 _client;
            try
            {
                // object a = new object();

                // var res = Task<bool>.Factory.FromAsync(test, test1, null);
                //_client.BeginGetAuthenticate,
                //_client.EndGetAuthenticate, value1, value2, null);

                _client = new Service1Client(binding, endPoint);
                var res = Task<string>.Factory.FromAsync(_client.BeginGetUpdatedPlan, _client.EndGetUpdatedPlan,
                    kierunek, rok,
                    null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static async Task<LessonPlan> GetPlan(string value1, DateTime value2)
        {
            IService1 _client;
            try
            {
                // object a = new object();

                // var res = Task<bool>.Factory.FromAsync(test, test1, null);
                //_client.BeginGetAuthenticate,
                //_client.EndGetAuthenticate, value1, value2, null);

                _client = new Service1Client(binding, endPoint);
                var res = Task<LessonPlan>.Factory.FromAsync(_client.BeginGetPlan, _client.EndGetPlan, value1, value2,
                    null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<string> AddWydarzenie(string indeks, DateTime date, string tytul_tekst)
        {
            IService1 _client;
            try
            {
                // object a = new object();

                // var res = Task<bool>.Factory.FromAsync(test, test1, null);
                //_client.BeginGetAuthenticate,
                //_client.EndGetAuthenticate, value1, value2, null);

                _client = new Service1Client(binding, endPoint);
                var res = Task<string>.Factory.FromAsync(_client.BeginDodajWydarzenie, _client.EndDodajWydarzenie, indeks,
                    date, tytul_tekst,
                    null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<LessonPlan[]> GetPlan7(string value1, string value2)
        {
            IService1 _client;
            try
            {
                // object a = new object();

                // var res = Task<bool>.Factory.FromAsync(test, test1, null);
                //_client.BeginGetAuthenticate,
                //_client.EndGetAuthenticate, value1, value2, null);

                _client = new Service1Client(binding, endPoint);
                var res = Task<LessonPlan[]>.Factory.FromAsync(_client.BeginAktualneNa7, _client.EndAktualneNa7, value1,
                    value2, null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<wydarzenia[]> GetWydarzenia(string value1)
        {
            IService1 _client;
            try
            {
                // object a = new object();

                // var res = Task<bool>.Factory.FromAsync(test, test1, null);
                //_client.BeginGetAuthenticate,
                //_client.EndGetAuthenticate, value1, value2, null);

                _client = new Service1Client(binding, endPoint);
                var res = Task<wydarzenia[]>.Factory.FromAsync(_client.BeginGetWydarzenia, _client.EndGetWydarzenia,
                    value1,
                    null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<News[]> GetNews()
        {
            IService1 _client;
            try
            {
                // object a = new object();

                // var res = Task<bool>.Factory.FromAsync(test, test1, null);
                //_client.BeginGetAuthenticate,
                //_client.EndGetAuthenticate, value1, value2, null);

                _client = new Service1Client(binding, endPoint);
                var res = Task<News[]>.Factory.FromAsync(_client.BeginGetNews, _client.EndGetNews, null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> GetReset(string value1, string value2, string value3)
        {
            IService1 _client;
            try
            {
                object a = new object();

                System.AsyncCallback callback;
                object asyncState;

                _client = new Service1Client(binding, endPoint);
                var res = Task<bool>.Factory.FromAsync(_client.BeginGetReset, _client.EndGetReset, value1, value2,
                    value3, null);

                res.Wait();

                await res;
                return res.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ValidLogin(string val1, string val2, string val3)
        {
            var task = await ServiceAgent.GetAuthenticate(val1, val2, val3);

            validCheck = task;
            return task;
        }

        public async Task<string> ValidHash(string val1, string val2)
        {
            var task = await ServiceAgent.GetHash(val1, val2);

            passHash = task;
            return passHash;
        }

        public async Task<string> ValidPlan7(string val1, string val2)
        {
            var task = await ServiceAgent.GetPlan7(val1, val2);

            SetPlan7(task);
            return passHash;
        }

        public async Task<bool> ValidRegister(string val1, string val2, string val3)
        {
            var task = await ServiceAgent.GetRegister(val1, val2, val3);

            validCheck = task;
            return task;
        }

        public async Task<string> ValidPlanUpdate(string val1, string val2)
        {
            var task = await ServiceAgent.GetCheckPlanUpdate(val1, val2);

            string t = task;
            PlanUpdated = t;
            return t;
        }

        public async Task<bool> ValidReset(string val1, string val2, string val3)
        {
            var task = await ServiceAgent.GetReset(val1, val2, val3);

            validCheck = task;
            return task;
        }

        public async Task<string> ValidDodajWydarze(string val1, DateTime val2, string val3)
        {
            var task = await ServiceAgent.AddWydarzenie(val1, val2, val3);

            AddWydarz = task;
            return task;
        }

        public async Task<LessonPlan> ValidPlan(string val1, DateTime val2)
        {
            LessonPlan task = await ServiceAgent.GetPlan(val1, val2);

            SetPlan(task);
            return task;
        }

        public async Task<wydarzenia[]> ValidGetWydarzenia(string val1)
        {
            wydarzenia[] task = await ServiceAgent.GetWydarzenia(val1);

            SetWydarze(task);
            return task;
        }

        public async Task<News[]> ValidNews()
        {
            News[] task = await ServiceAgent.GetNews();

            SetNewss(task);
            return task;
        }

        private LessonPlan les;
        private News[] Newses;
        private LessonPlan[] Plan7;
        private wydarzenia[] Wyda;

        public LessonPlan GetPlan()
        {
            return les;
        }

        public wydarzenia[] GetWyd()
        {
            return Wyda;
        }

        public void SetWydarze(wydarzenia[] s)
        {
            Wyda = s;
        }

        public News[] GetNewss()
        {
            return Newses;
        }

        public LessonPlan[] GetPlan7()
        {
            return Plan7;
        }

        public void SetPlan(LessonPlan s)
        {
            les = s;
        }

        public void SetPlan7(LessonPlan[] s)
        {
            Plan7 = s;
        }

        public void SetNewss(News[] s)
        {
            Newses = s;
        }
    }
}