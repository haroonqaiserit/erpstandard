using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public class AccountsServices
    {
        public void SaveAccounts(Account account)
        {
            using (var context = new SairaIndEntities())
            {
                account.AcntId = context.Accounts.Where(x => x.CompNo == StandardVariables.CompNo && x.Status == StandardVariables.BranchNo).Select(x => x.AcntId).Max();

                double newacntid = double.Parse(account.AcntId.Substring(account.AcntId.Length - 4));
                
                context.Accounts.Add(account);
            }
        }       
    }
}
