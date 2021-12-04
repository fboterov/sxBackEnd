using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace sxBackEnd.db
{
    public interface IMembersService
    {
        IEnumerable<Member> GetMemberRecords(long? MemberCardNumber = long.MinValue, long? PolicyNumber = long.MinValue);
    }

    public class MembersService : IMembersService
    {
        private List<Member> Members;

        public MembersService()
        {
            LoadData();
        }

        public IEnumerable<Member> GetMemberRecords(long? MemberCardNumber = long.MinValue, long? PolicyNumber = long.MinValue) 
        {
            var result = Members.Where(c => c.MemberCardNumber == MemberCardNumber || c.PolicyNumber == PolicyNumber);
            return result;
        }

        private void LoadData() 
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            var format = "dd/MM/yyyy";
            var dateTimeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = format };

            Members = new List<Member>();
            Members = JsonConvert.DeserializeObject<List<Member>>(File.ReadAllText($@"{path}\db\MOCK_DATA.json"), dateTimeConverter);
        }
    }
}
