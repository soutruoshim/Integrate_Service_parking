using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Timers;
using System.IO;
using System.Net;
//using System.Text.Json;
using RestSharp;
using Newtonsoft.Json;
using Daikou_service_parking.repo;
using Daikou_service_parking.models;

namespace Daikou_service_parking
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        
        // public SqlConnection connection;
        private IList<Card> cards = new List<Card>();
        private IList<Card> cardsApi = new List<Card>();
        private IList<Card> cardNoneDublic = new List<Card>();
        
        CardRepo cardRepo = new CardRepo();
        OutRecordRepo outRecord = new OutRecordRepo();

        public Service1()
        {
            InitializeComponent();
            // connection = new SqlConnection(@"Data Source = DESKTOP-O73SD5A; Initial Catalog = ParkWatch; Integrated Security = True");
        }

        protected override void OnStart(string[] args)
        {

            //WriteToFile("Service is started at " + DateTime.Now);
            
            // ========card=================
            cards = cardRepo.GetAll();
            readCardsApi();

            //=========outRecord===============
            readOutRecordAndPPost();

            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 10000; //number in milisecinds  
            timer.Enabled = true;
        }
        public void Working()
        {

        }

        protected override void OnStop()
        {
            //WriteToFile("Service is stopped at " + DateTime.Now);
            cards = cardRepo.GetAll();
            readCardsApi();

            // for outRecord
            readOutRecordAndPPost();
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            //WriteToFile("Service is recall at " + DateTime.Now);
            cards = cardRepo.GetAll();
            readCardsApi();

            // for outRecord
            readOutRecordAndPPost();
        }

       
        private void readCardsApi()
        {

        //    var url = "https://eazy.daikou.asia/parking/cards.php";

        //    var httpRequest = (HttpWebRequest)WebRequest.Create(url);

        //    httpRequest.Accept = "*/*";

        /*
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                var result = streamReader.ReadToEnd();
                var cardList = JsonSerializer.Deserialize<IList<Card>>(result);

                foreach (var card in cardList)
                {
                    // Console.WriteLine("Department Id is: {0}", card.CardNo);
                    // Console.WriteLine("Department Name is: {0}", card.CarNo);
                    Card cardObject = new Card(card.CardNo, card.CarNo, card.CardType, card.CardIndate, card.CardAmount, card.CarType, card.CarStyle, card.CarColor, card.MasterName, card.MasterID, card.MasterTel, card.MasterAddr, card.ParkNo, card.ParkPosition, card.PayAmount, card.MakeDateTime, card.OperatorName, card.Enable, card.Remark);

                    cardsApi.Add(cardObject);
                }
            }

            Console.WriteLine(httpResponse.StatusCode);


            IEnumerable<Card> onlyInFirstSet = cardsApi.Except(cards);


            foreach (Card card in onlyInFirstSet)
            {
                Console.WriteLine("none dup" + card.CardNo);
                addCardDataToLocal(card);
            }
            */

            var client = new RestClient("https://eazy.daikou.asia/parking");
            var request = new RestRequest("cards.php");
            var respone = client.Execute(request);
            if (respone.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawRespone = respone.Content;
                //var cardList = JsonConvert.DeserializeObject<Card>(rawRespone);
                List<Card> cardList = JsonConvert.DeserializeObject<List<Card>>(rawRespone);
                foreach (var card in cardList)
                {
                    Console.WriteLine("api: " + card.CardNo);
                    cardRepo.Add(card);
                }
            }
        }
        
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
        private async void readOutRecordAndPPost()
        {
            foreach (var outrepo in outRecord.GetUnsignLimit())
            {
                Console.WriteLine("Record: " + outrepo.RecordNo);
                postOutRecord(outrepo);
            }
        }
        // post outRecord to server
        private async void postOutRecord(OutReport outRecord)
        {
            try
            {
                var client = new RestClient("http://apartment.local/api/parking_register_outrecord.php");
                var request = new RestRequest("", Method.POST);
                //var request = new RestRequest("create", Method.POST);

                var inDateTime = Convert.ToDateTime(outRecord.InDateTime);
                var card_in_date = Convert.ToDateTime(outRecord.CardIndate);
                var outDateTime = Convert.ToDateTime(outRecord.OutDateTime);
                var payDateTime = Convert.ToDateTime(outRecord.PayDateTime);

                //Console.WriteLine("indate: " + inDate);
                //Console.WriteLine(inDate.ToString("yyyy-MM-dd HH:mm:ss"));

                var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    property_id = "5",
                    record_no = outRecord.RecordNo,
                    compute_no = outRecord.ComputeNo,
                    park_no = outRecord.ParkNo,
                    card_no = outRecord.CardNo,
                    car_no = outRecord.CarNo,
                    card_type = outRecord.CardType,
                    card_in_date = card_in_date.ToString("yyyy-MM-dd HH:mm:ss"),
                    card_amount = outRecord.CardAmount,
                    car_type = outRecord.CarType,
                    car_style = outRecord.CarStyle,
                    car_color = outRecord.CarColor,
                    master_name = outRecord.MasterName,
                    master_id = outRecord.MasterID,
                    master_tel = outRecord.MasterTel,
                    master_addr = outRecord.MasterAddr,
                    park_position = outRecord.ParkPosition,
                    in_track_name = outRecord.InTrackName,
                    in_date_time = inDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    in_picture_name = outRecord.InPictureName,
                    in_operator_name = outRecord.InOperatorName,
                    in_style = outRecord.InStyle,
                    out_track_name = outRecord.OutTrackName,
                    out_date_time = outDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    out_picture_name = outRecord.OutPictureName,
                    out_operator_name = outRecord.OutOperatorName,
                    out_style = outRecord.OutStyle,
                    car_free = outRecord.CarFee,
                    pay_amount = outRecord.CardAmount,
                    card_pay_amount = outRecord.CardPayAmount,
                    pay_date_time = payDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    park_time = outRecord.ParkTime,
                    pic_in_add = outRecord.PicInAdd,
                    pic_out_add = outRecord.PicOutAdd,
                    remark = outRecord.Remark
                });


                request.AddHeader("Accept", "application/json");
                request.Parameters.Clear();
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                /*
                request.AddParameter("property_id", 12);
                request.AddParameter("recordNo", outRecord.RecordNo);
                request.AddParameter("computeNo", outRecord.ComputeNo);
                request.AddParameter("parkNo", outRecord.ParkNo);
                request.AddParameter("cardNo", outRecord.CardNo);
                request.AddParameter("carNo", outRecord.CarNo);
                request.AddParameter("cardType", outRecord.CardType);
                request.AddParameter("cardIndate", outRecord.CardIndate);
                request.AddParameter("cardAmount", outRecord.CardAmount);
                request.AddParameter("carType", outRecord.CarType);
                request.AddParameter("carStyle", outRecord.CarStyle);
                request.AddParameter("carColor", outRecord.CarColor);
                request.AddParameter("masterName", outRecord.MasterName);
                request.AddParameter("masterID", outRecord.MasterID);
                request.AddParameter("masterTel", outRecord.MasterTel);
                request.AddParameter("masterAddr", outRecord.MasterAddr);
                request.AddParameter("parkPosition", outRecord.ParkPosition);
                request.AddParameter("inTrackName", outRecord.InTrackName);
                request.AddParameter("inDateTime", outRecord.InDateTime);
                request.AddParameter("inPictureName", outRecord.InPictureName);
                request.AddParameter("inOperatorName", outRecord.InOperatorName);
                request.AddParameter("inStyle", outRecord.InStyle);
                request.AddParameter("outTrackName", outRecord.OutTrackName);
                request.AddParameter("outDateTime", outRecord.OutDateTime);
                request.AddParameter("outPictureName", outRecord.OutPictureName);
                request.AddParameter("outOperatorName", outRecord.OutOperatorName);
                request.AddParameter("outStyle", outRecord.OutStyle);
                request.AddParameter("carFee", outRecord.CarFee);
                request.AddParameter("payAmount", outRecord.PayAmount);
                request.AddParameter("cardPayAmount", outRecord.CardPayAmount);
                request.AddParameter("payDateTime", outRecord.PayDateTime);
                request.AddParameter("parkTime", outRecord.ParkTime);
                request.AddParameter("picInAdd", outRecord.PicInAdd);
                request.AddParameter("picOutAdd", outRecord.PicOutAdd);
                request.AddParameter("remark", outRecord.Remark); */

                //request.AddHeader("Content-Type", "application/json; chaset-utf-8");

            
                var respone = await client.ExecutePostTaskAsync(request);

                if (respone.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string rawRespone = respone.Content;
                    Message message = JsonConvert.DeserializeObject<Message>(rawRespone);
                    Console.WriteLine("status: " + message.success + "Message: " + message.msg);

                    if (message.success == true)
                    {
                        OutRecordRepo outRecordRepo = new OutRecordRepo();
                        outRecordRepo.updateSign(outRecord.RecordNo);
                    }
                }
                Console.WriteLine(respone);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
