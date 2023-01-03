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
        StandardVariables standard = new StandardVariables();
        public void SaveAccounts(Account account)
        {
            using (var context = new SairaIndEntities())
            {
                account.AcntId = context.Accounts.Where(x => x.CompNo == standard.CompNo && x.Status == standard.BranchNo && x.).Select(x => x.AcntId).Max();

                double newacntid = double.Parse(account.AcntId.Substring(account.AcntId.Length - 4));
                
                context.Accounts.Add(account);
            }
        }       
    }
}
