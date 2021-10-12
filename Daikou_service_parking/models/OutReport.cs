using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daikou_service_parking.models
{
    // Select property Then press Ctrl+r Then press Ctrl+e
    public class OutReport
    {
        private string recordNo;
        private string computeNo;
        private string parkNo;
        private string cardNo;
        private string carNo;
        private string cardType;
        private string cardIndate;
        private string cardAmount;
        private string carType;
        private string carStyle;
        private string carColor;
        private string masterName;
        private string masterID;
        private string masterTel;
        private string masterAddr;
        private string parkPosition;
        private string inTrackName;
        private string inDateTime;
        private string inPictureName;
        private string inOperatorName;
        private string inStyle;
        private string outTrackName;
        private string outDateTime;
        private string outPictureName;
        private string outOperatorName;
        private string outStyle;
        private string carFee;
        private string payAmount;
        private string cardPayAmount;
        private string payDateTime;
        private string parkTime;
        private string picInAdd;
        private string picOutAdd;
        private string remark;


        public string RecordNo { get => recordNo; set => recordNo = value; }
        public string ComputeNo { get => computeNo; set => computeNo = value; }
        public string ParkNo { get => parkNo; set => parkNo = value; }
        public string CardNo { get => cardNo; set => cardNo = value; }
        public string CarNo { get => carNo; set => carNo = value; }
        public string CardType { get => cardType; set => cardType = value; }
        public string CardIndate { get => cardIndate; set => cardIndate = value; }
        public string CardAmount { get => cardAmount; set => cardAmount = value; }
        public string CarType { get => carType; set => carType = value; }
        public string CarStyle { get => carStyle; set => carStyle = value; }
        public string CarColor { get => carColor; set => carColor = value; }
        public string MasterName { get => masterName; set => masterName = value; }
        public string MasterID { get => masterID; set => masterID = value; }
        public string MasterTel { get => masterTel; set => masterTel = value; }
        public string MasterAddr { get => masterAddr; set => masterAddr = value; }
        public string ParkPosition { get => parkPosition; set => parkPosition = value; }
        public string InTrackName { get => inTrackName; set => inTrackName = value; }
        public string InDateTime { get => inDateTime; set => inDateTime = value; }
        public string InPictureName { get => inPictureName; set => inPictureName = value; }
        public string InOperatorName { get => inOperatorName; set => inOperatorName = value; }
        public string InStyle { get => inStyle; set => inStyle = value; }
        public string OutTrackName { get => outTrackName; set => outTrackName = value; }
        public string OutDateTime { get => outDateTime; set => outDateTime = value; }
        public string OutPictureName { get => outPictureName; set => outPictureName = value; }
        public string OutOperatorName { get => outOperatorName; set => outOperatorName = value; }
        public string OutStyle { get => outStyle; set => outStyle = value; }
        public string CarFee { get => carFee; set => carFee = value; }
        public string PayAmount { get => payAmount; set => payAmount = value; }
        public string CardPayAmount { get => cardPayAmount; set => cardPayAmount = value; }
        public string PayDateTime { get => payDateTime; set => payDateTime = value; }
        public string ParkTime { get => parkTime; set => parkTime = value; }
        public string PicInAdd { get => picInAdd; set => picInAdd = value; }
        public string PicOutAdd { get => picOutAdd; set => picOutAdd = value; }
        public string Remark { get => remark; set => remark = value; }
    }
}
