using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using Daikou_service_parking.models;

namespace Daikou_service_parking.repo
{
    class OutRecordRepo
    {
        DbProviderFactory factory;
        string provider;
        string connectionString;

        public OutRecordRepo()
        {
            provider = ConfigurationSettings.AppSettings["provider"];
            connectionString = ConfigurationSettings.AppSettings["connectionString"];
            factory = DbProviderFactories.GetFactory(provider);
        }
        public List<OutReport> GetAll()
        {
            var outReports = new List<OutReport>();
            using (var connection = factory.CreateConnection())
            {

                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "Select * From OutRecord;";
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        outReports.Add(new OutReport
                        {
                            RecordNo = reader["RecordNo"] != DBNull.Value ? ((int)reader["RecordNo"]).ToString() : " ",
                            ComputeNo = reader["ComputeNo"] != DBNull.Value ? (string)reader["ComputeNo"] : " ",
                            ParkNo = reader["ParkNo"] != DBNull.Value ? (string)reader["ParkNo"] : " ",
                            CardNo = reader["CardNo"] != DBNull.Value ? (string)reader["CardNo"] : " ",
                            CarNo = reader["CarNo"] != DBNull.Value ? (string)reader["CarNo"] : " ",
                            CardType = reader["CardType"] != DBNull.Value ? (string)reader["CardType"] : " ",
                            CardIndate = reader["CardIndate"] != DBNull.Value ? ((DateTime)reader["CardIndate"]).ToString() : " ",
                            CardAmount = reader["CardAmount"] != DBNull.Value ? ((decimal)reader["CardAmount"]).ToString() : " ",
                            CarType = reader["CarType"] != DBNull.Value ? (string)reader["CarType"] : " ",
                            CarStyle = reader["CarStyle"] != DBNull.Value ? (string)reader["CarStyle"] : " ",
                            CarColor = reader["CarColor"] != DBNull.Value ? (string)reader["CarColor"] : " ",
                            MasterName = reader["MasterName"] != DBNull.Value ? (string)reader["MasterName"] : " ",
                            MasterID = reader["MasterID"] != DBNull.Value ? (string)reader["MasterID"] : " ",
                            MasterTel = reader["MasterTel"] != DBNull.Value ? (string)reader["MasterTel"] : " ",
                            MasterAddr = reader["MasterAddr"] != DBNull.Value ? (string)reader["MasterAddr"] : " ",
                            ParkPosition = reader["ParkPosition"] != DBNull.Value ? (string)reader["ParkPosition"] : " ",
                            InTrackName = reader["InTrackName"] != DBNull.Value ? (string)reader["InTrackName"] : " ",
                            InDateTime = reader["InDateTime"] != DBNull.Value ? ((DateTime)reader["InDateTime"]).ToString() : " ",
                            InPictureName = reader["InPictureName"] != DBNull.Value ? (string)reader["InPictureName"] : " ",
                            InOperatorName = reader["InOperatorName"] != DBNull.Value ? (string)reader["InOperatorName"] : " ",
                            InStyle = reader["InStyle"] != DBNull.Value ? (string)reader["InStyle"] : " ",
                            OutTrackName = reader["OutTrackName"] != DBNull.Value ? (string)reader["OutTrackName"] : " ",
                            OutDateTime = reader["OutDateTime"] != DBNull.Value ? ((DateTime)reader["OutDateTime"]).ToString() : " ",
                            OutPictureName = reader["OutPictureName"] != DBNull.Value ? (string)reader["OutPictureName"] : " ",
                            OutOperatorName = reader["OutOperatorName"] != DBNull.Value ? (string)reader["OutOperatorName"] : " ",
                            OutStyle = reader["OutStyle"] != DBNull.Value ? (string)reader["OutStyle"] : " ",
                            CarFee = reader["CarFee"] != DBNull.Value ? ((decimal)reader["CarFee"]).ToString() : " ",
                            PayAmount = reader["PayAmount"] != DBNull.Value ? ((decimal)reader["PayAmount"]).ToString() : " ",
                            CardPayAmount = reader["CardPayAmount"] != DBNull.Value ? ((decimal)reader["CardPayAmount"]).ToString() : " ",
                            PayDateTime = reader["PayDateTime"] != DBNull.Value ? ((DateTime)reader["PayDateTime"]).ToString() : " ",
                            ParkTime = reader["ParkTime"] != DBNull.Value ? (string)reader["ParkTime"] : " ",
                            PicInAdd = reader["PicInAdd"] != DBNull.Value ? (string)reader["PicInAdd"] : " ",
                            PicOutAdd = reader["PicOutAdd"] != DBNull.Value ? (string)reader["PicOutAdd"] : " ",
                            Remark = reader["Remark"] != DBNull.Value ? (string)reader["Remark"] : " "
                        }
                       );
                    }
                }
            }

            return outReports;
        }

        // Select* From OutRecord WHERE sign IS NULL LIMIT 20;
        public List<OutReport> GetUnsignLimit()
        {
            var outReports = new List<OutReport>();
            using (var connection = factory.CreateConnection())
            {

                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "Select Top 20 * From OutRecord WHERE sign IS NULL;";
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        outReports.Add(new OutReport
                        {
                            RecordNo = reader["RecordNo"] != DBNull.Value ? ((int)reader["RecordNo"]).ToString() : " ",
                            ComputeNo = reader["ComputeNo"] != DBNull.Value ? (string)reader["ComputeNo"] : " ",
                            ParkNo = reader["ParkNo"] != DBNull.Value ? (string)reader["ParkNo"] : " ",
                            CardNo = reader["CardNo"] != DBNull.Value ? (string)reader["CardNo"] : " ",
                            CarNo = reader["CarNo"] != DBNull.Value ? (string)reader["CarNo"] : " ",
                            CardType = reader["CardType"] != DBNull.Value ? (string)reader["CardType"] : " ",
                            CardIndate = reader["CardIndate"] != DBNull.Value ? ((DateTime)reader["CardIndate"]).ToString() : " ",
                            CardAmount = reader["CardAmount"] != DBNull.Value ? ((decimal)reader["CardAmount"]).ToString() : " ",
                            CarType = reader["CarType"] != DBNull.Value ? (string)reader["CarType"] : " ",
                            CarStyle = reader["CarStyle"] != DBNull.Value ? (string)reader["CarStyle"] : " ",
                            CarColor = reader["CarColor"] != DBNull.Value ? (string)reader["CarColor"] : " ",
                            MasterName = reader["MasterName"] != DBNull.Value ? (string)reader["MasterName"] : " ",
                            MasterID = reader["MasterID"] != DBNull.Value ? (string)reader["MasterID"] : " ",
                            MasterTel = reader["MasterTel"] != DBNull.Value ? (string)reader["MasterTel"] : " ",
                            MasterAddr = reader["MasterAddr"] != DBNull.Value ? (string)reader["MasterAddr"] : " ",
                            ParkPosition = reader["ParkPosition"] != DBNull.Value ? (string)reader["ParkPosition"] : " ",
                            InTrackName = reader["InTrackName"] != DBNull.Value ? (string)reader["InTrackName"] : " ",
                            InDateTime = reader["InDateTime"] != DBNull.Value ? ((DateTime)reader["InDateTime"]).ToString() : " ",
                            InPictureName = reader["InPictureName"] != DBNull.Value ? (string)reader["InPictureName"] : " ",
                            InOperatorName = reader["InOperatorName"] != DBNull.Value ? (string)reader["InOperatorName"] : " ",
                            InStyle = reader["InStyle"] != DBNull.Value ? (string)reader["InStyle"] : " ",
                            OutTrackName = reader["OutTrackName"] != DBNull.Value ? (string)reader["OutTrackName"] : " ",
                            OutDateTime = reader["OutDateTime"] != DBNull.Value ? ((DateTime)reader["OutDateTime"]).ToString() : " ",
                            OutPictureName = reader["OutPictureName"] != DBNull.Value ? (string)reader["OutPictureName"] : " ",
                            OutOperatorName = reader["OutOperatorName"] != DBNull.Value ? (string)reader["OutOperatorName"] : " ",
                            OutStyle = reader["OutStyle"] != DBNull.Value ? (string)reader["OutStyle"] : " ",
                            CarFee = reader["CarFee"] != DBNull.Value ? ((decimal)reader["CarFee"]).ToString() : " ",
                            PayAmount = reader["PayAmount"] != DBNull.Value ? ((decimal)reader["PayAmount"]).ToString() : " ",
                            CardPayAmount = reader["CardPayAmount"] != DBNull.Value ? ((decimal)reader["CardPayAmount"]).ToString() : " ",
                            PayDateTime = reader["PayDateTime"] != DBNull.Value ? ((DateTime)reader["PayDateTime"]).ToString() : " ",
                            ParkTime = reader["ParkTime"] != DBNull.Value ? (string)reader["ParkTime"] : " ",
                            PicInAdd = reader["PicInAdd"] != DBNull.Value ? (string)reader["PicInAdd"] : " ",
                            PicOutAdd = reader["PicOutAdd"] != DBNull.Value ? (string)reader["PicOutAdd"] : " ",
                            Remark = reader["Remark"] != DBNull.Value ? (string)reader["Remark"] : " "
                        }
                       );
                    }
                }
            }

            return outReports;
        }

        public void Add(OutReport outReport)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"Insert Into OutRecord (" +
                    $"RecordNo, ComputeNo," +
                    $"ParkNo, CardNo," +
                    $"CarNo,CardType, " +
                    $"CardIndate, CardAmount, " +
                    $"CarType, CarStyle," +
                    $"CarColor,MasterName, " +
                    $"MasterID,MasterTel, " +
                    $"MasterAddr,ParkPosition, " +
                    $"InTrackName,InDateTime, " +
                    $"InPictureName,InOperatorName, " +
                    $"InStyle,OutTrackName, " +
                    $"OutDateTime,OutPictureName, " +
                    $"OutOperatorName,OutStyle, " +
                    $"CarFee, PayAmount, " +
                    $"CardPayAmount,PayDateTime, " +
                    $"ParkTime,PicInAdd,  " +
                    $"PicOutAdd, Remark) Values" +
                    $"('{outReport.RecordNo}', '{outReport.ComputeNo}', " +
                    $"'{outReport.ParkNo}', '{outReport.CardNo}', " +
                    $"'{outReport.CarNo}', '{outReport.CardType}', " +
                    $"'{outReport.CardIndate}', '{outReport.CardAmount}', " +
                    $"'{outReport.CarType}', '{outReport.CarStyle}', " +
                    $"'{outReport.CarColor}', '{outReport.MasterName}', " +
                    $"'{outReport.MasterID}', '{outReport.MasterTel}'," +
                    $"'{outReport.MasterAddr}', '{outReport.ParkPosition}'," +
                    $"'{outReport.InTrackName}','{outReport.InDateTime}', " +
                    $"'{outReport.InPictureName}', '{outReport.InOperatorName}'," +
                    $"'{outReport.InStyle}', '{outReport.OutTrackName}'," +
                    $"'{outReport.OutDateTime}', '{outReport.OutPictureName}'," +
                    $"'{outReport.OutOperatorName}','{outReport.OutStyle}', " +
                    $"'{outReport.CarFee}', '{outReport.PayAmount}'," +
                    $"'{outReport.CardPayAmount}', '{outReport.PayDateTime}'," +
                    $"'{outReport.ParkTime}','{outReport.PicInAdd}'," +
                    $"'{outReport.PicOutAdd}', '{outReport.Remark}');";

                command.ExecuteNonQuery();
            }
        }
        public void Update(OutReport outReport)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"Update OutRecord Set  " +
                    $", ComputeNo = '{outReport.ComputeNo}'" +
                    $", ParkNo= '{outReport.ParkNo}'" +
                    $", CardNo= '{outReport.CardNo}'" +
                    $", CarNo= '{outReport.CarNo}'" +
                    $", CardType= '{outReport.CardType}'" +
                    $", CardIndate= '{outReport.CardIndate}'" +
                    $", CardAmount= '{outReport.CardAmount}'" +
                    $", CarType= '{outReport.CarType}'" +
                    $", CarStyle= '{outReport.CarStyle}'" +
                    $", CarColor= '{outReport.CarColor}'" +
                    $", MasterName= '{outReport.MasterName}'" +
                    $", MasterID= '{outReport.MasterID}'" +
                    $", MasterTel= '{outReport.MasterTel}'" +
                    $", MasterAddr= '{outReport.MasterAddr}'" +
                    $", ParkPosition= '{outReport.ParkPosition}'" +
                    $", InTrackName= '{outReport.InTrackName}'" +
                    $", InDateTime= '{outReport.InDateTime}'" +
                    $", InPictureName= '{outReport.InPictureName}'" +
                    $", InOperatorName= '{outReport.InOperatorName}'" +
                    $", InStyle= '{outReport.InStyle}'" +
                    $", OutTrackName= '{outReport.OutTrackName}'" +
                    $", OutDateTime= '{outReport.OutDateTime}'" +
                    $", OutPictureName= '{outReport.OutPictureName}'" +
                    $", OutOperatorName= '{outReport.OutOperatorName}'" +
                    $", OutStyle= '{outReport.OutStyle}'" +
                    $", CarFee= '{outReport.CarFee}'" +
                    $", PayAmount= '{outReport.PayAmount}'" +
                    $", CardPayAmount= '{outReport.CardPayAmount}'" +
                    $", PayDateTime= '{outReport.PayDateTime}'" +
                    $", ParkTime= '{outReport.ParkTime}'" +
                    $", PicInAdd= '{outReport.PicInAdd}'" +
                    $", PicOutAdd= '{outReport.PicOutAdd}'" +
                    $", Remark= '{outReport.Remark}'" +
                    $" Where RecordNo = {outReport.RecordNo};";

                command.ExecuteNonQuery();
            }
        }

        public void updateSign(string id)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"Update OutRecord Set sign =  1 " +
                    $" Where RecordNo = {id};";

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"Delete From OutRecord Where Id = {id};";
                command.ExecuteNonQuery();
            }
        }
    }
}
