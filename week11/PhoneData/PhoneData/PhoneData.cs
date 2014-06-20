using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneData
{
    public class PhoneBook
    {
        public List<PhoneData> phoneList;

        public string GetAllData()
        {
            string ret="";
            foreach(PhoneData p in phoneList)
            {
                ret += string.Format("{0}||{1}||{2}\r\n", p.mName, p.mGroup, p.mPhone);
            }
            return ret;
        }

        public PhoneBook()
        {
            phoneList = new List<PhoneData>();
        }
        
        public void add(string name,string phonenum, string group)
        {
            PhoneData p = new PhoneData(name, phonenum, group);
            phoneList.Add(p);
        }

        public PhoneData FindPeople(string name) // PhoneData는 리턴타입, 리스트에서 이름 가지고 폰데이터 찾기
        {
            foreach(PhoneData p in phoneList)
            {
                if(p.mName==name)
                {
                    return p;
                }
            }
            return null;
        }
    }

    public class PhoneData
    {
        public string mName;
        public string mPhone;
        public string mGroup;

        public PhoneData()
        {
        }

        public PhoneData(string name,string phone,string group) // 생성자
        {
            mName = name;
            mPhone = phone;
            mGroup = group;
        }
    }
}
