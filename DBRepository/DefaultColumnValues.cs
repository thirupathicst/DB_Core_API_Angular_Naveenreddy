using System;
using System.Collections.Generic;
using System.Text;

namespace DBRepository
{
    public class DefaultColumnValues
    {
        private DateTime _CreatedDateTime;
        public DateTime CreatedDateTime
        {
            get { return _CreatedDateTime; }
            private set
            {
                if (_CreatedDateTime == null)
                {
                    _CreatedDateTime = DateTime.Now;
                }
            }
        }
        public DateTime UpdatedDateTime { get; set; }
    }
}
