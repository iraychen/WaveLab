using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISYSSecurityMasterService
    {
        bool CheckExists(string userId);
        bool CheckPWD(string userId, string encryptPassWord);
        bool CheckActive(string userId);
        bool IsAdmin(string userId);
        IList<int> GetACMenu(string userId);

        IList<SYSSecurityMasterInfo> Query(Hashtable hashTable, string sortBy, string orderBy);
        void Save(SYSSecurityMasterInfo entity);
        SYSSecurityMasterInfo GetDetail(string userId);
        void Update(SYSSecurityMasterInfo entity);

        IList<SYSRoleInfo> GetRoles(string userId);
        void SaveRoleMapping(string userId, IList<SYSRoleInfo> roleItems);

        Byte[] ExportToPdf(string userId, string userName, string passWord);
        bool CheckPerm(string UserId, string op);
    }
}
