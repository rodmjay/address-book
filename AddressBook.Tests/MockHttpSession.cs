using System.Collections.Generic;
using System.Web;

namespace AddressBook.Tests
{
    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();

        public override object this[string name]
        {
            get { return m_SessionStorage[name]; }
            set { m_SessionStorage[name] = value; }
        }

        public override void Add(string name, object value)
        {
            m_SessionStorage.Add(name, value);
        }
    }
}