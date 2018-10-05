using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    interface IDiscInfo
    {
        [OperationContract]
        List<Disc> ShowAllDiscs();
        [OperationContract]
        List< SellInfo> AllSellInfo();
        [OperationContract]
       List<GroupInfo> TotalAmountSellGroup(string GroupName);
        [OperationContract]
        string MostPopularGroup();
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        bool AddDiscBand(SellInfo sellInfo);
        [OperationContract(IsOneWay = true)]
        void AddSell(string discName, string cashier);


    }
}
