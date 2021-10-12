using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace Daikou_service_parking.repo
{
    class CardRepo
    {
        DbProviderFactory factory;
        string provider;
        string connectionString;

        public CardRepo()
        {
            provider = ConfigurationSettings.AppSettings["provider"];
            connectionString = ConfigurationSettings.AppSettings["connectionString"];
            factory = DbProviderFactories.GetFactory(provider);
        }
        public List<Card> GetAll()
        {
            var cards = new List<Card>();
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "Select * From CardIssue;";
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cards.Add(new Card
                        ((string)reader["CardNo"],
                         (string)reader["CarNo"],
                         (string)reader["CardType"],
                         ((DateTime)reader["CardIndate"]).ToString(),
                         ((decimal)reader["CardAmount"]).ToString(),
                         (string)reader["CarType"],
                         (string)reader["CarStyle"],
                         (string)reader["CarColor"],
                         (string)reader["MasterName"],
                         (string)reader["MasterID"],
                         (string)reader["MasterTel"],
                         (string)reader["MasterAddr"],
                         (string)reader["ParkNo"],
                         (string)reader["ParkPosition"],
                         ((decimal)reader["PayAmount"]).ToString(),
                         ((DateTime)reader["MakeDateTime"]).ToString(),
                         (string)reader["OperatorName"],
                         ((bool)reader["Enable"]).ToString(),
                         (string)reader["Remark"]
                         )
                     );
                    }
                }
            }

            return cards;
        }
        public void Add(Card card)
        {
            using (var connection = factory.CreateConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    var command = factory.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = $"SET ANSI_WARNINGS OFF Insert Into CardIssue (CardNo, CarNo, CardType, CardIndate, CardAmount, CarType, CarStyle, CarColor, MasterName, MasterID, MasterTel, MasterAddr, ParkNo, ParkPosition, PayAmount, MakeDateTime, OperatorName, Enable,Remark) Values " +
                        $"('{card.CardNo}', '{card.CardNo}', '{card.CardType}', '{card.CardIndate}', '{card.CardAmount}', '{card.CarType}', '{card.CarStyle}', '{card.CarColor}'" +
                        $", '{card.MasterName}', '{card.MasterID}', '{card.MasterTel}', '{card.MasterAddr}', '{card.ParkNo}', '{card.ParkPosition}'" +
                        $", '{card.PayAmount}', '{card.MakeDateTime}', '{card.OperatorName}', '{card.Enable}', '{card.Remark}') SET ANSI_WARNINGS ON";
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error add: " + e.Message);
                }
            }
        }
        public void Update(Card card)
        {
            using (var connection = factory.CreateConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    var command = factory.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = $"Update CardIssue Set CarNo = '{card.CarNo}', CardType = '{card.CardType}' , CardIndate = '{card.CardIndate}', CardAmount = '{card.CardAmount}', CarType= '{card.CarType}', CarStyle = '{card.CarStyle}', CarColor= '{card.CarColor}'" +
                        $", MasterName = '{card.MasterName}', MasterID = '{card.MasterID}', MasterTel = '{card.MasterTel}', MasterAddr = '{card.MasterAddr}', ParkNo = '{card.ParkNo}', ParkPosition = '{card.ParkPosition}', PayAmount= '{card.PayAmount}', MakeDateTime = '{card.MakeDateTime}' , OperatorName= '{card.OperatorName}', Enable,Remark = '{card.Remark}' " +
                        $"Where CardNo = {card.CardNo};";
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Update Error: " + e.Message);
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = factory.CreateConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    var command = factory.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = $"Delete From CardIssue Where CardNo = {id};";
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Delete Error: " + e.Message);
                }
            }
        }
    }
}
