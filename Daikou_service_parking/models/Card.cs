using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daikou_service_parking
{
    class Card
    {
        private String cardNo;
        private String carNo;
        private String cardType;
        private String cardIndate;
        private String cardAmount;
        private String carType;
        private String carStyle;
        private String carColor;
        private String masterName;
        private String masterID;
        private String masterTel;
        private String masterAddr;
        private String parkNo;
        private String parkPosition;
        private String payAmount;
        private String makeDateTime;
        private String operatorName;
        private String enable;
        private String remark;

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
        public string ParkNo { get => parkNo; set => parkNo = value; }
        public string ParkPosition { get => parkPosition; set => parkPosition = value; }
        public string PayAmount { get => payAmount; set => payAmount = value; }
        public string MakeDateTime { get => makeDateTime; set => makeDateTime = value; }
        public string OperatorName { get => operatorName; set => operatorName = value; }
        public string Enable { get => enable; set => enable = value; }
        public string Remark { get => remark; set => remark = value; }

        public Card(string cardNo, string carNo, string cardType, string cardIndate, string cardAmount, string carType, string carStyle, string carColor, string masterName, string masterID, string masterTel, string masterAddr, string parkNo, string parkPosition, string payAmount, string makeDateTime, string operatorName, string enable, string remark)
        {
            CardNo = cardNo;
            CarNo = carNo;
            CardType = cardType;
            CardIndate = cardIndate;
            CardAmount = cardAmount;
            CarType = carType;
            CarStyle = carStyle;
            CarColor = carColor;
            MasterName = masterName;
            MasterID = masterID;
            MasterTel = masterTel;
            MasterAddr = masterAddr;
            ParkNo = parkNo;
            ParkPosition = parkPosition;
            PayAmount = payAmount;
            MakeDateTime = makeDateTime;
            OperatorName = operatorName;
            Enable = enable;
            Remark = remark;
        }


    }
}
