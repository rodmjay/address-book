using System.Collections.Generic;
using System.Web;
using AddressBook.Models;

namespace AddressBook.Tests
{
    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> _mSessionStorage = new Dictionary<string, object>();

        public override object this[string name]
        {
            get { return _mSessionStorage[name]; }
            set { _mSessionStorage[name] = value; }
        }

        public override void Add(string name, object value)
        {
            _mSessionStorage.Add(name, value);
        }
    }
}